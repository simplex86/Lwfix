namespace Lwfix
{
    /// <summary>
    /// 定点数 - 减法
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(Fixed32 a, int b)
        {
            var b_rawvalue = Int32ToRaw(b);
            return Sub(a.rawvalue, b_rawvalue, out var _);
        }

        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(int a, Fixed32 b)
        {
            var a_rawvalue = Int32ToRaw(a);
            return Sub(a_rawvalue, b.rawvalue, out var _);
        }

        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(Fixed32 a, Fixed32 b)
        {
            return Sub(a.rawvalue, b.rawvalue, out var _);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static Fixed32 Sub(long a, long b, out bool overflow)
        {
            overflow = false;

            if (PreprocessSub(a, b, out var r))
            {
                return r;
            }

            var c = OverflowSub(a, b, ref overflow);
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
        private static bool PreprocessSub(long a, long b, out Fixed32 r)
        {
            // NaN减任何数，得NaN
            if (a.IsNaN() || b.IsNaN()) { r = NaN; return true; }
            // 正无穷减正无穷，得NaN
            if (a.IsPositiveInfinity() && b.IsPositiveInfinity()) { r = NaN; return true; }
            // 负无穷减负无穷，得NaN
            if (a.IsNegativeInfinity() && b.IsNegativeInfinity()) { r = NaN; return true; }
            // 负无穷减任何数 或 任何数减正无穷，得负无穷
            if (a.IsNegativeInfinity() || b.IsPositiveInfinity()) { r = NegativeInfinity; return true; }
            // 正无穷减任何数 或 任何数减负无穷，得正无穷
            if (a.IsPositiveInfinity() || b.IsNegativeInfinity()) { r = PositiveInfinity; return true; }
            // 最小值减正数，得负无穷
            if (a.IsMin() && b > 0) { r = NegativeInfinity; return true; }
            // 最大值减负数，得正无穷
            if (a.IsMax() && b < 0) { r = PositiveInfinity; return true; }
            // 正数减最小值，得正无穷
            if (b.IsMin() && a > 0) { r = PositiveInfinity; return true; }
            // 负数减最大值，得负无穷
            if (b.IsMax() && a < 0) { r = NegativeInfinity; return true; }

            r = Zero;
            return false;
        }

        /// <summary>
        /// 计算减法，并获知结果是否溢出
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="overflow"></param>
        /// <returns></returns>
        private static long OverflowSub(long a, long b, ref bool overflow)
        {
            var r = a - b;
            overflow |= (((a ^ b) & (a ^ r)) & long.MinValue) != 0;

            return r;
        }

        /// <summary>
        /// 相反数
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(Fixed32 n)
        {
            if (n.IsNaN()) return NaN;
            if (n.IsZero()) return Zero;
            if (n.IsPositiveInfinity()) return NegativeInfinity;
            if (n.IsNegativeInfinity()) return PositiveInfinity;

            return FromRaw(-n.rawvalue);
        }
    }
}
