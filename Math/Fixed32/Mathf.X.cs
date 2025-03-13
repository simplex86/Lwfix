namespace Lwkit.Fixed
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static partial class Mathf
    {
        /// <summary>
        /// 平方
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Pow2(Fixed32 n)
        {
            if (n == Fixed32.Zero) return Fixed32.Zero;
            if (n == Fixed32.One)  return Fixed32.One;

            return n * n;
        }

        /// <summary>
        /// 三次方
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Pow3(Fixed32 n)
        {
            if (n == Fixed32.Zero) return Fixed32.Zero;
            if (n == Fixed32.One) return Fixed32.One;

            return n * n * n;
        }

        /// <summary>
        /// 获取整数部分
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Integral(Fixed32 n)
        {
            return Fixed32.From(n.value & Fixed32.INTEGRAL_MASK);
        }

        /// <summary>
        /// 获取小数部分
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Fractional(Fixed32 n)
        {
            return Fixed32.From(n.value & Fixed32.FRACTIONAL_MASK);
        }

        /// <summary>
        /// 角度转弧度
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static Fixed32 DegreeToRadian(Fixed32 degree)
        {
            return Fixed32.DegreeToRadian(degree);
        }

        /// <summary>
        /// 弧度转角度
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 RadianToDegree(Fixed32 radian)
        {
            return Fixed32.RadianToDegree(radian);
        }
    }
}
