namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量 - 移动
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct Vector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 移动到
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDistanceDelta"></param>
        /// <returns></returns>
        public static Vector2<T> MoveTowards(Vector2<T> current, Vector2<T> target, T maxDistanceDelta)
        {
            var x = target.X - current.X;
            var y = target.Y - current.Y;

            var d = x * x + y * y;
            if (d == 0 || maxDistanceDelta >= 0 && d <= maxDistanceDelta * maxDistanceDelta)
            {
                return target;
            }

            d = FMath.Sqrt(d);
            x = current.X + x / d * maxDistanceDelta;
            y = current.Y + y / d * maxDistanceDelta;

            return new Vector2<T>(x, y);
        }
    }
}
