﻿namespace Lwkit.Fixed
{
    /// <summary>
    /// 三维向量 - 缩放
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct FVector3<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 缩放
        /// </summary>
        /// <param name="scale"></param>
        public void Scale(FVector3<T> scale)
        {
            X *= scale.X;
            Y *= scale.Y;
            Z *= scale.Z;
        }

        /// <summary>
        /// 缩放
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static FVector3<T> Scale(FVector3<T> a, FVector3<T> b)
        {
            return new FVector3<T>(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }
    }
}
