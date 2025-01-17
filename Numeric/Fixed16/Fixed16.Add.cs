namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 加法
    /// </summary>
    public partial struct Fixed16
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator +(Fixed16 a, byte b)
        {
            return a + (long)b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator +(byte a, Fixed16 b)
        {
            return b + a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator +(Fixed16 a, short b)
        {
            return a + (long)b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator +(short a, Fixed16 b)
        {
            return b + a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator +(Fixed16 a, int b)
        {
            return new Fixed16() { value = a.value + (b << FRACTIONAL_BITS) };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator +(int a, Fixed16 b)
        {
            return b + a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator +(Fixed16 a, long b)
        {
            return a + (int)b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator +(long a, Fixed16 b)
        {
            return b + a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator +(Fixed16 a, float b)
        {
            return new Fixed16() { value = a.value + (int)(b * FRACTIONAL_MULTIPLIER) };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator +(float a, Fixed16 b)
        {
            return b + a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator +(Fixed16 a, double b)
        {
            return new Fixed16() { value = a.value + (int)(b * FRACTIONAL_MULTIPLIER) };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator +(double a, Fixed16 b)
        {
            return b + a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator +(Fixed16 a, Fixed16 b)
        {
            return From(a.value + b.value);
        }
    }
}
