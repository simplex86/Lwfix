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
        internal long rawvalue { get; private set; } = 0;

        /// <summary>
        /// 总位宽
        /// </summary>
        private const byte TOTAL_BITS = sizeof(long) * 8;
        /// <summary>
        /// 整数部分占用的位宽
        /// </summary>
        private const byte INTEGRAL_BITS = TOTAL_BITS / 2;
        /// <summary>
        /// 小数部分占用的位宽
        /// </summary>
        private const byte FRACTIONAL_BITS = TOTAL_BITS - INTEGRAL_BITS;
        /// <summary>
        /// 小数精度
        /// </summary>
        private const double FRACTIONAL_MULTIPLIER = uint.MaxValue + 1.0;

        /// <summary>
        /// 所有位的掩码
        /// </summary>
        private const ulong FULL_BIT_MASK = 0xFFFFFFFFFFFFFFFF;
        /// <summary>
        /// 符号位的掩码
        /// </summary>
        private const long SIGN_BIT_MASK = unchecked((long)0x8000000000000000L);
        /// <summary>
        /// 整数部分的掩码
        /// </summary>
        private const long INTEGRAL_MASK = FRACTIONAL_MASK << INTEGRAL_BITS;
        /// <summary>
        /// 小数部分的掩码
        /// </summary>
        private const long FRACTIONAL_MASK = (1L << FRACTIONAL_BITS) - 1L;

        /// <summary>
        /// 
        /// </summary>
        private const long EPSILON_VALUE = 8L;

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
            this.rawvalue = (long)value << FRACTIONAL_BITS;
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
            this.rawvalue = (long)(value * FRACTIONAL_MULTIPLIER);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public Fixed32(Fixed32 other)
        {
            this.rawvalue = other.rawvalue;
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
