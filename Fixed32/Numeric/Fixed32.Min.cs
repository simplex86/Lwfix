namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 最小值
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 求两个数的最小值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 Min(Fixed32 a, Fixed32 b)
        {
            if (a.IsNaN() || b.IsNaN()) return NaN;
            return a < b ? a : b;
        }

        /// <summary>
        /// 求三个数的最小值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Fixed32 Min(Fixed32 a, Fixed32 b, Fixed32 c)
        {
            return Min(a, Min(b, c));
        }

        /// <summary>
        /// 求四个数的最小值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Fixed32 Min(Fixed32 a, Fixed32 b, Fixed32 c, Fixed32 d)
        {
            return Min(a, Min(b, c, d));
        }

        /// <summary>
        /// 求多个数的最小值
        /// </summary>
        /// <param name="fixeds"></param>
        /// <returns></returns>
        public static Fixed32 Min(params Fixed32[] fixeds)
        {
            if (fixeds == null || fixeds.Length < 2)
            {
                return NaN;
            }

            var min = Min(fixeds[0], fixeds[1]);
            for (int i=2; i<fixeds.Length; i++)
            {
                min = Min(min, fixeds[i]);
            }

            return min;
        }
    }
}
