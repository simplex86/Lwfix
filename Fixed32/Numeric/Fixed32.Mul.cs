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
        public static Fixed32 operator *(Fixed32 a, int b)
        {
            var b_rawvalue = Int32ToRaw(b);
            return Mul(a.rawvalue, b_rawvalue, out var _);
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
            return Mul(a.rawvalue, b.rawvalue, out var _);
        }

        /// <summarys
        /// 计算乘法，并获知乘结果是否溢出
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="overflow"></param>
        /// <returns></returns>
        private static Fixed32 Mul(long a, long b, out bool overflow)
        {
            overflow = false;

            if (PreprocessMul(a, b, out var r))
            {
                return r;
            }

            var aint = a >> FRACTIONAL_BITS;
            var bint = b >> FRACTIONAL_BITS;
            var afrac = (ulong)(a & FRACTIONAL_MASK);
            var bfrac = (ulong)(b & FRACTIONAL_MASK);

            var term1 = aint * bint;
            var term2 = aint * (long)bfrac;
            var term3 = bint * (long)afrac;
            var term4 = afrac * bfrac;

            var c = OverflowAdd((long)(term4 >> FRACTIONAL_BITS), term3, ref overflow);
            c = OverflowAdd(c, term2, ref overflow);
            c = OverflowAdd(c, term1 << INTEGRAL_BITS, ref overflow);

            var signs = IsSameSign(a, b); // 符号相同
            if (signs)
            {
                if (c < 0 || (overflow && a > 0)) return PositiveInfinity;
            }
            else
            {
                if (c > 0) return NegativeInfinity;
            }

            var carry = term1 >> FRACTIONAL_BITS;
            if (carry != 0 && carry != -1)
            {
                return signs ? PositiveInfinity : NegativeInfinity;
            }

            if (!signs)
            {
                var pos = 0L;
                var neg = 0L;

                if (a > b)
                {
                    pos = a;
                    neg = b;
                }
                else
                {
                    pos = b;
                    neg = a;
                }

                if (c > neg && neg < NegativeOne.rawvalue && pos > One.rawvalue)
                {
                    return NegativeInfinity;
                }
            }

            return FromRaw(c);
        }

        /// <summary>
        /// 预处理特殊边界值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static bool PreprocessMul(long a, long b, out Fixed32 r)
        {
            // NaN乘以任何数，都等于NaN
            if (a == NaN.rawvalue  || b == NaN.rawvalue) { r = NaN; return true; }
            // 零乘以任何数，都等于零
            if (a == Zero.rawvalue || b == Zero.rawvalue) { r = Zero; return true; }
            // 正无穷，乘以正数得正无穷，乘以负数得负无穷
            if (a == PositiveInfinity.rawvalue) { r = b > 0 ? PositiveInfinity : NegativeInfinity; return true; }
            if (b == PositiveInfinity.rawvalue) { r = a > 0 ? PositiveInfinity : NegativeInfinity; return true; }
            // 负无穷，乘以正数得负无穷，乘以负数得正无穷
            if (a == NegativeInfinity.rawvalue) { r = b > 0 ? NegativeInfinity : PositiveInfinity; return true; }
            if (b == NegativeInfinity.rawvalue) { r = a > 0 ? NegativeInfinity : PositiveInfinity; return true; }

            r = Zero;
            return false;
        }
    }
}
