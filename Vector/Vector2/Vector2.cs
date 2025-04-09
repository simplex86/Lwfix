﻿namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct FVector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T X { get; set; } = T.Zero;

        /// <summary>
        /// 
        /// </summary>
        public T Y { get; set; } = T.Zero;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public FVector2(T x, T y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public FVector2(FVector2<T> other)
        {
            this.X = other.X;
            this.Y = other.Y;
        }

        /// <summary>
        /// 字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"[{X},{Y}]";

        /// <summary>
        /// 获取Hash码
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() << 2;
        }
    }
}
