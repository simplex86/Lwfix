﻿namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 数学
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 符号
        /// </summary>
        /// <returns></returns>
        public int Sign()
        {
            if (IsNaN()) throw new ArithmeticException("Function does not accept floating point Not-a-Number values.");
            if (IsZero()) return 0;

            return IsNegative() ? -1 : 1;
        }

        /// <summary>
        /// 符号
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Sign(Fixed32 n)
        {
            return n.Sign();
        }
    }
}
