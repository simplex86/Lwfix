using System.Numerics;

namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFixed<T> : IMinMaxValue<T>
                               , IComparable
                               , IComparable<T>
                               , IEquatable<T> 
        where T : IFixed<T>
    {
        #region property

        /// <summary>
        /// 
        /// </summary>
        abstract static T AdditiveIdentity { get; }
        /// <summary>
        /// 
        /// </summary>
        abstract static T MultiplicativeIdentity { get; }
        /// <summary>
        /// 0
        /// </summary>
        abstract static T Zero { get; }
        /// <summary>
        /// 
        /// </summary>
        abstract static T Half { get; }
        /// <summary>
        /// 1
        /// </summary>
        abstract static T One { get; }
        /// <summary>
        /// -1
        /// </summary>
        abstract static T NegativeOne { get; }
        /// <summary>
        /// 1
        /// </summary>
        abstract static T Two { get; }
        /// <summary>
        /// ln(2)
        /// </summary>
        abstract static T Ln2 { get; }
        /// <summary>
        /// ln(10)
        /// </summary>
        abstract static T Ln10 { get; }
        /// <summary>
        /// 非数字
        /// </summary>
        abstract static T NaN { get; }
        /// <summary>
        /// 精度
        /// </summary>
        abstract static T Epsilon { get; }

        /// <summary>
        /// 自然常数e
        /// </summary>
        abstract static T E { get; }
        /// <summary>
        /// π
        /// </summary>
        abstract static T PI { get; }
        /// <summary>
        /// π/ 2
        /// </summary>
        abstract static T Half_PI { get; }
        /// <summary>
        /// π/ 4
        /// </summary>
        abstract static T Quarter_PI { get; }
        /// <summary>
        /// 2π
        /// </summary>
        abstract static T Two_PI { get; }

        /// <summary>
        /// 10^-1
        /// </summary>
        abstract static Fixed32 TPN1 { get; }
        /// <summary>
        /// 10^-2
        /// </summary>
        abstract static Fixed32 TPN2 { get; }
        /// <summary>
        /// 10^-3
        /// </summary>
        abstract static Fixed32 TPN3 { get; }
        /// <summary>
        /// 10^-4
        /// </summary>
        abstract static Fixed32 TPN4 { get; }

        /// <summary>
        /// 180
        /// </summary>
        abstract static Fixed32 N180 { get; }
        /// <summary>
        /// 360
        /// </summary>
        abstract static Fixed32 N360 { get; }

        /// <summary>
        /// 正无穷
        /// </summary>
        abstract static T PositiveInfinity { get; }
        /// <summary>
        /// 负无穷
        /// </summary>
        abstract static T NegativeInfinity { get; }

        #endregion

        #region cast

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        abstract static explicit operator byte(T n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        abstract static explicit operator short(T n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        abstract static explicit operator int(T n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        abstract static explicit operator long(T n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        abstract static explicit operator float(T n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        abstract static explicit operator double(T n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        abstract static implicit operator T(byte n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        abstract static implicit operator T(short n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        abstract static implicit operator T(int n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        abstract static explicit operator T(long n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        abstract static explicit operator T(float n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        abstract static explicit operator T(double n);

        #endregion

        #region compare

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static bool operator ==(T a, T b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static bool operator !=(T a, T b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static bool operator >(T a, T b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static bool operator <(T a, T b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static bool operator >=(T a, T b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static bool operator <=(T a, T b);

        #endregion

        #region add

        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator +(T a, int b);

        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator +(int a, T b);

        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator +(T a, T b);

        #endregion

        #region sub

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator -(T a, int b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator -(int a, T b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator -(T a, T b);

        #endregion

        #region mul

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator *(T a, int b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator *(int a, T b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator *(T a, T b);

        #endregion

        #region div

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator /(T a, int b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator /(int a, T b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator /(T a, T b);

        #endregion

        #region mod

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator %(T a, int b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator %(int a, T b);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static T operator %(T a, T b);

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

        #region abs

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Abs();

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsPowerOfTwo();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T ClosestPowerOfTwo();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T NextPowerOfTwo();

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

        /// <summary>
        /// 四舍五入，返回整数类型
        /// </summary>
        /// <returns></returns>
        int RoundToInt();

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int FloorToInt();

        #endregion

        #region ceil

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Ceil();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int CeilToInt();

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsFractional();

        #endregion

        #region sign

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int Sign();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        abstract static bool IsSigns(T a, T b);

        #endregion

        #region sin

        /// <summary>
        /// 正弦
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        abstract static T Sin(T radian);

        /// <summary>
        /// 快速正弦
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        abstract static T FastSin(T radian);

        /// <summary>
        /// 反正弦
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        abstract static T Asin(T radian);

        #endregion

        #region cos

        /// <summary>
        /// 余弦
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        abstract static T Cos(T radian);

        /// <summary>
        /// 快速余弦
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        abstract static T FastCos(T radian);

        /// <summary>
        /// 反余弦
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        abstract static T Acos(T radian);

        #endregion

        #region tan

        /// <summary>
        /// 正切
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        abstract static T Tan(T radian);

        /// <summary>
        /// 快速正切
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        abstract static T FastTan(T radian);

        /// <summary>
        /// 反正切
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        abstract static T Atan(T radian);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        abstract static T Atan2(T y, T x);

        #endregion

        #region utils

        /// <summary>
        /// 角度规范化到[0, 2π]
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        abstract static T NormalizeRadian(T radian);

        /// <summary>
        /// 角度转弧度
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        abstract static T DegreeToRadian(T degree);

        /// <summary>
        /// 弧度转角度
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        abstract static T RadianToDegree(T radian);

        #endregion

        #region unity

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDelta"></param>
        /// <returns></returns>
        abstract static T MoveTowards(T current, T target, T maxDelta);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDelta"></param>
        /// <returns></returns>
        abstract static T MoveTowardsAngle(T current, T target, T maxDelta);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        abstract static T Repeat(T t, T length);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        abstract static T DeltaAngle(T current, T target);

        #endregion

        #region damp

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="currentVelocity"></param>
        /// <param name="smoothTime"></param>
        /// <param name="maxSpeed"></param>
        /// <param name="deltaTime"></param>
        /// <returns></returns>
        abstract static T SmoothDamp<T>(T current, T target, ref T currentVelocity, T smoothTime, T maxSpeed, T deltaTime);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="currentVelocity"></param>
        /// <param name="smoothTime"></param>
        /// <param name="maxSpeed"></param>
        /// <returns></returns>
        abstract static T SmoothDamp<T>(T current, T target, ref T currentVelocity, T smoothTime, T maxSpeed);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="currentVelocity"></param>
        /// <param name="smoothTime"></param>
        /// <returns></returns>
        abstract static T SmoothDamp<T>(T current, T target, ref T currentVelocity, T smoothTime);

        #endregion
    }
}
