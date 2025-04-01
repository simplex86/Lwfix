namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - e的幂
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// e的幂
        /// </summary>
        /// <returns></returns>
        public Fixed32 Exp()
        {
            if (PreprocessExp(rawvalue, out var r))
            {
                return r;
            }

            // 分解 x = k * ln(2) + r，其中 |r| ≤ 0.5 * ln(2)
            var k = (this / Ln2).Round();
            var residual = this - k * Ln2;

            // 计算 e^r 的泰勒级数展开
            var ter = One;
            var sum = One;
            var idx = 0;
            while (ter != Zero) // 迭代多次确保精度
            {
                idx++;
                ter = ter * residual / idx;
                sum += ter;
            }

            var s = k.IsNegative();
            var t = k.Abs().ToInt();

            var pow = new Fixed32(1 << t);
            if (s) pow = pow.Reciprocal();

            // e^x = e^(k * ln(2) + r) = 2^k * e^r
            return pow * sum;
        }

        /// <summary>
        /// e的m次幂
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static Fixed32 Exp(Fixed32 m)
        {
            return m.Exp();
        }

        /// <summary>
        /// 预处理特殊边界值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static bool PreprocessExp(long n, out Fixed32 r)
        {
            if (n == NaN.rawvalue) { r = NaN; return true; }
            if (n == Zero.rawvalue) { r = One; return true; }
            if (n == PositiveInfinity.rawvalue) { r = PositiveInfinity; return true; }
            if (n == NegativeInfinity.rawvalue) { r = Zero; return true; }

            r = Zero;
            return false;
        }
    }
}
