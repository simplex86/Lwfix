﻿namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量 - 最大值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct FVector3<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static FVector3<T> Max(FVector3<T> lhs, FVector3<T> rhs)
        {
            var x = FMath.Max(lhs.X, rhs.X);
            var y = FMath.Max(lhs.Y, rhs.Y);
            var z = FMath.Max(lhs.Z, rhs.Z);

            return new FVector3<T>(x, y, z);
        }
    }
}
