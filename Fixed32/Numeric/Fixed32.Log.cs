namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 对数
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 自然对数（e为底）
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Fixed32 Log()
        {
            if (rawvalue <= 0)
                throw new ArgumentException("自然对数对非正数无定义");

            // 1. 归一化到 [1, 2) 并记录指数
            var exponent = 0;
            var mantissa = this;
            var two = One + One;

            while (mantissa >= two)
            {
                mantissa = mantissa / two;
                exponent++;
            }
            while (mantissa < One)
            {
                mantissa = mantissa * two;
                exponent--;
            }
            var e = LN2 * new Fixed32(exponent);

            // 2. 计算 ln(mantissa) 的泰勒级数展开
            var x = mantissa - One;
            var p = x;
            var r = x;

            for (int i = 2; i < 50; i++)
            {
                p = p * x;
                r = (i % 2 == 0) ? r - p / new Fixed32(i)
                                 : r + p / new Fixed32(i);
            }

            // 3. ln(n) = ln(mantissa) + exponent * ln(2)
            return r + e;
        }

        /// <summary>
        /// 以2为底的对数
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Fixed32 Log2()
        {
            if (rawvalue <= 0)
            {
                throw new ArgumentException("Log2 is undefined for non-positive values.");
            }

            // 1. 归一化到 [1, 2) 并记录指数
            var exponent = 0;
            var mantissa = this;
            var two = One + One;
            var one = One;

            // 2.计算 ln(mantissa) 的泰勒级数展开
            while (mantissa >= two)
            {
                mantissa = mantissa / two;
                exponent++;
            }
            while (mantissa < one)
            {
                mantissa = mantissa * two;
                exponent--;
            }
            var e = new Fixed32(exponent);

            // Now mantissa is in [1, 2)
            var x = mantissa - One;
            var p = x;
            var r = x;

            for (int i = 2; i < 50; i++)
            {
                p = p * x;
                r = (i % 2 == 0) ? r - p / new Fixed32(i)
                                 : r + p / new Fixed32(i);
            }
            r = r / LN2;

            return r + e;
        }

        /// <summary>
        /// 以10为底的对数
        /// </summary>
        /// <returns></returns>
        public Fixed32 Log10()
        {
            return Log() / LN10;
        }
    }
}
