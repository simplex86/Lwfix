﻿using System.Numerics;
using System;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="maxMagnitude"></param>
        /// <returns></returns>
        public static FVector2<T> ClampMagnitude(FVector2<T> vector, T maxMagnitude)
        {
            var magnitude = vector.Magnitude;
            if (magnitude > maxMagnitude)
            {
                var x = vector.X / magnitude * maxMagnitude;
                var y = vector.Y / magnitude * maxMagnitude;

                return new FVector2<T>(x, y);
            }

            return vector;
        }
    }
}
