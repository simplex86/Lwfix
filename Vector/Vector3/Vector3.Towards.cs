namespace Lwkit.Fixed
{
    /// <summary>
    /// 三维向量 - 移动
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct FVector3<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 移动到
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDistanceDelta"></param>
        /// <returns></returns>
        public static FVector3<T> MoveTowards(FVector3<T> current, FVector3<T> target, T maxDistanceDelta)
        {
            var x = target.X - current.X;
            var y = target.Y - current.Y;
            var z = target.Z - current.Z;

            var d = x * x + y * y;
            if (d.IsZero() || maxDistanceDelta.IsPositive() && d <= maxDistanceDelta * maxDistanceDelta)
            {
                return target;
            }

            d = FMath.Sqrt(d);
            x = current.X + x / d * maxDistanceDelta;
            y = current.Y + y / d * maxDistanceDelta;
            z = current.Z + z / d * maxDistanceDelta;

            return new FVector3<T>(x, y, z);
        }

        /// <summary>
        /// 旋转到
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxRadiansDelta"></param>
        /// <param name="maxMagnitudeDelta"></param>
        /// <returns></returns>
        public static FVector3<T> RotateTowards(FVector3<T> current, FVector3<T> target, T maxRadiansDelta, T maxMagnitudeDelta)
        {
            // TODO
            return target;
        }
    }
}
