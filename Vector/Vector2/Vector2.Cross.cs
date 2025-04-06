namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量 - 叉乘
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct Vector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 叉乘
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static T Cross(Vector2<T> lhs, Vector2<T> rhs)
        {
            return lhs.X * rhs.Y - lhs.Y * rhs.X;
        }
    }
}
