namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 取余
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator %(Fixed32 a, int b)
        {
            if (a.IsNaN()) return NaN;
            if (a.IsInfinity()) return NaN;
            if (a.IsMin()) return Zero;
            if (b == -1) return Zero;

            return Mod(a.rawvalue, (long)b << INTEGRAL_BITS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator %(int a, Fixed32 b)
        {
            if (b.IsNaN()) return NaN;
            if (b == NegativeOne) return Zero;
            if (b.IsMax() || b.IsMin() || b.IsInfinity()) return new Fixed32(a);

            return Mod((long)a << INTEGRAL_BITS, b.rawvalue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator %(Fixed32 a, Fixed32 b)
        {
            if (a.IsNaN() || b.IsNaN()) return NaN;
            if (a.IsInfinity()) return NaN;
            if (a.IsMin()) return Zero;
            if (b == NegativeOne) return Zero;
            if (b.IsMax() || b.IsMin() || b.IsInfinity()) return new Fixed32(a);

            return Mod(a.rawvalue, b.rawvalue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static Fixed32 Mod(long a, long b)
        {
            if (a == MinValue.rawvalue && b == -1)
            {
                return 0;
            }

            return FromRaw(a % b);
        }
    }
}
