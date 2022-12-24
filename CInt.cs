namespace Circular
{//hello
    public struct CInt : IConvertible
    {
        private int Value { get; set; }

        private int Max = int.MaxValue;
        private int Min = int.MinValue;

        #region Constructors
        public CInt(int _Value)
        { Value = _Value; }

        public CInt(int _Max, int _Min)
        {
            Value = 0;
            if (_Min > _Max)
            { throw new ArgumentException("Max must be greater than min"); }
            else
            {
                Max = _Max;
                Min = _Min;
            }
        }

        public CInt(int _Value, int _Max, int _Min)
        {
            Value = _Value;

            if (_Min > _Max)
            { throw new ArgumentException("Max must be greater than min"); }
            else if (_Value > _Max || _Value < _Min)
            { throw new ArgumentOutOfRangeException("Value is not within max/min"); }
            else
            {
                Max = _Max;
                Min = _Min;
            }
        }
        #endregion

        #region CInt-CInt operator overloading
        public static CInt operator +(CInt a, CInt b)
        {
            if ((a.Value + b.Value) > a.Max)
            { a.Value = a.Min + Math.Abs(b.Value % a.Value); }
            else
            { a.Value += b.Value; }

            return a;
        }

        public static CInt operator -(CInt a, CInt b)
        {
            if ((a.Value - b.Value) < a.Min)
            { a.Value = a.Max - Math.Abs(a.Value % b.Value); }
            else
            { a.Value -= b.Value; }

            return a;
        }

        public static CInt operator *(CInt a, CInt b)
        {
            if ((a.Value * b.Value) > a.Max)
            { a.Value = a.Max % (a.Value * b.Value); }
            else if ((a.Value * b.Value) < a.Min)
            { a.Value = a.Min; }
            else
            { a.Value *= b.Value; }

            return a;
        }

        public static CInt operator /(CInt a, CInt b)
        { throw new NotImplementedException("Pls dont divide"); }

        public static bool operator >(CInt a, CInt b)
        {
            if (a.Value > b.Value)
            { return true; }

            return false;
        }

        public static bool operator >=(CInt a, CInt b)
        {
            if (a.Value >= b.Value)
            { return true; }

            return false;
        }

        public static bool operator <(CInt a, CInt b)
        {
            if (a.Value < b.Value)
            { return true; }

            return false;
        }

        public static bool operator <=(CInt a, CInt b)
        {
            if (a.Value <= b.Value)
            { return true; }

            return false;
        }
        #endregion

        #region CInt-int operator overloading
        public static CInt operator +(CInt a, int b)
        {
            if ((a.Value + b) > a.Max)
            { a.Value = a.Min + Math.Abs(b % a.Value); }
            else
            { a.Value += b; }

            return a;
        }

        public static CInt operator -(CInt a, int b)
        {
            if ((a.Value - b) < a.Min)
            { a.Value = a.Max - Math.Abs(a.Value % b); }
            else
            { a.Value -= b; }

            return a;
        }

        public static CInt operator *(CInt a, int b)
        {
            if ((a.Value * b) > a.Max)
            { a.Value = a.Max % (a.Value * b); }
            else if ((a.Value * b) < a.Min)
            { a.Value = a.Min; }
            else
            { a.Value *= b; }

            return a;
        }

        public static CInt operator /(CInt a, int b)
        { throw new NotImplementedException("Pls dont divide"); }

        public static bool operator >(CInt a, int b)
        {
            if (a.Value > b)
            { return true; }

            return false;
        }

        public static bool operator >=(CInt a, int b)
        {
            if (a.Value >= b)
            { return true; }

            return false;
        }

        public static bool operator <(CInt a, int b)
        {
            if (a.Value < b)
            { return true; }

            return false;
        }

        public static bool operator <=(CInt a, int b)
        {
            if (a.Value <= b)
            { return true; }

            return false;
        }
        #endregion

        public static CInt operator ++(CInt a)
        {
            a.Value++;

            if (a.Value > a.Max)
            { a.Value = a.Min; }

            return a;
        }

        public static CInt operator --(CInt a)
        {
            a.Value--;

            if (a.Value <= a.Min - 1)
            { a.Value = a.Max; }

            return a;
        }

        public override string ToString() => $"{Value}";

        #region IConvertible stuffs
        public TypeCode GetTypeCode()
        { throw new NotImplementedException(); }

        public bool ToBoolean(IFormatProvider? provider)
        { throw new NotImplementedException("Cannot convert to boolean"); }

        public byte ToByte(IFormatProvider? provider)
        { throw new NotImplementedException("Cannot convert to Byte"); }

        public char ToChar(IFormatProvider? provider)
        { return (Char)Value; }

        public DateTime ToDateTime(IFormatProvider? provider)
        { throw new NotImplementedException("Cannot convert to DateTime"); }

        public decimal ToDecimal(IFormatProvider? provider)
        { return (decimal)Value; }

        public double ToDouble(IFormatProvider? provider)
        { return (double)Value; }

        public short ToInt16(IFormatProvider? provider)
        { return (short)Value; }

        public int ToInt32(IFormatProvider? provider)
        { return Value; }

        public long ToInt64(IFormatProvider? provider)
        { return (Int64)Value; }

        public sbyte ToSByte(IFormatProvider? provider)
        { return (sbyte)Value; }

        public float ToSingle(IFormatProvider? provider)
        { return (Single)Value; }

        public string ToString(IFormatProvider? provider)
        { return Value.ToString(); }

        public object ToType(Type conversionType, IFormatProvider? provider)
        { throw new NotImplementedException("I genuinely don't know what this is suppose to do"); }

        public ushort ToUInt16(IFormatProvider? provider)
        { return (UInt16)Value; }

        public uint ToUInt32(IFormatProvider? provider)
        { return (UInt32)Value; }

        public ulong ToUInt64(IFormatProvider? provider)
        { return (UInt64)Value; }
        #endregion

        public void Set(int _NewValue)
        {
            if (_NewValue > Min && _NewValue < Max)
            { Value = _NewValue; }
            else
            { throw new ArgumentOutOfRangeException(nameof(_NewValue)); }
        }

        public static explicit operator int(CInt a)
        { return a.Value; }

        public static implicit operator CInt(int a)
        { return new CInt(a); }
    }
}