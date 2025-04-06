namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量 - 最大值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct Vector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector2<T> Max(Vector2<T> lhs, Vector2<T> rhs)
        {
            var x = FMath.Max(lhs.X, rhs.X);
            var y = FMath.Max(lhs.Y, rhs.Y);
            return new Vector2<T>(x, y);
        }
    }
}
