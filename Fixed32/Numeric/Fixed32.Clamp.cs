namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 数学
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static Fixed32 Clamp(Fixed32 value, Fixed32 min, Fixed32 max)
        {
            if (value.IsNaN()) return NaN;

            if (min.IsNaN()) min = NegativeInfinity;
            if (max.IsNaN()) max = PositiveInfinity;

            if (value < min)   return min;
            if (value > max)   return max;
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fixed32 Clamp01(Fixed32 value)
        {
            return Clamp(value, Zero, One);
        }
    }
}
