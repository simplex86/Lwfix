namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct Vector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly T Magnitude => FMath.Sqrt(X * X + Y * Y);

        /// <summary>
        /// 
        /// </summary>
        public readonly T SqrMagnitude => X * X + Y * Y;
    }
}
