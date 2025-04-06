namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量 - 垂直
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct Vector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 垂直向量（逆时针旋转90度）
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static Vector2<T> Perpendicular(Vector2<T> v)
        {
            return new Vector2<T>(-v.Y, v.X);
        }
    }
}
