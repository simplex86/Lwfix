namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 减法
    /// </summary>
    public partial struct Fixed32
    {
        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(Fixed32 a, int b)
        {
            return From(a.value - ((long)b <<  INTEGRAL_BITS));
        }

        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(int a, Fixed32 b)
        {
            return From(((long)a << INTEGRAL_BITS) - b.value);
        }

        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(Fixed32 a, Fixed32 b)
        {
            return From(a.value - b.value);
        }

        /// <summary>
        /// 相反数
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(Fixed32 b)
        {
            return From(-b.value);
        }
    }
}
