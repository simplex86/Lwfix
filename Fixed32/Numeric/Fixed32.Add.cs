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
            var b_rawvalue = Int32ToRaw(b);
            return Add(a.rawvalue, b_rawvalue, out var _);
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

            if (PreprocessAdd(a, b, out var r))
            {
                return r;
            }
            
            var c = OverflowAdd(a, b, ref overflow);
            if (overflow)
            {
                if (a > 0) return PositiveInfinity;
                return NegativeInfinity;
            }
            else
            {
                if (c < MinValue.rawvalue) return NegativeInfinity;
                if (c > MaxValue.rawvalue) return PositiveInfinity;
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
        private static bool PreprocessAdd(long a, long b, out Fixed32 r)
        {
            // NaN加任何数，得NaN
            if (a.IsNaN() || b.IsNaN()) { r = NaN; return true; }
            // 正负无穷相加，得NaN
            if (a.IsPositiveInfinity() && b.IsNegativeInfinity()) { r = NaN; return true; }
            if (a.IsNegativeInfinity() && b.IsPositiveInfinity()) { r = NaN; return true; }
            // 最大值加正数，得正无穷
            if (a.IsMax() && b > 0) { r = PositiveInfinity; return true; }
            if (b.IsMax() && a > 0) { r = PositiveInfinity; return true; }
            // 最小值加负数，得负无穷
            if (a.IsMin() && b < 0) { r = NegativeInfinity; return true; }
            if (b.IsMin() && a < 0) { r = NegativeInfinity; return true; }
            // 正无穷加任何数，得正无穷
            if (a.IsPositiveInfinity() || b.IsPositiveInfinity()) { r = PositiveInfinity; return true; }
            // 负无穷加任何数，得负无穷
            if (a.IsNegativeInfinity() || b.IsNegativeInfinity()) { r = NegativeInfinity; return true; }

            r = Zero;
            return false;
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
