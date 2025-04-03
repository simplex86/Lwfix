namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 数学
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <returns></returns>
        public Fixed32 Round()
        {
            if (IsNaN()) return NaN;
            if (IsPositiveInfinity()) return PositiveInfinity;
            if (IsNegativeInfinity()) return NegativeInfinity;

            var frac = rawvalue & FRACTIONAL_MASK;

            if (frac < 0x80000000) return Floor();
            if (frac > 0x80000000) return Ceil();

            return (rawvalue & One.rawvalue) == 0 ? Floor()
                                                  : Ceil();
        }

        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Round(Fixed32 n)
        {
            return n.Round();
        }

        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <returns></returns>
        public int RoundToInt()
        {
            return Round().ToInt();
        }

        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int RoundToInt(Fixed32 n)
        {
            return n.RoundToInt();
        }
    }
}
