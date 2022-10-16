using UnityEngine;

namespace LMath
{
    public static partial class Math
    {
        public const long LPIQuad = 785398L;  //0.7853981
        public const long LPIHalf = 1570796L;  //1.5707963
        public const long LPI = 3141593L;  //3.1415926
        public const long LPI2 = 6283185L;  //6.2831853
        public const long LRad2Deg = 57295780L;  //57.2957795
        public const long LDeg2Rad = 17453L;  //0.0174532
        //Precision = 1000000
        public static readonly LFloat PIQuad = new LFloat(true, LPIHalf);
        public static readonly LFloat PIHalf = new LFloat(true, LPIHalf);
        public static readonly LFloat PI = new LFloat(true, LPI);
        public static readonly LFloat PI2 = new LFloat(true, LPI2);
        public static readonly LFloat Rad2Deg = new LFloat(true, LRad2Deg);
        public static readonly LFloat Deg2Rad = new LFloat(true, LDeg2Rad);
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

                return x < 0 ? Math.LPI : 0;
            }

            if (x == 0)
            {
                return y > 0 ? Math.LPIHalf : -Math.LPIHalf;
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
            var deg = _LutATan(factor) - Math.LPIQuad;
            return info.sign * deg + info.offset;
        }

        private static LutAtan2Helper[] idx2LutInfo = new LutAtan2Helper[] {
            new LutAtan2Helper(-1, Math.LPIQuad),
            new LutAtan2Helper(1, Math.LPIQuad),
            new LutAtan2Helper(1, -Math.LPIQuad),
            new LutAtan2Helper(-1, -Math.LPIQuad),

            new LutAtan2Helper(1, Math.LPIQuad * 3),
            new LutAtan2Helper(-1, Math.LPIQuad * 3),
            new LutAtan2Helper(-1, -Math.LPIQuad * 3),
            new LutAtan2Helper(1, -Math.LPIQuad * 3),
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
            if (ydx >= LUTAtan2.MaxQueryIdx) return Math.LPIHalf;
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
            return new LFloat(true, _Atan2(y, x));
        }

        public static LFloat Acos(LFloat val)
        {
            int idx = (int)(val._val * LUTAcos.HALF_COUNT / LFloat.Precision) +
                      LUTAcos.HALF_COUNT;
            idx = Clamp(idx, 0, LUTAcos.COUNT);
            return new LFloat(true, LUTAcos.table[idx]);
        }

        public static LFloat Asin(LFloat val)
        {
            int idx = (int)(val._val * LUTAsin.HALF_COUNT / LFloat.Precision) +
                      LUTAsin.HALF_COUNT;
            idx = Clamp(idx, 0, LUTAsin.COUNT);
            return new LFloat(true, LUTAsin.table[idx]);
        }

        //ccw
        public static LFloat Sin(LFloat radians)
        {
            return new LFloat(true, LUTSin.table[_GetIdx(radians)]);
        }

        //ccw
        public static LFloat Cos(LFloat radians)
        {
            return new LFloat(true, LUTCos.table[_GetIdx(radians)]);
        }

        private static int _GetIdx(LFloat radians)
        {
            var rawVal = radians._val % Math.LPI2;
            if (rawVal < 0) rawVal += Math.LPI2;
            var val = new LFloat(true, rawVal) / Math.PI2;
            var idx = (int)(val * LUTCos.COUNT);
            idx = Clamp(idx, 0, LUTCos.COUNT);
            return idx;
        }

        //ccw
        public static void SinCos(out LFloat s, out LFloat c, LFloat radians)
        {
            int idx = _GetIdx(radians);
            s = new LFloat(true, LUTSin.table[idx]);
            c = new LFloat(true, LUTCos.table[idx]);
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

            return (int)Math.Sqrt32((uint)a);
        }

        public static long Sqrt(long a)
        {
            if (a <= 0L)
            {
                return 0;
            }

            if (a <= (long)(0xffffffffu))
            {
                return (long)Math.Sqrt32((uint)a);
            }

            return (long)Math.Sqrt64((ulong)a);
        }

        public static LFloat Sqrt(LFloat a)
        {
            if (a._val <= 0)
            {
                return LFloat.zero;
            }

            return new LFloat(true, Sqrt((long)a._val * LFloat.Precision));
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
                return new LFloat(true, -val._val);
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
                    return new LFloat(true, val._val + remainder - LFloat.Precision);
                }
                else
                {
                    return new LFloat(true, val._val + remainder);
                }
            }
            else
            {
                var remainder = (val._val) % LFloat.Precision;
                if (remainder > LFloat.HalfPrecision)
                {
                    return new LFloat(true, val._val - remainder + LFloat.Precision);
                }
                else
                {
                    return new LFloat(true, val._val - remainder);
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

        public static LFloat ToLFloat(this float a)
        {
            return new LFloat(true, (long)(a * LFloat.Precision));
        }
        public static LFloat ToLFloat(this int a)
        {
            return new LFloat(true, (long)(a * LFloat.Precision));
        }
        public static LFloat ToLFloat(this long a)
        {
            return new LFloat(true, (long)(a * LFloat.Precision));
        }

        public static LFloat Min(LFloat a, LFloat b)
        {
            return new LFloat(true, Min(a._val, b._val));
        }

        public static LFloat Max(LFloat a, LFloat b)
        {
            return new LFloat(true, Max(a._val, b._val));
        }

        public static LFloat Lerp(LFloat a, LFloat b, LFloat f)
        {
            return new LFloat(true, (int)(((long)(b._val - a._val) * f._val) / LFloat.Precision) + a._val);
        }

        public static LFloat InverseLerp(LFloat a, LFloat b, LFloat value)
        {
            if (a != b)
                return Clamp01(((value - a) / (b - a)));
            return LFloat.zero;
        }
        public static LVector2 Lerp(LVector2 a, LVector2 b, LFloat f)
        {
            return new LVector2(true,
                (int)(((long)(b._x - a._x) * f._val) / LFloat.Precision) + a._x,
                (int)(((long)(b._y - a._y) * f._val) / LFloat.Precision) + a._y);
        }

        public static LVector3 Lerp(LVector3 a, LVector3 b, LFloat f)
        {
            return new LVector3(true,
                (int)(((long)(b._x - a._x) * f._val) / LFloat.Precision) + a._x,
                (int)(((long)(b._y - a._y) * f._val) / LFloat.Precision) + a._y,
                (int)(((long)(b._z - a._z) * f._val) / LFloat.Precision) + a._z);
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

        public static LFloat Dot(LVector2 u, LVector2 v)
        {
            return new LFloat(true, ((long)u._x * v._x + (long)u._y * v._y) / LFloat.Precision);
        }

        public static LFloat Dot(LVector3 lhs, LVector3 rhs)
        {
            var val = ((long)lhs._x) * rhs._x + ((long)lhs._y) * rhs._y + ((long)lhs._z) * rhs._z;
            return new LFloat(true, val / LFloat.Precision);
            ;
        }
        public static LVector3 Cross(LVector3 lhs, LVector3 rhs)
        {
            return new LVector3(true,
                ((long)lhs._y * rhs._z - (long)lhs._z * rhs._y) / LFloat.Precision,
                ((long)lhs._z * rhs._x - (long)lhs._x * rhs._z) / LFloat.Precision,
                ((long)lhs._x * rhs._y - (long)lhs._y * rhs._x) / LFloat.Precision
            );
        }

        public static LFloat Cross2D(LVector2 u, LVector2 v)
        {
            return new LFloat(true, ((long)u._x * v._y - (long)u._y * v._x) / LFloat.Precision);
        }
        public static LFloat Dot2D(LVector2 u, LVector2 v)
        {
            return new LFloat(true, ((long)u._x * v._x + (long)u._y * v._y) / LFloat.Precision);
        }

        public static LVector3 Transform(ref LVector3 point, ref LVector3 axis_x, ref LVector3 axis_y, ref LVector3 axis_z,
           ref LVector3 trans)
        {
            return new LVector3(true,
                ((axis_x._x * point._x + axis_y._x * point._y + axis_z._x * point._z) / LFloat.Precision) + trans._x,
                ((axis_x._y * point._x + axis_y._y * point._y + axis_z._y * point._z) / LFloat.Precision) + trans._y,
                ((axis_x._z * point._x + axis_y._z * point._y + axis_z._z * point._z) / LFloat.Precision) + trans._z);
        }

        public static LVector3 Transform(LVector3 point, ref LVector3 axis_x, ref LVector3 axis_y, ref LVector3 axis_z,
            ref LVector3 trans)
        {
            return new LVector3(true,
                ((axis_x._x * point._x + axis_y._x * point._y + axis_z._x * point._z) / LFloat.Precision) + trans._x,
                ((axis_x._y * point._x + axis_y._y * point._y + axis_z._y * point._z) / LFloat.Precision) + trans._y,
                ((axis_x._z * point._x + axis_y._z * point._y + axis_z._z * point._z) / LFloat.Precision) + trans._z);
        }

        public static LVector3 Transform(ref LVector3 point, ref LVector3 axis_x, ref LVector3 axis_y, ref LVector3 axis_z,
            ref LVector3 trans, ref LVector3 scale)
        {
            long num = (long)point._x * (long)scale._x / LFloat.Precision;
            long num2 = (long)point._y * (long)scale._x / LFloat.Precision;
            long num3 = (long)point._z * (long)scale._x / LFloat.Precision;
            return new LVector3(true,
                (int)(((long)axis_x._x * num + (long)axis_y._x * num2 + (long)axis_z._x * num3) / LFloat.Precision) +
                trans._x,
                (int)(((long)axis_x._y * num + (long)axis_y._y * num2 + (long)axis_z._y * num3) / LFloat.Precision) +
                trans._y,
                (int)(((long)axis_x._z * num + (long)axis_y._z * num2 + (long)axis_z._z * num3) / LFloat.Precision) +
                trans._z);
        }

        public static LVector3 Transform(ref LVector3 point, ref LVector3 forward, ref LVector3 trans)
        {
            LVector3 up = LVector3.up;
            LVector3 vInt = Cross(LVector3.up, forward);
            return Math.Transform(ref point, ref vInt, ref up, ref forward, ref trans);
        }

        public static LVector3 Transform(LVector3 point, LVector3 forward, LVector3 trans)
        {
            LVector3 up = LVector3.up;
            LVector3 vInt = Cross(LVector3.up, forward);
            return Math.Transform(ref point, ref vInt, ref up, ref forward, ref trans);
        }

        public static LVector3 Transform(LVector3 point, LVector3 forward, LVector3 trans, LVector3 scale)
        {
            LVector3 up = LVector3.up;
            LVector3 vInt = Cross(LVector3.up, forward);
            return Math.Transform(ref point, ref vInt, ref up, ref forward, ref trans, ref scale);
        }

        public static LVector3 MoveTowards(LVector3 from, LVector3 to, LFloat dt)
        {
            if ((to - from).sqrMagnitude <= (dt * dt))
            {
                return to;
            }

            return from + (to - from).Normalize(dt);
        }


        public static LFloat AngleInt(LVector3 lhs, LVector3 rhs)
        {
            return Math.Acos(Dot(lhs, rhs));
        }
#if UNITY_5_3_OR_NEWER

        public static LVector2 ToLVector2(this Vector2Int vec)
        {
            return new LVector2(true, vec.x * LFloat.Precision, vec.y * LFloat.Precision);
        }

        public static LVector3 ToLVector3(this Vector3Int vec)
        {
            return new LVector3(true, vec.x * LFloat.Precision, vec.y * LFloat.Precision, vec.z * LFloat.Precision);
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
                Math.ToLFloat(vec.x),
                Math.ToLFloat(vec.y));
        }

        public static LVector3 ToLVector3(this Vector3 vec)
        {
            return new LVector3(
                Math.ToLFloat(vec.x),
                Math.ToLFloat(vec.y),
                Math.ToLFloat(vec.z));
        }
        public static LVector2 ToLVector2XZ(this Vector3 vec)
        {
            return new LVector2(
                Math.ToLFloat(vec.x),
                Math.ToLFloat(vec.z));
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

        public static LVector2 ToLVector2(this LVector2Int vec)
        {
            return new LVector2(true, vec.x * LFloat.Precision, vec.y * LFloat.Precision);
        }

        public static LVector3 ToLVector3(this LVector3Int vec)
        {
            return new LVector3(true, vec.x * LFloat.Precision, vec.y * LFloat.Precision, vec.z * LFloat.Precision);
        }

        public static LVector2Int ToLVector2Int(this LVector2 vec)
        {
            return new LVector2Int(vec.x.ToInt(), vec.y.ToInt());
        }

        public static LVector3Int ToLVector3Int(this LVector3 vec)
        {
            return new LVector3Int(vec.x.ToInt(), vec.y.ToInt(), vec.z.ToInt());
        }

        public static LVector2Int Floor(this LVector2 vec)
        {
            return new LVector2Int(Math.FloorToInt(vec.x), Math.FloorToInt(vec.y));
        }

        public static LVector3Int Floor(this LVector3 vec)
        {
            return new LVector3Int(
                Math.FloorToInt(vec.x),
                Math.FloorToInt(vec.y),
                Math.FloorToInt(vec.z)
            );
        }
        public static LVector2 RightVec(this LVector2 vec)
        {
            return new LVector2(true, vec._y, -vec._x);
        }

        public static LVector2 LeftVec(this LVector2 vec)
        {
            return new LVector2(true, -vec._y, vec._x);
        }

        public static LVector2 BackVec(this LVector2 vec)
        {
            return new LVector2(true, -vec._x, -vec._y);
        }

    }
}