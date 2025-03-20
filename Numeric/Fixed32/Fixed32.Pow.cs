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
        public Fixed32 Pow(int n)
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
        public Fixed32 Pow(Fixed32 n)
        {
            if (rawvalue == 0)
            {
                if (n.rawvalue <= 0) throw new ArgumentException("0 的非正数次幂无定义");
                return Zero;
            }

            if (n.IsFractional())
            {
                if (rawvalue < 0) throw new ArgumentException("负数的非整数次幂无实数解");
                return (n * Log()).Exp(); // m^n = e^(n * ln(m))
            }

            return Pow(n.ToInt());
        }

        /// <summary>
        /// e的幂
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Fixed32 Exp()
        {
            // 处理 x = 0 的快速路径
            if (rawvalue == 0)
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

        /// <summary>
        /// 是否为2的幂
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPowerOfTwo(Fixed32 value)
        {
            if (value.rawvalue <= 0) return false;
            return (value.rawvalue & (value.rawvalue - 1)) == 0;
        }

        /// <summary>
        /// 最接近的2的幂
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 ClosestPowerOfTwo(Fixed32 value)
        {
            // 非正数的情况，返回最小的2^0
            if (value.rawvalue <= 0)
            {
                return One;
            }

            var raw = (ulong)value.rawvalue;
            var pos = TOTAL_BITS - 1;

            // 找到最高有效位的位置
            while (pos >= 0 && (raw & (1UL << pos)) == 0)
            {
                pos--;
            }

            var k = pos - FRACTIONAL_BITS; // 计算指数k=最高位-定点数偏移
            var lower = (long)(1UL << (k + FRACTIONAL_BITS)); // 下界2^k的Q32.32表示

            // 检查上界2^(k+1)是否可表示
            var valid = (k + FRACTIONAL_BITS + 1) < 64;
            var upper = valid ? (long)(1UL << (k + FRACTIONAL_BITS + 1)) : -1;

            // 比较距离选择最近值
            if (valid)
            {
                var diffLower = value.rawvalue - lower;
                var diffUpper = upper - value.rawvalue;

                return (diffLower < diffUpper) ? FromRaw(lower)
                                               : FromRaw(upper);
            }

            return FromRaw(lower); // 上界溢出时返回下界
        }

        /// <summary>
        /// 下一个2的幂
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fixed32 NextPowerOfTwo(Fixed32 value)
        {
            var raw = (ulong)value.rawvalue;
            var pos = TOTAL_BITS - 1;

            // 找到最高有效位的位置
            while (pos >= 0 && (raw & (1UL << pos)) == 0)
            {
                pos--;
            }

            return FromRaw(1 << (pos + 1));
        }
    }
}
