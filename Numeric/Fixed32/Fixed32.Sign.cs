namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 符号
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 符号
        /// </summary>
        /// <returns></returns>
        public int Sign()
        {
            if (IsNaN()) throw new ArithmeticException("Function does not accept Not-a-Number values.");
            if (IsZero()) return 0;

            return IsNegative() ? -1 : 1;
        }

        /// <summary>
        /// 符号
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Sign(Fixed32 n)
        {
            return FMath.Sign(n);
        }

        /// <summary>
        /// 符号是否相同
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool IsSigns(Fixed32 a, Fixed32 b)
        {
            return IsSigns(a.rawvalue, b.rawvalue);
        }
    }
}
