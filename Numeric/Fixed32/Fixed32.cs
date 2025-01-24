namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 
        /// </summary>
        internal long value = 0;

        /// <summary>
        /// 总位宽
        /// </summary>
        internal const byte TOTAL_BITS = sizeof(long) * 8;
        /// <summary>
        /// 整数部分占用的位宽
        /// </summary>
        internal const byte INTEGRAL_BITS = TOTAL_BITS / 2;
        /// <summary>
        /// 小数部分占用的位宽
        /// </summary>
        internal const byte FRACTIONAL_BITS = TOTAL_BITS - INTEGRAL_BITS;
        /// <summary>
        /// 小数精度
        /// </summary>
        internal const double FRACTIONAL_MULTIPLIER = uint.MaxValue + 1.0;

        /// <summary>
        /// 所有位的掩码
        /// </summary>
        internal const ulong FULL_BIT_MASK = 0xFFFFFFFFFFFFFFFF;
        /// <summary>
        /// 符号位的掩码
        /// </summary>
        internal const long SIGN_BIT_MASK = unchecked((long)0x8000000000000000L);
        /// <summary>
        /// 整数部分的掩码
        /// </summary>
        internal const long INTEGRAL_MASK = FRACTIONAL_MASK << INTEGRAL_BITS;
        /// <summary>
        /// 小数部分的掩码
        /// </summary>
        internal const long FRACTIONAL_MASK = (1L << FRACTIONAL_BITS) - 1L;

        /// <summary>
        /// 
        /// </summary>
        public Fixed32()
        {
            value = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed32(int value)
        {
            this.value = (long)value << FRACTIONAL_BITS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed32(float value)
            : this((double)value)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed32(double value)
        {
            this.value = (long)(value * FRACTIONAL_MULTIPLIER);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public Fixed32(Fixed32 other)
        {
            this.value = other.value;
        }

        /// <summary>
        /// 最大值
        /// </summary>
        public static Fixed32 MaxValue => From(long.MaxValue); // 0x7FFFFFFFFFFFFFFF
        /// <summary>
        /// 最小值
        /// </summary>
        public static Fixed32 MinValue => From(long.MinValue + 1); // 0x8000000000000001
        /// <summary>
        /// 
        /// </summary>
        public readonly static Fixed32 AdditiveIdentity = new Fixed32(0);
        /// <summary>
        /// 
        /// </summary>
        public readonly static Fixed32 MultiplicativeIdentity = new Fixed32(1);
        /// <summary>
        /// 0
        /// </summary>
        public readonly static Fixed32 Zero = new Fixed32(0);
        /// <summary>
        /// 1
        /// </summary>
        public readonly static Fixed32 One = new Fixed32(1);
        /// <summary>
        /// -1
        /// </summary>
        public readonly static Fixed32 NegativeOne = new Fixed32(-1);
        /// <summary>
        /// 非数字
        /// </summary>
        public readonly static Fixed32 NaN = From(long.MinValue); // 0x8000000000000000
        /// <summary>
        /// 精度
        /// </summary>
        public readonly static Fixed32 Epsilon = From(1);

        /// <summary>
        /// 自然常数
        /// </summary>
        public readonly static Fixed32 E = new Fixed32(2.7182818284590452354);
        /// <summary>
        /// 圆周率
        /// </summary>
        public readonly static Fixed32 PI = new Fixed32(3.14159265358979323846);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}
