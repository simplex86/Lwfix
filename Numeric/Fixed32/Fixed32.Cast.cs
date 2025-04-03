namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 类型转换
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fixed32 FromRaw(long value)
        {
            return new Fixed32() { rawvalue = value };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToRaw(Fixed32 value)
        {
            return value.rawvalue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static long Int32ToRaw(int value)
        {
            return Math.Clamp((long)value << INTEGRAL_BITS, MIN_RAW_VALUE, MAX_RAW_VALUE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static long DoubleToRaw(double value)
        {
            return Math.Clamp((long)(value * FRACTIONAL_MULTIPLIER + 0.5), MIN_RAW_VALUE, MAX_RAW_VALUE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator byte(Fixed32 n) => n.ToByte();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator short(Fixed32 n) => n.ToShort();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator int(Fixed32 n) => n.ToInt();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator long(Fixed32 n) => n.ToLong();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator float(Fixed32 n) => n.ToFloat();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator double(Fixed32 n) => n.ToDouble();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static implicit operator Fixed32(byte n) => new Fixed32(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static implicit operator Fixed32(short n) => new Fixed32(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static implicit operator Fixed32(int n) => new Fixed32(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator Fixed32(long n) => new Fixed32(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator Fixed32(float n) => new Fixed32(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator Fixed32(double n) => new Fixed32(n);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte ToByte()
        {
            return IsNaN() ? (byte)0 : (byte)ToLong();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public short ToShort()
        {
            return IsNaN() ? (short)0 : (short)ToLong();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ToInt()
        {
            return IsNaN() ? 0 : (int)ToLong();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long ToLong()
        {
            if (IsNaN()) return 0L;
            return rawvalue >> FRACTIONAL_BITS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float ToFloat()
        {
            if (IsNaN()) return float.NaN;
            return (float)ToDouble();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double ToDouble()
        {
            if (IsNaN()) return double.NaN;
            if (IsPositiveInfinity()) return double.PositiveInfinity;
            if (IsNegativeInfinity()) return double.NegativeInfinity;

            return rawvalue / FRACTIONAL_MULTIPLIER;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (IsNaN()) return "NaN";
            if (IsPositiveInfinity()) return "+∞";
            if (IsNegativeInfinity()) return "-∞";

            return IsFractional() ? ToDouble().ToString()
                                  : ToLong().ToString();
        }

        /// <summary>
        /// 获取整数部分
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Fixed32 Integral()
        {
            if (IsNaN()) return NaN;
            return FromRaw(rawvalue & INTEGRAL_MASK);
        }

        /// <summary>
        /// 获取整数部分
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Integral(Fixed32 n)
        {
            return n.Integral();
        }

        /// <summary>
        /// 获取小数部分
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Fixed32 Fractional()
        {
            if (IsNaN()) return NaN;
            return FromRaw(rawvalue & FRACTIONAL_MASK);
        }

        /// <summary>
        /// 获取小数部分
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Fractional(Fixed32 n)
        {
            return n.Fractional();
        }
    }
}
