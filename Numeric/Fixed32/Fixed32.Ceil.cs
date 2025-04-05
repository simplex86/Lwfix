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
        public Fixed32 Ceil()
        {
            if (IsNaN()) return NaN;
            if (IsPositiveInfinity()) return PositiveInfinity;

            return IsFractional() ? (this + One).Floor() : this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Ceil(Fixed32 n)
        {
            return FMath.Ceil(n);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int CeilToInt()
        {
            return Ceil().ToInt();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int CeilToInt(Fixed32 n)
        {
            return FMath.CeilToInt(n);
        }
    }
}
