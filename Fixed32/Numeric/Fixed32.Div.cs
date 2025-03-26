namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 乘法
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(Fixed32 a, int b)
        {
            var b_rawvalue = Int32ToRaw(b);
            return Div(a.rawvalue, b_rawvalue, out var _);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(int a, Fixed32 b)
        {
            var a_rawvalue = Int32ToRaw(a);
            return Div(a_rawvalue, b.rawvalue, out var _);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator /(Fixed32 a, Fixed32 b)
        {
            return Div(a.rawvalue, b.rawvalue, out var _);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static Fixed32 Div(long a, long b, out bool overflow)
        {
            overflow = false;

            if (PreprocessDiv(a, b, out var r))
            {
                return r;
            }

            var am = a >> (TOTAL_BITS - 1);
            var bm = b >> (TOTAL_BITS - 1);

            var remainder = (ulong)((a + am) ^ am); // 余数
            var divisor = (ulong)((b + bm) ^ bm); // 除数
            var quotient = 0UL; // 商

            // 如果 divisor 是 2 的幂，直接右移来进行除法运算；
            // 否则，进行逐位除法
            if ((divisor & (divisor - 1)) == 0)
            {
                var shift = GetTrailingZeroCount(divisor) - FRACTIONAL_BITS - 1;
                quotient = shift >= 0 ? remainder >> shift : remainder << -shift;
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
                    var shift = GetLeadingZeroCount(remainder);
                    if (shift > bitptr) shift = bitptr;
                    
                    remainder <<= shift;
                    bitptr -= shift;

                    var quot = remainder / divisor;
                    remainder = remainder % divisor;
                    quotient += quot << bitptr;

                    // overflow
                    if ((quot & ~(FULL_BIT_MASK >> bitptr)) != 0)
                    {
                        overflow = true;
                        return IsSameSign(a, b) ? PositiveInfinity : NegativeInfinity;
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

            return FromRaw(result);
        }

        /// <summary>
        /// 预处理特殊边界值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static bool PreprocessDiv(long a, long b, out Fixed32 r)
        {
            // 任意有一个数是NaN，得NaN
            if (a == NaN.rawvalue || b == NaN.rawvalue) { r = NaN; return true; }
            // 零除以零，得NaN；正数除以零，得正无穷；负数除以零，得负无穷
            if (b == 0)
            {
                if (a == 0) { r = NaN; return true; }
                r = a > 0 ? PositiveInfinity : NegativeInfinity; 
                return true;
            }
            // 任何数除以无穷大，得零；无穷大除以无穷大，得NaN
            if (b == PositiveInfinity.rawvalue || b == NegativeInfinity.rawvalue)
            {
                r = (a == PositiveInfinity.rawvalue || a == NegativeInfinity.rawvalue) ? NaN : Zero;
                return true;
            }
            // 正无穷，除以正数得正无穷；除以负数得负无穷
            if (a == PositiveInfinity.rawvalue) { r = b > 0 ? PositiveInfinity : NegativeInfinity; return true; }
            // 负无穷，除以正数得负无穷；除以负数得正无穷
            if (a == NegativeInfinity.rawvalue) { r = b > 0 ? NegativeInfinity : PositiveInfinity; return true; }

            r = Zero;
            return false;
        }
    }
}
