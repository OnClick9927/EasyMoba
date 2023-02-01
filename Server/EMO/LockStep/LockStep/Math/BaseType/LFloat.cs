

using System;
using System.Runtime.CompilerServices;

namespace LockStep.Math
{
    [Serializable]
    public struct LFloat : IEquatable<LFloat>, IComparable<LFloat>
    {
        public const long Precision = 1000000;
        public const long RateOfOldPrecision = Precision / 1000;
        public const long HalfPrecision = Precision / 2;
        public const float PrecisionFactor = 0.000001f;

        public long _val;

        public static readonly LFloat zero = LFloat.CreateByRaw(0L);
        public static readonly LFloat one = LFloat.CreateByRaw(LFloat.Precision);
        public static readonly LFloat negOne = LFloat.CreateByRaw(-LFloat.Precision);
        public static readonly LFloat half = LFloat.CreateByRaw(LFloat.Precision / 2L);
        public static readonly LFloat FLT_MAX = LFloat.CreateByRaw(long.MaxValue);
        public static readonly LFloat FLT_MIN = LFloat.CreateByRaw(long.MinValue);
        public static readonly LFloat EPSILON = LFloat.CreateByRaw(1L);
        public static readonly LFloat INTERVAL_EPSI_LON = LFloat.CreateByRaw(1L);

        public static readonly LFloat MaxValue = LFloat.CreateByRaw(long.MaxValue);
        public static readonly LFloat MinValue = LFloat.CreateByRaw(long.MinValue);

        public static LFloat CreateByRaw(long rawVal)
        {
            return new LFloat(rawVal)
            {
                _val = rawVal
            };
        }
        public LFloat(int val) => this._val = val * LFloat.Precision;
        public LFloat(long val) => this._val = val * LFloat.Precision;

        public LFloat(float val) => this._val = (long)(val * LFloat.Precision);
        public int ToInt() => (int)(_val / LFloat.Precision);

        public long ToLong() => _val / LFloat.Precision;

        public float ToFloat() => _val * LFloat.PrecisionFactor;

        public double ToDouble() => _val * LFloat.PrecisionFactor;

        public int Floor()
        {
            var x = this._val;
            if (x > 0)
            {
                x /= LFloat.Precision;
            }
            else
            {
                if (x % LFloat.Precision == 0)
                {
                    x /= LFloat.Precision;
                }
                else
                {
                    x = x / LFloat.Precision - 1;
                }
            }

            return (int)x;
        }

        public int Ceil()
        {
            var x = this._val;
            if (x < 0)
            {
                x /= LFloat.Precision;
            }
            else
            {
                if (x % LFloat.Precision == 0)
                {
                    x /= LFloat.Precision;
                }
                else
                {
                    x = x / LFloat.Precision + 1;
                }
            }

            return (int)x;
        }
        public override bool Equals(object obj) => obj is LFloat && ((LFloat)obj)._val == _val;
        public bool Equals(LFloat other) => _val == other._val;
        public int CompareTo(LFloat other) => _val.CompareTo(other._val);
        public override int GetHashCode() => (int)_val;
        public override string ToString() => (_val * LFloat.PrecisionFactor).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(LFloat a, LFloat b) => a._val < b._val;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(LFloat a, LFloat b) => a._val > b._val;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(LFloat a, LFloat b) => a._val <= b._val;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(LFloat a, LFloat b) => a._val >= b._val;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(LFloat a, LFloat b) => a._val == b._val;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(LFloat a, LFloat b) => a._val != b._val;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static LFloat operator +(LFloat a, LFloat b) => LFloat.CreateByRaw(a._val + b._val);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static LFloat operator -(LFloat a, LFloat b) => LFloat.CreateByRaw(a._val - b._val);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static LFloat operator *(LFloat a, LFloat b) => LFloat.CreateByRaw((long)(a._val) * b._val / LFloat.Precision);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static LFloat operator /(LFloat a, LFloat b) => LFloat.CreateByRaw((long)(a._val * LFloat.Precision) / b._val);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static LFloat operator -(LFloat a) => LFloat.CreateByRaw(-a._val);
        public static LFloat operator +(LFloat a, int b) => LFloat.CreateByRaw(a._val + b * Precision);
        public static LFloat operator -(LFloat a, int b) => LFloat.CreateByRaw(a._val - b * Precision);
        public static LFloat operator *(LFloat a, int b) => LFloat.CreateByRaw((a._val * b));
        public static LFloat operator /(LFloat a, int b) => LFloat.CreateByRaw((a._val) / b);
        public static LFloat operator +(int a, LFloat b) => LFloat.CreateByRaw(b._val + a * Precision);
        public static LFloat operator -(int a, LFloat b) => LFloat.CreateByRaw(a * Precision - b._val);
        public static LFloat operator *(int a, LFloat b) => LFloat.CreateByRaw((b._val * a));
        public static LFloat operator /(int a, LFloat b) => LFloat.CreateByRaw(((long)(a * Precision * Precision) / b._val));
        public static bool operator <(LFloat a, int b) => a._val < (b * Precision);
        public static bool operator >(LFloat a, int b) => a._val > (b * Precision);
        public static bool operator <=(LFloat a, int b) => a._val <= (b * Precision);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(LFloat a, int b) => a._val >= (b * Precision);
        public static bool operator ==(LFloat a, int b) => a._val == (b * Precision);
        public static bool operator !=(LFloat a, int b) => a._val != (b * Precision);
        public static bool operator <(int a, LFloat b) => (a * Precision) < (b._val);
        public static bool operator >(int a, LFloat b) => (a * Precision) > (b._val);
        public static bool operator <=(int a, LFloat b) => (a * Precision) <= (b._val);
        public static bool operator >=(int a, LFloat b) => (a * Precision) >= (b._val);
        public static bool operator ==(int a, LFloat b) => (a * Precision) == (b._val);
        public static bool operator !=(int a, LFloat b) => (a * Precision) != (b._val);
        public static LFloat operator +(LFloat a, long b) => LFloat.CreateByRaw(a._val + b * Precision);
        public static LFloat operator -(LFloat a, long b) => LFloat.CreateByRaw(a._val - b * Precision);
        public static LFloat operator *(LFloat a, long b) => LFloat.CreateByRaw((a._val * b));
        public static LFloat operator /(LFloat a, long b) => LFloat.CreateByRaw((a._val) / b);
        public static LFloat operator +(long a, LFloat b) => LFloat.CreateByRaw(b._val + a * Precision);
        public static LFloat operator -(long a, LFloat b) => LFloat.CreateByRaw(a * Precision - b._val);
        public static LFloat operator *(long a, LFloat b) => LFloat.CreateByRaw((b._val * a));
        public static LFloat operator /(long a, LFloat b) => LFloat.CreateByRaw(((long)(a * Precision * Precision) / b._val));
        public static bool operator <(LFloat a, long b) => a._val < (b * Precision);
        public static bool operator >(LFloat a, long b) => a._val > (b * Precision);
        public static bool operator <=(LFloat a, long b) => a._val <= (b * Precision);
        public static bool operator >=(LFloat a, long b) => a._val >= (b * Precision);
        public static bool operator ==(LFloat a, long b) => a._val == (b * Precision);
        public static bool operator !=(LFloat a, long b) => a._val != (b * Precision);
        public static bool operator <(long a, LFloat b) => (a * Precision) < (b._val);
        public static bool operator >(long a, LFloat b) => (a * Precision) > (b._val);
        public static bool operator <=(long a, LFloat b) => (a * Precision) <= (b._val);
        public static bool operator >=(long a, LFloat b) => (a * Precision) >= (b._val);
        public static bool operator ==(long a, LFloat b) => (a * Precision) == (b._val);
        public static bool operator !=(long a, LFloat b) => (a * Precision) != (b._val);
        public static implicit operator LFloat(short value) => LFloat.CreateByRaw(value * Precision);
        public static explicit operator short(LFloat value) => (short)(value._val / Precision);
        public static implicit operator LFloat(int value) => LFloat.CreateByRaw(value * Precision);
        public static implicit operator int(LFloat value) => (int)(value._val / Precision);
        public static explicit operator LFloat(long value) => LFloat.CreateByRaw(value * Precision);
        public static implicit operator long(LFloat value) => value._val / Precision;
        public static explicit operator LFloat(float value) => LFloat.CreateByRaw((long)(value * Precision));
        public static explicit operator float(LFloat value) => (float)value._val * LFloat.PrecisionFactor;
        public static explicit operator LFloat(double value) => LFloat.CreateByRaw((long)(value * Precision));
        public static explicit operator double(LFloat value) => (double)value._val * LFloat.PrecisionFactor;


    }
}