namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 乘法
    /// </summary>
    public partial struct Fixed32
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator *(Fixed32 a, int b)
        {
            return Mul(a.rawvalue, (long)b << INTEGRAL_BITS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator *(int a, Fixed32 b)
        {
            return b * a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator *(Fixed32 a, Fixed32 b)
        {
            return Mul(a.rawvalue, b.rawvalue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static Fixed32 Mul(long a, long b)
        {
            // 整数部分
            var aint = a >> INTEGRAL_BITS;
            var bint = b >> INTEGRAL_BITS;
            // 小数部分
            var afrac = (ulong)(a & FRACTIONAL_MASK);
            var bfrac = (ulong)(b & FRACTIONAL_MASK);

            var rint = (aint * bint) << FRACTIONAL_BITS; // 整数的积
            var rfrac = (afrac * bfrac) >> FRACTIONAL_BITS; // 小数的积
            var rcrs = (aint * (long)bfrac + bint * (long)afrac); // 交叉部分

            return FromRaw(rint + rcrs + (long)rfrac);
        }
    }
}
