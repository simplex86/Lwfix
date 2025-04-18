namespace Lwfix
{
    /// <summary>
    /// 定点数
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 
        /// </summary>
        internal long rawvalue = 0;

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
        internal const long EPSILON_VALUE = 8L;

        /// <summary>
        /// 
        /// </summary>
        public Fixed32()
        {
            rawvalue = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed32(int value)
        {
            rawvalue = Int32ToRaw(value);// Math.Clamp((long)value << FRACTIONAL_BITS, MIN_RAW_VALUE, MAX_RAW_VALUE);
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
            rawvalue = DoubleToRaw(value);// Math.Clamp((long)(value * FRACTIONAL_MULTIPLIER + 0.5), MIN_RAW_VALUE, MAX_RAW_VALUE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public Fixed32(Fixed32 other)
        {
            rawvalue = other.rawvalue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return rawvalue.GetHashCode();
        }
    }
}
