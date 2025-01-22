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
            return Mul(a.value, (long)b << INTEGRAL_BITS);
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
        public static Fixed32 operator *(Fixed32 a, float b)
        {
            return Mul(a.value, (long)(b * FRACTIONAL_MULTIPLIER));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator *(float a, Fixed32 b)
        {
            return b * a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator *(Fixed32 a, double b)
        {
            return Mul(a.value, (long)(b * FRACTIONAL_MULTIPLIER));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator *(double a, Fixed32 b)
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
            return Mul(a.value, b.value);
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
            var afrac = (a & FRACTIONAL_MASK);
            var bfrac = (b & FRACTIONAL_MASK);

            var rint  = (aint * bint) << FRACTIONAL_BITS; // 整数的积
            var rfrac = (afrac * bfrac) >> FRACTIONAL_BITS; // 小数的积
            var rcrs  = (aint * bfrac + bint * afrac); // 交叉部分

            return From(rint + rcrs + rfrac);
        }
    }
}
