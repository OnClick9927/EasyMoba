

using System;
using System.Runtime.CompilerServices;
#if UNITY_5_3_OR_NEWER 
using UnityEngine;
#endif

namespace LockStep.Math
{
    [Serializable]
    public struct LVector3 : IEquatable<LVector3>
    {
        public LFloat x
        {
            get { return LFloat.CreateByRaw(_x); }
            set { _x = value._val; }
        }

        public LFloat y
        {
            get { return LFloat.CreateByRaw(_y); }
            set { _y = value._val; }
        }

        public LFloat z
        {
            get { return LFloat.CreateByRaw(_z); }
            set { _z = value._val; }
        }

        public long _x;
        public long _y;
        public long _z;


        public static readonly LVector3 zero = LVector3.CreateByRaw(0, 0, 0);
        public static readonly LVector3 one = LVector3.CreateByRaw(LFloat.Precision, LFloat.Precision, LFloat.Precision);
        public static readonly LVector3 half = LVector3.CreateByRaw(LFloat.Precision / 2, LFloat.Precision / 2, LFloat.Precision / 2);

        public static readonly LVector3 forward = LVector3.CreateByRaw(0, 0, LFloat.Precision);
        public static readonly LVector3 up = LVector3.CreateByRaw(0, LFloat.Precision, 0);
        public static readonly LVector3 right = LVector3.CreateByRaw(LFloat.Precision, 0, 0);
        public static readonly LVector3 back = LVector3.CreateByRaw(0, 0, -LFloat.Precision);
        public static readonly LVector3 down = LVector3.CreateByRaw(0, -LFloat.Precision, 0);
        public static readonly LVector3 left = LVector3.CreateByRaw(-LFloat.Precision, 0, 0);

        public static LVector3 CreateByRaw(long _x, long _y, long _z)
        {
            return new LVector3() { _x = _x, _y = _y, _z = _z };
        }


        public LVector3(long _x, long _y, long _z)
        {
            this._x = _x * LFloat.Precision;
            this._y = _y * LFloat.Precision;
            this._z = _z * LFloat.Precision;
        }
        public LVector3(LFloat x, LFloat y, LFloat z)
        {
            this._x = x._val;
            this._y = y._val;
            this._z = z._val;
        }


        public LFloat magnitude
        {
            get
            {
                return LFloat.CreateByRaw(LMath.Sqrt(_x * _x + _y * _y + _z * _z));
            }
        }


        public LFloat sqrMagnitude
        {
            get
            {
                return LFloat.CreateByRaw((_x * _x + _y * _y + _z * _z) / LFloat.Precision);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long RawSqrMagnitude() => (_x * _x + _y * _y + _z * _z);

        public LVector3 abs
        {
            get { return LVector3.CreateByRaw(LMath.Abs(this._x), LMath.Abs(this._y), LMath.Abs(this._z)); }
        }

        public LVector3 Normalize()
        {
            return Normalize((LFloat)1);
        }

        public LVector3 Normalize(LFloat newMagn)
        {
            long sqr = _x * _x + _y * _y + _z * _z;
            if (sqr == 0L)
            {
                return LVector3.zero;
            }
            long b = LMath.Sqrt(sqr);
            _x = (_x * LFloat.Precision / b);
            _y = (_y * LFloat.Precision / b);
            _z = (_z * LFloat.Precision / b);
            return this;
        }

        public LVector3 normalized
        {
            get
            {
                long sqr = _x * _x + _y * _y + _z * _z;
                if (sqr == 0L)
                {
                    return LVector3.zero;
                }

                var ret = new LVector3();
                long b = LMath.Sqrt(sqr);
                ret._x = (_x * LFloat.Precision / b);
                ret._y = (_y * LFloat.Precision / b);
                ret._z = (_z * LFloat.Precision / b);
                return ret;
            }
        }

        public static bool operator ==(LVector3 lhs, LVector3 rhs)
        {
            return lhs._x == rhs._x && lhs._y == rhs._y && lhs._z == rhs._z;
        }

        public static bool operator !=(LVector3 lhs, LVector3 rhs)
        {
            return lhs._x != rhs._x || lhs._y != rhs._y || lhs._z != rhs._z;
        }

        public static LVector3 operator -(LVector3 lhs, LVector3 rhs)
        {
            lhs._x -= rhs._x;
            lhs._y -= rhs._y;
            lhs._z -= rhs._z;
            return lhs;
        }

        public static LVector3 operator -(LVector3 lhs)
        {
            lhs._x = -lhs._x;
            lhs._y = -lhs._y;
            lhs._z = -lhs._z;
            return lhs;
        }

        public static LVector3 operator +(LVector3 lhs, LVector3 rhs)
        {
            lhs._x += rhs._x;
            lhs._y += rhs._y;
            lhs._z += rhs._z;
            return lhs;
        }

        public static LVector3 operator *(LVector3 lhs, LVector3 rhs)
        {
            lhs._x = (int)(((long)(lhs._x * rhs._x)) / LFloat.Precision);
            lhs._y = (int)(((long)(lhs._y * rhs._y)) / LFloat.Precision);
            lhs._z = (int)(((long)(lhs._z * rhs._z)) / LFloat.Precision);
            return lhs;
        }

        public static LVector3 operator *(LVector3 lhs, LFloat rhs)
        {
            lhs._x = (int)(((long)(lhs._x * rhs._val)) / LFloat.Precision);
            lhs._y = (int)(((long)(lhs._y * rhs._val)) / LFloat.Precision);
            lhs._z = (int)(((long)(lhs._z * rhs._val)) / LFloat.Precision);
            return lhs;
        }

        public static LVector3 operator /(LVector3 lhs, LFloat rhs)
        {
            lhs._x = (int)(((long)lhs._x * LFloat.Precision) / rhs._val);
            lhs._y = (int)(((long)lhs._y * LFloat.Precision) / rhs._val);
            lhs._z = (int)(((long)lhs._z * LFloat.Precision) / rhs._val);
            return lhs;
        }

        public static LVector3 operator *(LFloat rhs, LVector3 lhs)
        {
            lhs._x = (int)(((long)(lhs._x * rhs._val)) / LFloat.Precision);
            lhs._y = (int)(((long)(lhs._y * rhs._val)) / LFloat.Precision);
            lhs._z = (int)(((long)(lhs._z * rhs._val)) / LFloat.Precision);
            return lhs;
        }

        public override string ToString()
        {
            return string.Format("({0},{1},{2})", _x * LFloat.PrecisionFactor, _y * LFloat.PrecisionFactor,
                _z * LFloat.PrecisionFactor);
        }

        public override bool Equals(object o)
        {
            if (o == null)
            {
                return false;
            }

            LVector3 other = (LVector3)o;
            return this._x == other._x && this._y == other._y && this._z == other._z;
        }


        public bool Equals(LVector3 other)
        {
            return this._x == other._x && this._y == other._y && this._z == other._z;
        }


        public override int GetHashCode()
        {
            return (int)(this._x * 73856093 ^ this._y * 19349663 ^ this._z * 83492791);
        }

        public static LFloat AngleInt(LVector3 lhs, LVector3 rhs)
        {
            return LMath.Acos(Dot(lhs, rhs));
        }
        public LFloat this[int index]

        {

            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: throw new IndexOutOfRangeException("vector idx invalid" + index);
                }
            }

            set
            {
                switch (index)
                {
                    case 0: _x = value._val; break;
                    case 1: _y = value._val; break;
                    case 2: _z = value._val; break;
                    default: throw new IndexOutOfRangeException("vector idx invalid" + index);
                }
            }

        }

        public static LFloat Dot(ref LVector3 lhs, ref LVector3 rhs)
        {
            var val = ((long)lhs._x) * rhs._x + ((long)lhs._y) * rhs._y + ((long)lhs._z) * rhs._z;
            return LFloat.CreateByRaw(val / LFloat.Precision);
        }

        public static LFloat Dot(LVector3 lhs, LVector3 rhs)
        {
            var val = ((long)lhs._x) * rhs._x + ((long)lhs._y) * rhs._y + ((long)lhs._z) * rhs._z;
            return LFloat.CreateByRaw(val / LFloat.Precision);
            ;
        }


        public static LVector3 Cross(ref LVector3 lhs, ref LVector3 rhs)
        {
            return LVector3.CreateByRaw(
                ((long)lhs._y * rhs._z - (long)lhs._z * rhs._y) / LFloat.Precision,
                ((long)lhs._z * rhs._x - (long)lhs._x * rhs._z) / LFloat.Precision,
                ((long)lhs._x * rhs._y - (long)lhs._y * rhs._x) / LFloat.Precision
            );
        }

        public static LVector3 Cross(LVector3 lhs, LVector3 rhs)
        {
            return LVector3.CreateByRaw(
                ((long)lhs._y * rhs._z - (long)lhs._z * rhs._y) / LFloat.Precision,
                ((long)lhs._z * rhs._x - (long)lhs._x * rhs._z) / LFloat.Precision,
                ((long)lhs._x * rhs._y - (long)lhs._y * rhs._x) / LFloat.Precision
            );
        }


        public static LVector3 Lerp(LVector3 a, LVector3 b, LFloat f)
        {
            return LVector3.CreateByRaw(
                (int)(((long)(b._x - a._x) * f._val) / LFloat.Precision) + a._x,
                (int)(((long)(b._y - a._y) * f._val) / LFloat.Precision) + a._y,
                (int)(((long)(b._z - a._z) * f._val) / LFloat.Precision) + a._z);
        }
        public static LVector3 Transform(ref LVector3 point, ref LVector3 axis_x, ref LVector3 axis_y, ref LVector3 axis_z,
         ref LVector3 trans)
        {
            return LVector3.CreateByRaw(
                ((axis_x._x * point._x + axis_y._x * point._y + axis_z._x * point._z) / LFloat.Precision) + trans._x,
                ((axis_x._y * point._x + axis_y._y * point._y + axis_z._y * point._z) / LFloat.Precision) + trans._y,
                ((axis_x._z * point._x + axis_y._z * point._y + axis_z._z * point._z) / LFloat.Precision) + trans._z);
        }

        public static LVector3 Transform(LVector3 point, ref LVector3 axis_x, ref LVector3 axis_y, ref LVector3 axis_z,
            ref LVector3 trans)
        {
            return LVector3.CreateByRaw(
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
            return LVector3.CreateByRaw(
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
            LVector3 vInt = LVector3.Cross(LVector3.up, forward);
            return Transform(ref point, ref vInt, ref up, ref forward, ref trans);
        }

        public static LVector3 Transform(LVector3 point, LVector3 forward, LVector3 trans)
        {
            LVector3 up = LVector3.up;
            LVector3 vInt = LVector3.Cross(LVector3.up, forward);
            return LVector3.Transform(ref point, ref vInt, ref up, ref forward, ref trans);
        }

        public static LVector3 Transform(LVector3 point, LVector3 forward, LVector3 trans, LVector3 scale)
        {
            LVector3 up = LVector3.up;
            LVector3 vInt = LVector3.Cross(LVector3.up, forward);
            return LVector3.Transform(ref point, ref vInt, ref up, ref forward, ref trans, ref scale);
        }

        public static LVector3 MoveTowards(LVector3 from, LVector3 to, LFloat dt)
        {
            if ((to - from).sqrMagnitude <= (dt * dt))
            {
                return to;
            }

            return from + (to - from).Normalize(dt);
        }
        public LVector3Int ToLVector3Int()
        {
            return new LVector3Int(this.x.ToInt(), this.y.ToInt(), this.z.ToInt());
        }


        public LVector3Int Floor()
        {
            return new LVector3Int(
                LMath.FloorToInt(this.x),
                LMath.FloorToInt(this.y),
                LMath.FloorToInt(this.z)
            );
        }
    }
}