﻿namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量 - 最小值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct FVector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static FVector2<T> Min(FVector2<T> lhs, FVector2<T> rhs)
        {
            var x = FMath.Min(lhs.X, rhs.X);
            var y = FMath.Min(lhs.Y, rhs.Y);
            return new FVector2<T>(x, y);
        }
    }
}
