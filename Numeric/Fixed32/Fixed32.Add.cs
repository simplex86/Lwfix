namespace Lwkit.Fixed
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
            return From(a.rawvalue + ((long)b << INTEGRAL_BITS));
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
        public static Fixed32 operator +(Fixed32 a, Fixed32 b)
        {
            return From(a.rawvalue + b.rawvalue);
        }
    }
}
