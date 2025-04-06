namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量 - 反射
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct Vector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 反射
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        public static Vector2<T> Reflect(Vector2<T> direction, Vector2<T> normal)
        {
            var t = -2 * Dot(normal, direction);
            var x = t * normal.X + direction.X;
            var y = t * normal.Y + direction.Y;

            return new Vector2<T>(x, y);
        }
    }
}
