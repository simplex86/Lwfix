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
            if (a.IsNaN()) return NaN;

            var result = Mul(a.rawvalue, (long)b << INTEGRAL_BITS, out var _);
            return FromRaw(result);
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
            if (a.IsNaN() || b.IsNaN()) return NaN;

            var result = Mul(a.rawvalue, b.rawvalue, out var _);
            return FromRaw(result);
        }

        /// <summarys
        /// 计算乘法，并获知乘结果是否溢出
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="overflow"></param>
        /// <returns></returns>
        private static long Mul(long a, long b, out bool overflow)
        {
            overflow = false;
            if (a == 0 || b == 0) return 0;

            var aint = a >> FRACTIONAL_BITS;          // xhi
            var bint = b >> FRACTIONAL_BITS;          // yhi
            var afrac = (ulong)(a & FRACTIONAL_MASK); // xlo
            var bfrac = (ulong)(b & FRACTIONAL_MASK); // ylo

            var term1 = aint * bint;        // hihi
            var term2 = aint * (long)bfrac; // hilo
            var term3 = bint * (long)afrac; // lohi
            var term4 = afrac * bfrac;      // lolo

            var r = OverflowAdd((long)(term4 >> FRACTIONAL_BITS), term3, ref overflow);
            r = OverflowAdd(r, term2, ref overflow);
            r = OverflowAdd(r, term1 << INTEGRAL_BITS, ref overflow);

            var signs = ((a ^ b) & long.MinValue) == 0;
            if (signs)
            {
                if (r < 0 || (overflow && a > 0)) return PositiveInfinity.rawvalue;
            }
            else
            {
                if (r > 0) return NegativeInfinity.rawvalue;
            }

            var carry = term1 >> FRACTIONAL_BITS;
            if (carry != 0 && carry != -1 /*&& xl != -17 && b != -17*/)
            {
                return signs ? PositiveInfinity.rawvalue : NegativeInfinity.rawvalue;
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

                if (r > neg && neg < NegativeOne.rawvalue && pos > One.rawvalue)
                {
                    return NegativeInfinity.rawvalue;
                }
            }

            return r;
        }
    }
}
