﻿using System.Numerics;

namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct Vector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 相加
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector2<T> operator +(Vector2<T> a, Vector2<T> b)
        {
            return new Vector2<T>(a.X + b.X, a.Y + b.Y);
        }

        /// <summary>
        /// 相减
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector2<T> operator -(Vector2<T> a, Vector2<T> b)
        {
            return new Vector2<T>(a.X - b.X, a.Y - b.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector2<T> operator *(Vector2<T> a, Vector2<T> b)
        {
            return new Vector2<T>(a.X * b.X, a.Y * b.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector2<T> operator /(Vector2<T> a, Vector2<T> b)
        {
            return new Vector2<T>(a.X / b.X, a.Y / b.Y);
        }

        /// <summary>
        /// 取反
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vector2<T> operator -(Vector2<T> a)
        {
            return new Vector2<T>(-a.X, -a.Y);
        }

        /// <summary>
        /// 数乘
        /// </summary>
        /// <param name="a"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Vector2<T> operator *(Vector2<T> a, T d)
        {
            return new Vector2<T>(a.X * d, a.Y * d);
        }

        /// <summary>
        /// 数乘
        /// </summary>
        /// <param name="d"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vector2<T> operator *(T d, Vector2<T> a)
        {
            return a * d;
        }

        /// <summary>
        /// 数除
        /// </summary>
        /// <param name="a"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Vector2<T> operator /(Vector2<T> a, T d)
        {
            return new Vector2<T>(a.X / d, a.Y / d);
        }
    }
}
