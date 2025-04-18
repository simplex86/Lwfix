namespace Lwfix
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
            return FMath.Max(a, b);
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
            return FMath.Max(a, b, c);
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
            return FMath.Max(a, b, c, d);
        }

        /// <summary>
        /// 最大值
        /// </summary>
        /// <param name="fixeds"></param>
        /// <returns></returns>
        public static Fixed32 Max(params Fixed32[] fixeds)
        {
            return FMath.Max(fixeds);
        }
    }
}
