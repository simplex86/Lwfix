namespace Lwkit.Fixed
{
    internal static class Int32Extend
    {
        /// <summary>
        /// 是否等于零
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsZero(this Int32 value)
        {
            return value == 0;
        }

        /// <summary>
        /// 是否为正数（包括0）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPositive(this Int32 value)
        {
            return value >= 0;
        }

        /// <summary>
        /// 是否为负数
        /// </summary>
        /// <returns></returns>
        public static bool IsNegative(this Int32 value)
        {
            return value < 0;
        }
    }
}
