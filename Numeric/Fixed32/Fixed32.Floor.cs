namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 数学
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Fixed32 Floor()
        {
            if (IsNaN()) return NaN;
            if (IsNegativeInfinity()) return NegativeInfinity;

            return FromRaw(rawvalue & INTEGRAL_MASK);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Floor(Fixed32 n)
        {
            return FMath.Floor(n);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int FloorToInt()
        {
            return Floor().ToInt();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int FloorToInt(Fixed32 n)
        {
            return FMath.FloorToInt(n);
        }
    }
}
