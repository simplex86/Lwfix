namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量 - 最小值
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
        public static Vector2<T> Min(Vector2<T> lhs, Vector2<T> rhs)
        {
            var x = FMath.Min(lhs.X, rhs.X);
            var y = FMath.Min(lhs.Y, rhs.Y);
            return new Vector2<T>(x, y);
        }
    }
}
