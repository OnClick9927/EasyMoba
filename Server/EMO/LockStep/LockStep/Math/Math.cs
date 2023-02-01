
namespace LockStep.Math
{
    public static partial class LMath
    {
        public const long LPIQuad = 785398L;  //0.7853981
        public const long LPIHalf = 1570796L;  //1.5707963
        public const long LPI = 3141593L;  //3.1415926
        public const long LPI2 = 6283185L;  //6.2831853
        public const long LRad2Deg = 57295780L;  //57.2957795
        public const long LDeg2Rad = 17453L;  //0.0174532
        public static readonly LFloat PIQuad = LFloat.CreateByRaw(LPIHalf);
        public static readonly LFloat PIHalf = LFloat.CreateByRaw(LPIHalf);
        public static readonly LFloat PI = LFloat.CreateByRaw(LPI);
        public static readonly LFloat PI2 = LFloat.CreateByRaw(LPI2);
        public static readonly LFloat Rad2Deg = LFloat.CreateByRaw(LRad2Deg);
        public static readonly LFloat Deg2Rad = LFloat.CreateByRaw(LDeg2Rad);
        public static LFloat Pi => PI;

        #region Atan2
        public static long _Atan2(long y, long x)
        {
            //特殊情况处理
            if (y == 0)
            {
                if (x == 0)
                {
                    return 0;
                }

                return x < 0 ? LMath.LPI : 0;
            }

            if (x == 0)
            {
                return y > 0 ? LMath.LPIHalf : -LMath.LPIHalf;
            }

            //决定象限
            int idxV = 0;
            if (x < 0)
            {
                x = -x;
                idxV += 4;
            }

            if (y < 0)
            {
                y = -y;
                idxV += 2;
            }

            LFloat factor = 0;
            if (y > x)
            {
                idxV += 1;
                factor = new LFloat(y) / x;
            }
            else
            {
                factor = new LFloat(x) / y;
            }

            //逆时针 idx 为 0 1 5 4 6 7 3 2
            var info = idx2LutInfo[idxV];
            if (x == y)
            {
                return info.offset;
            }
            var deg = _LutATan(factor) - LMath.LPIQuad;
            return info.sign * deg + info.offset;
        }

        private static LutAtan2Helper[] idx2LutInfo = new LutAtan2Helper[] {
            new LutAtan2Helper(-1, LMath.LPIQuad),
            new LutAtan2Helper(1, LMath.LPIQuad),
            new LutAtan2Helper(1, -LMath.LPIQuad),
            new LutAtan2Helper(-1, -LMath.LPIQuad),

            new LutAtan2Helper(1, LMath.LPIQuad * 3),
            new LutAtan2Helper(-1, LMath.LPIQuad * 3),
            new LutAtan2Helper(-1, -LMath.LPIQuad * 3),
            new LutAtan2Helper(1, -LMath.LPIQuad * 3),
        };
        public struct LutAtan2Helper
        {
            public long sign;
            public long offset;

            public LutAtan2Helper(long sign, long offset)
            {
                this.sign = sign;
                this.offset = offset;
            }
        }

        public static long _LutATan(LFloat ydx)
        {
            if (ydx >= LUTAtan2.MaxQueryIdx) return LMath.LPIHalf;
            var iydx = (int)ydx;
            var startIdx = LUTAtan2._startIdx[iydx - 1];
            var size = LUTAtan2._arySize[iydx - 1];
            var remaind = ydx - iydx;
            var idx = startIdx + (int)(remaind * size);
            return LUTAtan2._tblTbl[idx];
        }
        #endregion

        public static LFloat Atan2(LFloat y, LFloat x)
        {
            return Atan2(y._val, x._val);
        }

        public static LFloat Atan2(long y, long x)
        {
            return LFloat.CreateByRaw(_Atan2(y, x));
        }

        public static LFloat Acos(LFloat val)
        {
            int idx = (int)(val._val * LUTAcos.HALF_COUNT / LFloat.Precision) +
                      LUTAcos.HALF_COUNT;
            idx = Clamp(idx, 0, LUTAcos.COUNT);
            return LFloat.CreateByRaw(LUTAcos.table[idx]);
        }

        public static LFloat Asin(LFloat val)
        {
            int idx = (int)(val._val * LUTAsin.HALF_COUNT / LFloat.Precision) +
                      LUTAsin.HALF_COUNT;
            idx = Clamp(idx, 0, LUTAsin.COUNT);
            return LFloat.CreateByRaw(LUTAsin.table[idx]);
        }

        //ccw
        public static LFloat Sin(LFloat radians)
        {
            return LFloat.CreateByRaw(LUTSin.table[_GetIdx(radians)]);
        }

        //ccw
        public static LFloat Cos(LFloat radians)
        {
            return LFloat.CreateByRaw(LUTCos.table[_GetIdx(radians)]);
        }

        private static int _GetIdx(LFloat radians)
        {
            var rawVal = radians._val % LMath.LPI2;
            if (rawVal < 0) rawVal += LMath.LPI2;
            var val = LFloat.CreateByRaw(rawVal) / LMath.PI2;
            var idx = (int)(val * LUTCos.COUNT);
            idx = Clamp(idx, 0, LUTCos.COUNT);
            return idx;
        }

        //ccw
        public static void SinCos(out LFloat s, out LFloat c, LFloat radians)
        {
            int idx = _GetIdx(radians);
            s = LFloat.CreateByRaw(LUTSin.table[idx]);
            c = LFloat.CreateByRaw(LUTCos.table[idx]);
        }
        public static uint Sqrt32(uint a)
        {
            ulong rem = 0;
            ulong root = 0;
            ulong divisor = 0;
            for (int i = 0; i < 16; i++)
            {
                root <<= 1;
                rem = ((rem << 2) + (a >> 30));
                a <<= 2;
                divisor = (root << 1) + 1;
                if (divisor <= rem)
                {
                    rem -= divisor;
                    root++;
                }
            }
            return (uint)root;
        }
        //x = 2*p + q  
        //x^2 = 4*p^2 + 4pq + q^2
        //q = (x^2 - 4*p^2)/(4*p+q)  
        //https://www.cnblogs.com/10cm/p/3922398.html
        public static uint Sqrt64(ulong a)
        {
            ulong rem = 0;
            ulong root = 0;
            ulong divisor = 0;
            for (int i = 0; i < 32; i++)
            {
                root <<= 1;
                rem = ((rem << 2) + (a >> 62));//(x^2 - 4*p^2)  
                a <<= 2;
                divisor = (root << 1) + 1; //(4*p+q) 
                if (divisor <= rem)
                {
                    rem -= divisor;
                    root++;
                }
            }
            return (uint)root;
        }
        public static int Sqrt(int a)
        {
            if (a <= 0)
            {
                return 0;
            }

            return (int)LMath.Sqrt32((uint)a);
        }

        public static long Sqrt(long a)
        {
            if (a <= 0L)
            {
                return 0;
            }

            if (a <= (long)(0xffffffffu))
            {
                return (long)LMath.Sqrt32((uint)a);
            }

            return (long)LMath.Sqrt64((ulong)a);
        }

        public static LFloat Sqrt(LFloat a)
        {
            if (a._val <= 0)
            {
                return LFloat.zero;
            }

            return LFloat.CreateByRaw(Sqrt((long)a._val * LFloat.Precision));
        }

        public static LFloat Sqr(LFloat a)
        {
            return a * a;
        }


        public static uint RoundPowOfTwo(uint x)
        {
            uint val = 1;
            while (val < x)
            {
                val = val << 1;
            }
            return val;
        }
        public static ulong RoundPowOfTwo(ulong x)
        {
            ulong val = 1;
            while (val < x)
            {
                val = val << 1;
            }
            return val;
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }

        public static long Clamp(long a, long min, long max)
        {
            if (a < min)
            {
                return min;
            }

            if (a > max)
            {
                return max;
            }

            return a;
        }

        public static LFloat Clamp(LFloat a, LFloat min, LFloat max)
        {
            if (a < min)
            {
                return min;
            }

            if (a > max)
            {
                return max;
            }

            return a;
        }
        public static LFloat Clamp01(LFloat a)
        {
            if (a < LFloat.zero)
            {
                return LFloat.zero;
            }

            if (a > LFloat.one)
            {
                return LFloat.one;
            }

            return a;
        }


        public static bool SameSign(LFloat a, LFloat b)
        {
            return (long)a._val * b._val > 0L;
        }

        public static int Abs(this int val)
        {
            if (val < 0)
            {
                return -val;
            }

            return val;
        }

        public static long Abs(long val)
        {
            if (val < 0L)
            {
                return -val;
            }

            return val;
        }

        public static LFloat Abs(LFloat val)
        {
            if (val._val < 0)
            {
                return LFloat.CreateByRaw(-val._val);
            }

            return val;
        }

        public static int Sign(LFloat val)
        {
            return System.Math.Sign(val._val);
        }

        public static LFloat Round(LFloat val)
        {
            if (val <= 0)
            {
                var remainder = (-val._val) % LFloat.Precision;
                if (remainder > LFloat.HalfPrecision)
                {
                    return LFloat.CreateByRaw(val._val + remainder - LFloat.Precision);
                }
                else
                {
                    return LFloat.CreateByRaw(val._val + remainder);
                }
            }
            else
            {
                var remainder = (val._val) % LFloat.Precision;
                if (remainder > LFloat.HalfPrecision)
                {
                    return LFloat.CreateByRaw(val._val - remainder + LFloat.Precision);
                }
                else
                {
                    return LFloat.CreateByRaw(val._val - remainder);
                }
            }
        }

        public static long Max(long a, long b)
        {
            return (a <= b) ? b : a;
        }

        public static int Max(int a, int b)
        {
            return (a <= b) ? b : a;
        }

        public static long Min(long a, long b)
        {
            return (a > b) ? b : a;
        }

        public static int Min(int a, int b)
        {
            return (a > b) ? b : a;
        }
        public static int Min(params int[] values)
        {
            int length = values.Length;
            if (length == 0)
                return 0;
            int num = values[0];
            for (int index = 1; index < length; ++index)
            {
                if (values[index] < num)
                    num = values[index];
            }
            return num;
        }
        public static LFloat Min(params LFloat[] values)
        {
            int length = values.Length;
            if (length == 0)
                return LFloat.zero;
            LFloat num = values[0];
            for (int index = 1; index < length; ++index)
            {
                if (values[index] < num)
                    num = values[index];
            }
            return num;
        }
        public static int Max(params int[] values)
        {
            int length = values.Length;
            if (length == 0)
                return 0;
            int num = values[0];
            for (int index = 1; index < length; ++index)
            {
                if (values[index] > num)
                    num = values[index];
            }
            return num;
        }

        public static LFloat Max(params LFloat[] values)
        {
            int length = values.Length;
            if (length == 0)
                return LFloat.zero;
            var num = values[0];
            for (int index = 1; index < length; ++index)
            {
                if (values[index] > num)
                    num = values[index];
            }
            return num;
        }

        public static int FloorToInt(LFloat a)
        {
            var val = a._val;
            if (val < 0)
            {
                val = val - LFloat.Precision + 1;
            }
            return (int)(val / LFloat.Precision);
        }





        public static LFloat InverseLerp(LFloat a, LFloat b, LFloat value)
        {
            if (a != b)
                return Clamp01(((value - a) / (b - a)));
            return LFloat.zero;
        }

        public static bool IsPowerOfTwo(int x)
        {
            return (x & x - 1) == 0;
        }

        public static int CeilPowerOfTwo(int x)
        {
            x--;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x++;
            return x;
        }


        public static LFloat Min(LFloat a, LFloat b)
        {
            return LFloat.CreateByRaw(LMath.Min(a._val, b._val));
        }

        public static LFloat Max(LFloat a, LFloat b)
        {
            return LFloat.CreateByRaw(LMath.Max(a._val, b._val));
        }

        public static LFloat Lerp(LFloat a, LFloat b, LFloat f)
        {
            return LFloat.CreateByRaw((int)(((long)(b._val - a._val) * f._val) / LFloat.Precision) + a._val);
        }


#if UNITY_5_3_OR_NEWER

        public static LVector2 ToLVector2(this Vector2Int vec)
        {
            return LVector2.CreateByRaw( vec.x * LFloat.Precision, vec.y * LFloat.Precision);
        }
        public static LVector3 ToLVector3(this Vector3Int vec)
        {
            return LVector3.CreateByRaw( vec.x * LFloat.Precision, vec.y * LFloat.Precision, vec.z * LFloat.Precision);
        }
        public static LVector2Int ToLVector2Int(this Vector2Int vec)
        {
            return new LVector2Int(vec.x, vec.y);
        }
        public static LVector3Int ToLVector3Int(this Vector3Int vec)
        {
            return new LVector3Int(vec.x, vec.y, vec.z);
        }
        public static Vector2Int ToVector2Int(this LVector2Int vec)
        {
            return new Vector2Int(vec.x, vec.y);
        }
        public static Vector3Int ToVector3Int(this LVector3Int vec)
        {
            return new Vector3Int(vec.x, vec.y, vec.z);
        }
        public static LVector2 ToLVector2(this Vector2 vec)
        {
            return new LVector2(
                new LFloat(vec.x),
                new LFloat(vec.y));
        }
        public static LVector3 ToLVector3(this Vector3 vec)
        {
            return new LVector3(
                new LFloat(vec.x),
                new LFloat(vec.y),
                new LFloat(vec.z));
        }
        public static LVector2 ToLVector2XZ(this Vector3 vec)
        {
            return new LVector2(
                new LFloat(vec.x),
                new LFloat(vec.z));
        }
        public static Vector2 ToVector2(this LVector2 vec)
        {
            return new Vector2(vec.x.ToFloat(), vec.y.ToFloat());
        }
        public static Vector3 ToVector3(this LVector2 vec)
        {
            return new Vector3(vec.x.ToFloat(), vec.y.ToFloat(), 0);
        }
        public static Vector3 ToVector3XZ(this LVector2 vec, LFloat y)
        {
            return new Vector3(vec.x.ToFloat(), y.ToFloat(), vec.y.ToFloat());
        }
        public static Vector3 ToVector3XZ(this LVector2 vec)
        {
            return new Vector3(vec.x.ToFloat(), 0, vec.y.ToFloat());
        }
        public static Vector3 ToVector3(this LVector3 vec)
        {
            return new Vector3(vec.x.ToFloat(), vec.y.ToFloat(), vec.z.ToFloat());
        }
        public static Rect ToRect(this LRect vec)
        {
            return new Rect(vec.position.ToVector2(), vec.size.ToVector2());
        }
#endif

    }
}