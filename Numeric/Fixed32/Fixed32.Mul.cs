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
            var afrac = (ulong)(a & FRACTIONAL_MASK);
            var bfrac = (ulong)(b & FRACTIONAL_MASK);

            var rint = (aint * bint) << FRACTIONAL_BITS; // 整数的积
            var rfrac = (afrac * bfrac) >> FRACTIONAL_BITS; // 小数的积
            var rcrs = (aint * (long)bfrac + bint * (long)afrac); // 交叉部分

            return From(rint + rcrs + (long)rfrac);
            //var xl = x;
            //var yl = y;

            //var xlo = (ulong)(xl & 0x00000000FFFFFFFF);
            //var xhi = xl >> FRACTIONAL_BITS;
            //var ylo = (ulong)(yl & 0x00000000FFFFFFFF);
            //var yhi = yl >> FRACTIONAL_BITS;

            //var lolo = xlo * ylo;
            //var lohi = (long)xlo * yhi;
            //var hilo = xhi * (long)ylo;
            //var hihi = xhi * yhi;

            //var loResult = lolo >> FRACTIONAL_BITS;
            //var midResult1 = lohi;
            //var midResult2 = hilo;
            //var hiResult = hihi << FRACTIONAL_BITS;

            //var sum = (long)loResult + midResult1 + midResult2 + hiResult;
            //return From(sum);
        }
    }
}
