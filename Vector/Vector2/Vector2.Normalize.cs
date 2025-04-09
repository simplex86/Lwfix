using System.Numerics;

namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct FVector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 归一化后的向量
        /// </summary>
        public readonly FVector2<T> Normalized => Normalize(this);

        /// <summary>
        /// 归一化
        /// </summary>
        public void Normalize()
        {
            var m = Magnitude;
            this = (m.IsZero()) ? Zero : this / m;
        }

        /// <summary>
        /// 归一化
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static FVector2<T> Normalize(FVector2<T> v)
        {
            v.Normalize();
            return v;
        }
    }
}
