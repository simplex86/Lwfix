﻿namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量 - 插值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct FVector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// （不限制）插值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static FVector2<T> Lerp(FVector2<T> a, FVector2<T> b, T t)
        {
            
            return new FVector2<T>(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t);
        }

        /// <summary>
        /// 插值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static FVector2<T> ClampLerp(FVector2<T> a, FVector2<T> b, T t)
        {
            t = T.Clamp01(t);
            return Lerp(a, b, t);
        }
    }
}
