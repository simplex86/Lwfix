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
            return Div(a.value, (long)b << INTEGRAL_BITS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(int a, Fixed32 b)
        {
            return Div((long)a << INTEGRAL_BITS, b.value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(Fixed32 a, float b)
        {
            return Div(a.value, (long)(b * FRACTIONAL_MULTIPLIER));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(float a, Fixed32 b)
        {
            return Div((long)(a * FRACTIONAL_MULTIPLIER), b.value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(Fixed32 a, double b)
        {
            return Div(a.value, (long)(b * FRACTIONAL_MULTIPLIER));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(double a, Fixed32 b)
        {
            return Div((long)(a * FRACTIONAL_MULTIPLIER), b.value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(Fixed32 a, Fixed32 b)
        {
            return Div(a.value, b.value);
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
        /// <param name="n"></param>
        /// <returns></returns>
        public static int GetTrailingZeroCount(ulong n)
        {
            if (n == 0) return 64;

            var count = 0;
            {
                while ((n & 0xF) == 0) { count += 4; n >>= 4; }
                while ((n & 0x1) == 0) { count += 1; n >>= 1; }
            }
            return count;
        }

        /// <summary>
        /// 两个数符号是否相同
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static bool IsSameSign(long a, long b)
        {
            return ((a ^ b) & SIGN_BIT_MASK) == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static Fixed32 Div(long a, long b)
        {
            if (b == 0) return NaN;

            var am = a >> (TOTAL_BITS - 1);
            var bm = b >> (TOTAL_BITS - 1);

            var remainder = (ulong)((a + am) ^ am); // 余数
            var divisor = (ulong)((b + bm) ^ bm); // 除数
            var quotient = 0UL; // 商

            // 如果 divisor 是 2 的幂，直接右移来进行除法运算；
            // 否则，进行逐位除法
            if ((divisor & (divisor - 1)) == 0) 
            {
                quotient = remainder >> GetTrailingZeroCount(divisor);
                remainder = remainder & (divisor - 1);
            }
            else
            {
                var bitptr = TOTAL_BITS / 2 + 1;

                while ((divisor & 0xF) == 0 && bitptr >= 4)
                {
                    divisor >>= 4;
                    bitptr -= 4;
                }

                while (remainder != 0 && bitptr >= 0)
                {
                    int shift = GetLeadingZeroCount(remainder);
                    if (shift > bitptr) shift = bitptr;
                    
                    remainder <<= shift;
                    bitptr -= shift;

                    var quot = remainder / divisor;
                    remainder = remainder % divisor;
                    quotient += quot << bitptr;

                    if ((quot & ~(FULL_BIT_MASK >> bitptr)) != 0)
                    {
                        return IsSameSign(a, b) ? MaxValue : MinValue;
                    }

                    remainder <<= 1;
                    bitptr -= 1;
                }
            }

            var result = (long)(quotient >> 1);
            if ((quotient & 1) != 0 &&       // 商的最低位为 1，且
                remainder >= (divisor >> 1)) // 余数大于等于除数的一半
            {
                result += 1; // 则进位
            }
            // 符号相反，则取负
            if (!IsSameSign(a, b))
            {
                result = -result;
            }

            return From(result);
        }
    }
}
