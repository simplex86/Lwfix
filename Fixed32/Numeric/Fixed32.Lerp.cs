namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 插值
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// Hermite插值
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="tangent1"></param>
        /// <param name="value2"></param>
        /// <param name="tangent2"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private static Fixed32 Hermite(Fixed32 value1, Fixed32 tangent1, Fixed32 value2, Fixed32 tangent2, Fixed32 amount)
        {
            // All transformed to Fixed32 not to lose precission
            // Otherwise, for high numbers of param:amount the result is NaN instead of Infinity
            if (amount == Zero) return value1;
            if (amount == One)  return value2;

            var s1 = amount;
            var s2 = s1 * s1;
            var s3 = s1 * s2;

            var result = (2 * value1 - 2 * value2 + tangent2 + tangent1) * s3 +
                         (3 * value2 - 3 * value1 - 2 * tangent1 - tangent2) * s2 +
                         tangent1 * s1 + value1;

            return result;
        }

        /// <summary>
        /// 线性插值
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Fixed32 Lerp(Fixed32 value1, Fixed32 value2, Fixed32 amount)
        {
            if (PreprocessLerp(value1, value2, amount, out var r))
            {
                return r;
            }

            if (value1 == value2 ||
                amount == Zero)
            {
                return value1;
            }

            return value1 + (value2 - value1) * Clamp01(amount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Fixed32 InverseLerp(Fixed32 value1, Fixed32 value2, Fixed32 amount)
        {
            if (PreprocessLerp(value1, value2, amount, out var r))
            {
                return r;
            }

            if (value1 == value2) return Zero;
            return Clamp01((amount - value1) / (value2 - value1));
        }

        /// <summary>
        /// 平滑插值
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Fixed32 SmoothStep(Fixed32 value1, Fixed32 value2, Fixed32 amount)
        {
            if (PreprocessLerp(value1, value2, amount, out var r))
            {
                return r;
            }

            amount = Clamp01(amount);
            return Hermite(value1, Zero, value2, Zero, amount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="amount"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static bool PreprocessLerp(Fixed32 value1, Fixed32 value2, Fixed32 amount, out Fixed32 r)
        {
            if (amount.IsNaN() || amount.IsInfinity())
            {
                r = NaN;
                return true;
            }

            if (value1.IsNaN() || value2.IsNaN())
            {
                r = NaN;
                return true;
            }

            if (value1.IsInfinity() && value2.IsInfinity())
            {
                r = IsSigns(value1, value2) ? value1 : NaN;
                return true;
            }

            r = Zero;
            return false;
        }
    }
}
