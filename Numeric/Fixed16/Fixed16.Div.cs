namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 乘法
    /// </summary>
    public partial struct Fixed16
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator /(Fixed16 a, int b)
        {
            var n = a.IsFractional() ? a.ToDouble()
                                     : a.ToLong();
            return new Fixed16(n / b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator /(int a, Fixed16 b)
        {
            return b * a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator /(Fixed16 a, long b)
        {
            var n = a.IsFractional() ? a.ToDouble() : a.ToLong();
            return new Fixed16(n / b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator /(long a, Fixed16 b)
        {
            return b / a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator /(Fixed16 a, float b)
        {
            var n = a.IsFractional() ? a.ToDouble() : a.ToLong();
            return new Fixed16(n / b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator /(double a, Fixed16 b)
        {
            return b / a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator /(Fixed16 a, double b)
        {
            var n = a.IsFractional() ? a.ToDouble() : a.ToLong();
            return new Fixed16(n / b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator /(float a, Fixed16 b)
        {
            return b / a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 operator /(Fixed16 a, Fixed16 b)
        {
            var u = a.IsFractional() ? a.ToDouble() : a.ToLong();
            var v = b.IsFractional() ? b.ToDouble() : b.ToLong();

            return new Fixed16(u / v);
        }
    }
}
