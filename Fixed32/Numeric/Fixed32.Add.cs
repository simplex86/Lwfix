namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 加法
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(Fixed32 a, int b)
        {
            if (a.IsNaN()) return NaN;
            return FromRaw(a.rawvalue + ((long)b << INTEGRAL_BITS));
        }

        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(int a, Fixed32 b)
        {
            return b + a;
        }

        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(Fixed32 a, Fixed32 b)
        {
            if (a.IsNaN() || b.IsNaN()) return NaN;
            return FromRaw(a.rawvalue + b.rawvalue);
        }
    }
}
