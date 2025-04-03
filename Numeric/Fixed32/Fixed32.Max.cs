namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 最大值
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 最大值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 Max(Fixed32 a, Fixed32 b)
        {
            if (a.IsNaN() || b.IsNaN()) return NaN;
            return a > b ? a : b;
        }

        /// <summary>
        /// 最大值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Fixed32 Max(Fixed32 a, Fixed32 b, Fixed32 c)
        {
            return Max(a, Max(b, c));
        }

        /// <summary>
        /// 最大值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Fixed32 Max(Fixed32 a, Fixed32 b, Fixed32 c, Fixed32 d)
        {
            return Max(a, Max(b, c, d));
        }

        /// <summary>
        /// 最大值
        /// </summary>
        /// <param name="fixeds"></param>
        /// <returns></returns>
        public static Fixed32 Max(params Fixed32[] fixeds)
        {
            if (fixeds == null || fixeds.Length < 2)
            {
                return NaN;
            }

            var min = Max(fixeds[0], fixeds[1]);
            for (int i = 2; i < fixeds.Length; i++)
            {
                min = Max(min, fixeds[i]);
            }

            return min;
        }
    }
}
