namespace Lwfix
{
    /// <summary>
    /// 定点数 - 数学
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDelta"></param>
        /// <returns></returns>
        public static Fixed32 MoveTowards(Fixed32 current, Fixed32 target, Fixed32 maxDelta)
        {
            if (Abs(target - current) <= maxDelta) return target;
            return current + Sign(target - current) * maxDelta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDelta"></param>
        /// <returns></returns>
        public static Fixed32 MoveTowardsAngle(Fixed32 current, Fixed32 target, Fixed32 maxDelta)
        {
            target = current + DeltaAngle(current, target);
            return MoveTowards(current, target, maxDelta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static Fixed32 Repeat(Fixed32 t, Fixed32 length)
        {
            return t - Floor(t / length) * length;
        }

        /// <summary>
        /// 两个角度之间的最小差（度）
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Fixed32 DeltaAngle(Fixed32 current, Fixed32 target)
        {
            var num = Repeat(target - current, N360);
            return (num > N180) ? num - N360  : num;
        }
    }
}
