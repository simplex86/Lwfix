namespace Lwfix
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
            return FMath.Min(a, b);
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
            return FMath.Min(a, b, c);
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
            return FMath.Min(a, b, c, d);
        }

        /// <summary>
        /// 求多个数的最小值
        /// </summary>
        /// <param name="fixeds"></param>
        /// <returns></returns>
        public static Fixed32 Min(params Fixed32[] fixeds)
        {
            return FMath.Min(fixeds);
        }
    }
}
