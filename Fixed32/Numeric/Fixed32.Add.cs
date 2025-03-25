namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 加法
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(Fixed32 a, int b)
        {
            // 零加上任何数，都等于该数本身
            if (b.IsZero()) return a;
            // NaN加任何数，得NaN
            if (a.IsNaN()) return NaN;
            // 正无穷加任何数，得正无穷
            if (a.IsPositiveInfinity()) return PositiveInfinity;
            // 负无穷加任何数，得负无穷
            if (a.IsNegativeInfinity()) return NegativeInfinity;
            // 最大值加正数，得正无穷
            if (a.IsMax() && b.IsPositive()) return PositiveInfinity;
            // 最小值加负数，得负无穷
            if (a.IsMin() && b.IsNegative()) return NegativeInfinity;

            //return FromRaw(a.rawvalue + ((long)b << INTEGRAL_BITS));
            return Add(a.rawvalue, ((long)b) << INTEGRAL_BITS, out var _);
        }

        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(int a, Fixed32 b)
        {
            return b + a;
        }

        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(Fixed32 a, Fixed32 b)
        {
            // 零加上任何数，都等于该数本身
            if (a.IsZero()) return b;
            if (b.IsZero()) return a;
            // NaN加任何数，得NaN
            if (a.IsNaN() || b.IsNaN()) return NaN;
            // 正负无穷相加，得NaN
            if (a.IsPositiveInfinity() && b.IsNegativeInfinity()) return NaN;
            if (a.IsNegativeInfinity() && b.IsPositiveInfinity()) return NaN;
            // 最大值加正数，得正无穷
            if (a.IsMax() && b.IsPositive()) return PositiveInfinity;
            // 最小值加负数，得负无穷
            if (a.IsMin() && b.IsNegative()) return NegativeInfinity;
            // 正无穷加任何数，得正无穷
            if (a.IsPositiveInfinity() || b.IsPositiveInfinity()) return PositiveInfinity;
            // 负无穷加任何数，得负无穷
            if (a.IsNegativeInfinity() || b.IsNegativeInfinity()) return NegativeInfinity;

            return Add(a.rawvalue, b.rawvalue, out var _);
        }

        /// <summary>
        /// 相加并检查溢出
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="overflow"></param>
        /// <returns></returns>
        private static Fixed32 Add(long a, long b, out bool overflow)
        {
            overflow = false;
            var r = OverflowAdd(a, b, ref overflow);

            if (overflow)
            {
                if (a > 0) return PositiveInfinity;
                return NegativeInfinity;
            }
            else
            {
                if (r < MinValue.rawvalue) return NegativeInfinity;
                if (r > MaxValue.rawvalue) return PositiveInfinity;
            }

            return FromRaw(r);
        }

        /// <summary>
        /// 计算加法，并获知结果是否溢出
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="overflow"></param>
        /// <returns></returns>
        private static long OverflowAdd(long a, long b, ref bool overflow)
        {
            var r = a + b;
            // a + b overflows if sign(a) ^ sign(b) != sign(r)
            overflow |= ((~(a ^ b) & (a ^ r)) & long.MinValue) != 0;

            return r;
        }
    }
}
