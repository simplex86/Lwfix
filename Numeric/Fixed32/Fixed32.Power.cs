namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 幂
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// n次方
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Fixed32 Power(int n)
        {
            if (n == 0 || this == One)
            {
                return One;
            }
            if (this == Zero)
            {
                return n < 0 ? NaN : Zero;
            }

            var m = this;
            if (n < 0)
            {
                m = Reciprocal();
                n = -n;
            }

            var r = One;
            while (n > 0)
            {
                if (n % 2 == 1)
                {
                    r *= m;
                }
                m *= m;
                n /= 2;
            }

            return r;
        }

        /// <summary>
        /// n次方
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Fixed32 Power(Fixed32 n)
        {
            if (value == 0)
            {
                if (n.value <= 0) throw new ArgumentException("0 的非正数次幂无定义");
                return Zero;
            }

            if (n.IsFractional())
            {
                if (value < 0) throw new ArgumentException("负数的非整数次幂无实数解");
                return (n * Log()).Exp(); // m^n = e^(n * ln(m))
            }

            return Power(n.ToInt());
        }

        /// <summary>
        /// e的幂
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Fixed32 Exp()
        {
            // 处理 x = 0 的快速路径
            if (value == 0)
            {
                return One;
            }

            // 分解 x = k * ln(2) + r，其中 |r| ≤ 0.5 * ln(2)
            var k = (this / LN2).Round();
            var r = this - k * LN2;

            // 计算 e^r 的泰勒级数展开
            var ter = One;
            var sum = One;
            for (int i = 1; i < 50; i++) // 迭代多次确保精度
            {
                ter = ter * r / new Fixed32(i);
                sum += ter;
            }

            var t = k.ToInt();
            var pow = (t >= 0) ? new Fixed32(1 << t)
                               : One / new Fixed32(1 << -t);

            // e^x = e^(k * ln(2) + r) = 2^k * e^r
            return pow * sum;
        }
    }
}
