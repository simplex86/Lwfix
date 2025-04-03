using System.Numerics;

namespace Lwkit.Fixed
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFixed<T> : IMinMaxValue<T>
                               , IComparable
                               , IComparable<T>
                               , IEquatable<T> 
        where T : IFixed<T>
    {
        #region add

        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator +(T a, int b);

        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator +(int a, T b);

        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator +(T a, T b);

        #endregion

        #region sub

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator -(T a, int b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator -(int a, T b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator -(T a, T b);

        #endregion

        #region mul

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator *(T a, int b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator *(int a, T b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator *(T a, T b);

        #endregion

        #region div

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator /(T a, int b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator /(int a, T b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator /(T a, T b);

        #endregion

        #region mod

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator %(T a, int b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator %(int a, T b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static abstract T operator %(T a, T b);

        #endregion

        #region cast

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        byte ToByte();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        short ToShort();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int ToInt();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        long ToLong();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        float ToFloat();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        double ToDouble();

        #endregion

        #region pow

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        T Pow(int n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        T Pow(T n);

        #endregion

        #region exp

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Exp();

        #endregion

        #region sqrt

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Sqrt();

        #endregion

        #region log

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Log();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Log2();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Log10();

        #endregion

        #region round

        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <returns></returns>
        T Round();

        #endregion

        #region reciprocal

        /// <summary>
        /// 倒数
        /// </summary>
        /// <returns></returns>
        T Reciprocal();

        #endregion

        #region floor

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Floor();

        #endregion

        #region ceil

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Ceil();

        #endregion

        #region is

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsNaN();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsZero();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsMin();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsMax();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsInfinity();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsPositiveInfinity();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsNegativeInfinity();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsPositive();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsNegative();

        #endregion
    }
}
