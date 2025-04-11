namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量 - 大小
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct FVector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 大小
        /// </summary>
        public readonly T Magnitude => SqrMagnitude.Sqrt();

        /// <summary>
        /// 大小
        /// </summary>
        public readonly T SqrMagnitude => X * X + Y * Y;
    }
}
