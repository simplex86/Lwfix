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
            // NaN加任何数，得NaN
            if (a.IsNaN()) return NaN;
            // 正无穷加任何数，得正无穷
            if (a.IsPositiveInfinity()) return PositiveInfinity;
            // 负无穷加任何数，得负无穷
            if (a.IsNegativeInfinity()) return NegativeInfinity;
            // 最大值加正数，得正无穷
            if (a.IsMaxValue() && b > 0) return PositiveInfinity;
            // 最小值加负数，得负无穷
            if (a.IsMinValue() && b < 0) return NegativeInfinity;

            //return FromRaw(a.rawvalue + ((long)b << INTEGRAL_BITS));
            var result = Add(a.rawvalue, ((long)b) << INTEGRAL_BITS, out var _);
            return FromRaw(result);
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
            // NaN加任何数，得NaN
            if (a.IsNaN() || b.IsNaN()) return NaN;
            // 正负无穷相加，得NaN
            if (a.IsPositiveInfinity() && b.IsNegativeInfinity()) return NaN;
            if (a.IsNegativeInfinity() && b.IsPositiveInfinity()) return NaN;
            // 最大值加正数，得最大值
            if (a.IsMaxValue() && b.IsPositive()) return MaxValue;
            // 最小值加负数，得最小值
            if (a.IsMinValue() && b.IsNegative()) return MinValue;
            // 正无穷加任何数，得正无穷
            if (a.IsPositiveInfinity() || b.IsPositiveInfinity()) return PositiveInfinity;
            // 负无穷加任何数，得负无穷
            if (a.IsNegativeInfinity() || b.IsNegativeInfinity()) return NegativeInfinity;

            var result = Add(a.rawvalue, b.rawvalue, out var _);
            return FromRaw(result);
        }

        /// <summary>
        /// 相加并检查溢出
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="overflow"></param>
        /// <returns></returns>
        private static long Add(long a, long b, out bool overflow)
        {
            var r = a + b;

            overflow = false;
            if ((a ^ b) >= 0) // 符号相同
            {
                overflow = (a > 0 && r < 0) ||  (a < 0 && r > 0);// 相加后的符号是否改变（溢出标志）
                if (overflow)
                {
                    return (a < 0) ? NegativeInfinity.rawvalue
                                   : PositiveInfinity.rawvalue;
                }
            }

            if (!overflow)
            {
                if (r < MinValue.rawvalue) r = NegativeInfinity.rawvalue;
                if (r > MaxValue.rawvalue) r = PositiveInfinity.rawvalue;
            }

            return r;
        }
    }
}
