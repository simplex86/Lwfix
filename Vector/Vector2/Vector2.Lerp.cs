namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量 - 插值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct Vector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// （不限制）插值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector2<T> Lerp(Vector2<T> a, Vector2<T> b, T t)
        {
            
            return new Vector2<T>(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t);
        }

        /// <summary>
        /// 插值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector2<T> ClampLerp(Vector2<T> a, Vector2<T> b, T t)
        {
            t = FMath.Clamp01(t);
            return Lerp(a, b, t);
        }
    }
}
