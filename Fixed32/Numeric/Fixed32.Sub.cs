namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 减法
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(Fixed32 a, int b)
        {
            if (a.IsNaN()) return NaN;
            return FromRaw(a.rawvalue - ((long)b <<  INTEGRAL_BITS));
        }

        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(int a, Fixed32 b)
        {
            if (b.IsNaN()) return NaN;
            return FromRaw(((long)a << INTEGRAL_BITS) - b.rawvalue);
        }

        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(Fixed32 a, Fixed32 b)
        {
            if (a.IsNaN() || b.IsNaN()) return NaN;
            return FromRaw(a.rawvalue - b.rawvalue);
        }

        /// <summary>
        /// 相反数
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(Fixed32 n)
        {
            if (n == NaN)      return NaN;
            if (n == MaxValue) return MinValue;
            if (n == MinValue) return MaxValue;
            return FromRaw(-n.rawvalue);
        }
    }
}
