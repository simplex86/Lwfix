namespace Lwkit.Fixed
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Mathf
    {
        /// <summary>
        /// 绝对值
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Abs(Fixed32 n)
        {
            return n.Abs();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Floor(Fixed32 n)
        {
            return n.Floor();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Ceil(Fixed32 n)
        {
            return n.Ceil();
        }

        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Round(Fixed32 n)
        {
            return n.Round();
        }

        /// <summary>
        /// 最小值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 Min(Fixed32 a, Fixed32 b)
        {
            return a < b ? a : b;
        }

        /// <summary>
        /// 最大值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 Max(Fixed32 a, Fixed32 b)
        {
            return a > b ? a : b;
        }

        /// <summary>
        /// 开方
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Fixed32 Sqrt(Fixed32 n)
        {
            return n.Sqrt();
        }

        /// <summary>
        /// 是否近似
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool Approximately(Fixed32 a, Fixed32 b)
        {
            return Abs(b - a) < Fixed32.Epsilon;
        }
    }
}
