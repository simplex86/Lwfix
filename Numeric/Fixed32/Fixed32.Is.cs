namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 检测
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 是否为0
        /// </summary>
        /// <returns></returns>
        public bool IsZero()
        {
            return rawvalue.IsZero();
        }

        /// <summary>
        /// 是否为0
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsZero(Fixed32 n)
        {
            return n.IsZero();
        }

        /// <summary>
        /// 是否为最大值
        /// </summary>
        /// <returns></returns>
        public bool IsMax()
        {
            return rawvalue.IsMax();
        }

        /// <summary>
        /// 是否为最大值
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsMax(Fixed32 n)
        {
            return n.IsMax();
        }

        /// <summary>
        /// 是否为最小值
        /// </summary>
        /// <returns></returns>
        public bool IsMin()
        {
            return rawvalue.IsMin();
        }

        /// <summary>
        /// 是否为最小值
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsMin(Fixed32 n)
        {
            return n.IsMin();
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
            return rawvalue.IsPositiveInfinity();
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
            return rawvalue.IsNegativeInfinity();
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
            return rawvalue.IsNaN();
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

        /// <summary>
        /// 是否为正数（包括0）
        /// </summary>
        /// <returns></returns>
        public bool IsPositive()
        {
            return rawvalue >= 0;
        }

        /// <summary>
        /// 是否为正数（包括0）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPositive(Fixed32 value)
        {
            return value.IsPositive();
        }

        /// <summary>
        /// 是否为负数
        /// </summary>
        /// <returns></returns>
        public bool IsNegative()
        {
            return rawvalue < 0;
        }

        /// <summary>
        /// 是否为负数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNegative(Fixed32 value)
        {
            return value.IsNegative();
        }

        /// <summary>
        /// 是否为小数
        /// </summary>
        /// <returns></returns>
        public bool IsFractional()
        {
            return rawvalue.IsFractional();
        }
    }
}
