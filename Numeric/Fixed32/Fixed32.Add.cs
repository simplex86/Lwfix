﻿namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 加法
    /// </summary>
    public partial struct Fixed32
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(Fixed32 a, int b)
        {
            return a + (long)b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(int a, Fixed32 b)
        {
            return b + a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(Fixed32 a, float b)
        {
            return From(a.value + (long)(b * FRACTIONAL_MULTIPLIER));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(float a, Fixed32 b)
        {
            return b + a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(Fixed32 a, double b)
        {
            return From(a.value + (long)(b * FRACTIONAL_MULTIPLIER));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(double a, Fixed32 b)
        {
            return b + a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(Fixed32 a, Fixed32 b)
        {
            return From(a.value + b.value);
        }
    }
}
