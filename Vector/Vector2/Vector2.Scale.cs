namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量 - 缩放
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct Vector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 缩放
        /// </summary>
        /// <param name="scale"></param>
        public void Scale(Vector2<T> scale)
        {
            X *= scale.X;
            Y *= scale.Y;
        }

        /// <summary>
        /// 缩放
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector2<T> Scale(Vector2<T> a, Vector2<T> b)
        {
            return new Vector2<T>(a.X * b.X, a.Y * b.Y);
        }
    }
}
