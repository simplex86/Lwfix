using System.Runtime.Intrinsics.X86;

namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 减法
    /// </summary>
    public partial struct Fixed16
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator -(Fixed16 a, int b)
        {
            return From(a.value - (b << FRACTIONAL_BITS));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator -(int a, Fixed16 b)
        {
            return From((a << FRACTIONAL_BITS) - b.value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator -(Fixed16 a, long b)
        {
            return From(a.value - (int)(b << FRACTIONAL_BITS));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator -(long a, Fixed16 b)
        {
            return From((int)(a << FRACTIONAL_BITS) - b.value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator -(Fixed16 a, float b)
        {
            return From(a.value - (int)(b * FRACTIONAL_MULTIPLIER));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator -(float a, Fixed16 b)
        {
            return From((int)(a * FRACTIONAL_MULTIPLIER) - b.value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator -(Fixed16 a, double b)
        {
            return From(a.value - (int)(b * FRACTIONAL_MULTIPLIER));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator -(double a, Fixed16 b)
        {
            return From((int)(a * FRACTIONAL_MULTIPLIER) - b.value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator -(Fixed16 a, Fixed16 b)
        {
            return From(a.value - b.value);
        }
    }
}
