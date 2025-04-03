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
            return n.Sign();
        }
    }
}
