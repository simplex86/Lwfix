namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 取余
    /// </summary>
    public partial struct Fixed32
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator %(Fixed32 a, int b)
        {
            return Mod(a.value, (long)b << INTEGRAL_BITS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator %(int a, Fixed32 b)
        {
            return Mod((long)a << INTEGRAL_BITS, b.value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator %(Fixed32 a, Fixed32 b)
        {
            return Mod(a.value, b.value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static Fixed32 Mod(long a, long b)
        {
            if (a == NaN.value || 
                b == NaN.value)
            {
                return NaN;
            }

            // 整数部分
            var aint = a >> INTEGRAL_BITS;
            var bint = b >> INTEGRAL_BITS;
            // 小数部分
            var afrac = (a & FRACTIONAL_MASK);
            var bfrac = (b & FRACTIONAL_MASK);

            var mint = (aint % bint) << INTEGRAL_BITS;
            var mfrac = afrac % bfrac;

            return From(mint + mfrac);
        }
    }
}
