﻿using System;

namespace Lwfix
{
    /// <summary>
    /// 定点数 - 比较
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Fixed32 a, Fixed32 b)
        {
            if (a.IsNaN() || b.IsNaN()) return false;
            return a.rawvalue == b.rawvalue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Fixed32 a, Fixed32 b)
        {
            if (a.IsNaN() || b.IsNaN()) return true;
            return a.rawvalue != b.rawvalue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >(Fixed32 a, Fixed32 b)
        {
            if (a.IsNaN() || b.IsNaN()) return false;
            return a.rawvalue > b.rawvalue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <(Fixed32 a, Fixed32 b)
        {
            if (a.IsNaN() || b.IsNaN()) return false;
            return a.rawvalue < b.rawvalue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >=(Fixed32 a, Fixed32 b)
        {
            if (a.IsNaN() || b.IsNaN()) return false;
            return a.rawvalue >= b.rawvalue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <=(Fixed32 a, Fixed32 b)
        {
            if (a.IsNaN() || b.IsNaN()) return false;
            return a.rawvalue <= b.rawvalue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? other)
        {
            return base.Equals(other);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Fixed32 other)
        {
            return rawvalue == other.rawvalue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int CompareTo(object? value)
        {
            if (value == null)
            {
                return 1;
            }

            if (value is Fixed32 d)
            {
                if (this <  d) return -1;
                if (this >  d) return  1;
                if (this == d) return  0;
            }

            throw new ArgumentException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int CompareTo(Fixed32 value)
        {
            if (this < value) return -1;
            if (this > value) return 1;
            return 0;
        }
    }
}
