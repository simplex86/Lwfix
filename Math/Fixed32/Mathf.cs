namespace Lwkit.Fixed
{
    /// <summary>
    /// 常规
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
        /// 幂
        /// </summary>
        /// <param name="m">底数</param>
        /// <param name="n">指数</param>
        /// <returns></returns>
        public static Fixed32 Pow(Fixed32 m, int n)
        {
            return m.Power(n);
        }

        /// <summary>
        /// 幂
        /// </summary>
        /// <param name="m">底数</param>
        /// <param name="n">指数</param>
        /// <returns></returns>
        public static Fixed32 Pow(Fixed32 m, Fixed32 n)
        {
            return m.Power(n);
        }

        /// <summary>
        /// e的x次方
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Fixed32 Exp(Fixed32 x)
        {
            return x.Exp();
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
        /// n的自然对数（以e为底）
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Fixed32 Log(Fixed32 n)
        {
            return n.Log();
        }

        /// <summary>
        /// 以2为底n的对数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Fixed32 Log2(Fixed32 n)
        {
            return n.Log2();
        }

        /// <summary>
        /// 以10为底n的对数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Fixed32 Log10(Fixed32 n)
        {
            return n.Log10();
        }

        /// <summary>
        /// 倒数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fixed32 Reciprocal(Fixed32 n)
        {
            return n.Reciprocal();
        }

        /// <summary>
        /// 是否近似（相等）
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool Approximately(Fixed32 a, Fixed32 b)
        {
            return a == b;
        }
    }
}
