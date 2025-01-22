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
        public static Fixed32 operator /(Fixed32 a, int b)
        {
            return a / (long)b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(int a, Fixed32 b)
        {
            return (long)a / b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(Fixed32 a, float b)
        {
            var r = Div(a.value, (long)(b * FRACTIONAL_MULTIPLIER));
            return From(r);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(float a, Fixed32 b)
        {
            var r = Div((long)(a * FRACTIONAL_MULTIPLIER), b.value);
            return From(r);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(Fixed32 a, double b)
        {
            var r = Div(a.value, (long)(b * FRACTIONAL_MULTIPLIER));
            return From(r);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(double a, Fixed32 b)
        {
            var r = Div((long)(a * FRACTIONAL_MULTIPLIER), b.value);
            return From(r);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(Fixed32 a, Fixed32 b)
        {
            var r = Div(a.value, b.value);
            return From(r);
        }

        /// <summary>
        /// 获取前导零的数量
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int GetLeadingZeroCount(ulong n)
        {
            var count = 0;
            {
                while ((n & 0xF000000000000000) == 0) { count += 4; n <<= 4; }
                while ((n & 0x8000000000000000) == 0) { count += 1; n <<= 1; }
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static long Div(long a, long b)
        {
            if (b == 0)
            {
                return long.MinValue;
            }

            var remainder = (ulong)(a >= 0 ? a : -a); // 余数
            var divisor = (ulong)(b >= 0 ? b : -b); // 除数
            var quotient = 0uL; // 商
            var bitptr = TOTAL_BITS / 2 + 1;

            while ((divisor & 0xF) == 0 && bitptr >= 4)
            {
                divisor >>= 4;
                bitptr -= 4;
            }

            while (remainder != 0 && bitptr >= 0)
            {
                var shift = GetLeadingZeroCount(remainder);
                if (shift > bitptr) shift = bitptr;

                remainder <<= shift;
                bitptr -= shift;

                var quot = remainder / divisor;
                remainder = remainder % divisor;
                quotient += quot << bitptr;

                if ((quot & ~(0xFFFFFFFFFFFFFFFF >> bitptr)) != 0)
                {
                    return (((a ^ b) & long.MinValue) == 0) ? long.MaxValue : long.MinValue+1;
                }

                remainder <<= 1;
                bitptr -= 1;
            }

            var result = (long)((quotient + 1) >> 1);
            if (((a ^ b) & long.MinValue) != 0) result = -result;

            return result;
        }
    }
}
