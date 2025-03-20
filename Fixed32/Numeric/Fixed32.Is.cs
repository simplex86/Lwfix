namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 检测
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 是否为小数
        /// </summary>
        /// <returns></returns>
        internal bool IsFractional()
        {
            return (rawvalue & FRACTIONAL_MASK) != 0;
        }

        /// <summary>
        /// 是否为正负无穷
        /// </summary>
        /// <returns></returns>
        public bool IsInfinity()
        {
            return IsPositiveInfinity() || IsNegativeInfinity();
        }

        /// <summary>
        /// 是否为正负无穷
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInfinity(Fixed32 value)
        {
            return value.IsInfinity();
        }

        /// <summary>
        /// 是否为正无穷
        /// </summary>
        /// <returns></returns>
        public bool IsPositiveInfinity()
        {
            return rawvalue == PositiveInfinity.rawvalue;
        }

        /// <summary>
        /// 是否为正无穷
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPositiveInfinity(Fixed32 value)
        {
            return value.IsPositiveInfinity();
        }

        /// <summary>
        /// 是否为负无穷
        /// </summary>
        /// <returns></returns>
        public bool IsNegativeInfinity()
        {
            return rawvalue == NegativeInfinity.rawvalue;
        }

        /// <summary>
        /// 是否为负无穷
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNegativeInfinity(Fixed32 value)
        {
            return value.IsNegativeInfinity();
        }

        /// <summary>
        /// 是否为NaN
        /// </summary>
        /// <returns></returns>
        public bool IsNaN()
        {
            return rawvalue == NaN.rawvalue;
        }

        /// <summary>
        /// 是否为NaN
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNaN(Fixed32 value)
        {
            return value.IsNaN();
        }
    }
}
