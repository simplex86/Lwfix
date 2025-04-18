namespace Lwfix
{
    /// <summary>
    /// 定点数 - 插值
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 线性插值
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Fixed32 Lerp(Fixed32 value1, Fixed32 value2, Fixed32 amount)
        {
            return FMath.Lerp(value1, value2, amount);
        }

        /// <summary>
        /// 线性插值
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Fixed32 ClampLerp(Fixed32 value1, Fixed32 value2, Fixed32 amount)
        {
            return FMath.ClampLerp(value1, value2, amount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Fixed32 InverseLerp(Fixed32 value1, Fixed32 value2, Fixed32 amount)
        {
            return FMath.InverseLerp(value1, value2, amount);
        }

        /// <summary>
        /// 平滑插值
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Fixed32 SmoothStep(Fixed32 value1, Fixed32 value2, Fixed32 amount)
        {
            return FMath.SmoothStep(value1, value2, amount);
        }
    }
}
