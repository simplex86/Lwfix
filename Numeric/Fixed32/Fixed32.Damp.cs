namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 0.48
        /// </summary>
        private readonly static Fixed32 P48  = FromRaw(0);
        /// <summary>
        /// 0.235
        /// </summary>
        private readonly static Fixed32 P235 = FromRaw(0);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="currentVelocity"></param>
        /// <param name="smoothTime"></param>
        /// <param name="maxSpeed"></param>
        /// <param name="deltaTime"></param>
        /// <returns></returns>
        public static Fixed32 SmoothDamp(Fixed32 current, Fixed32 target, ref Fixed32 currentVelocity, Fixed32 smoothTime, Fixed32 maxSpeed, Fixed32 deltaTime)
        {
            smoothTime = Max(TPN4, smoothTime);
            var max = maxSpeed * smoothTime;

            var num1 = Two / smoothTime;
            var num2 = num1 * deltaTime;
            var num3 = Reciprocal(One + num2 + P48 * num2 * num2 + P235 * num2 * num2 * num2);
            var num4 = Clamp(current - target, -max, max);
            var num5 = target;
            var num6 = (currentVelocity + num1 * num4) * deltaTime;

            target = current - num4;
            currentVelocity = (currentVelocity - num1 * num6) * num3;

            var num7 = target + (num4 + num6) * num3;
            if ((num5 - current > Zero) == (num7 > num5))
            {
                num7 = num5;
                currentVelocity = (num7 - num5) / deltaTime;
            }

            return num7;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="currentVelocity"></param>
        /// <param name="smoothTime"></param>
        /// <param name="maxSpeed"></param>
        /// <returns></returns>
        public static Fixed32 SmoothDamp(Fixed32 current, Fixed32 target, ref Fixed32 currentVelocity, Fixed32 smoothTime, Fixed32 maxSpeed)
        {
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, TPN2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="currentVelocity"></param>
        /// <param name="smoothTime"></param>
        /// <returns></returns>
        public static Fixed32 SmoothDamp(Fixed32 current, Fixed32 target, ref Fixed32 currentVelocity, Fixed32 smoothTime)
        {
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, MinValue, TPN2);
        }
    }
}
