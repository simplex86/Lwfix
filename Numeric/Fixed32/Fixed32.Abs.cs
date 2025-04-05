namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 数学
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 绝对值
        /// </summary>
        /// <returns></returns>
        public Fixed32 Abs()
        {
            if (IsNaN()) return NaN;
            if (IsPositive()) return this;
            if (IsNegativeInfinity()) return PositiveInfinity;
            if (IsMin()) return MaxValue;

            var mask = rawvalue >> 63;
            return FromRaw((rawvalue + mask) ^ mask);
        }

        /// <summary>
        /// 绝对值
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Abs(Fixed32 n)
        {
            return FMath.Abs(n);
        }
    }
}
