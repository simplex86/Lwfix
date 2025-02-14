namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 数学
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 总位宽
        /// </summary>
        internal const byte HALF_TOTAL_BITS = TOTAL_BITS / 2;

        /// <summary>
        /// 绝对值
        /// </summary>
        /// <returns></returns>
        public Fixed32 Abs()
        {
            if (this == MinValue)
            {
                return MaxValue;
            }

            var mask = value >> 63;
            return From((value + mask) ^ mask);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Fixed32 Floor()
        {
            return From(value & INTEGRAL_MASK);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Fixed32 Ceil()
        {
            return IsFractional() ? (this + One).Floor() : this;
        }

        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <returns></returns>
        public Fixed32 Round()
        {
            var frac = value & FRACTIONAL_MASK;

            if (frac < 0x80000000) return Floor();
            if (frac > 0x80000000) return Ceil();

            return (value & One.value) == 0 ? Floor()
                                            : Ceil();
        }

        /// <summary>
        /// 倒数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Fixed32 Reciprocal()
        {
            return (this == Zero) ? NaN
                                  : One / this;
        }

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
        /// 
        /// </summary>
        /// <returns></returns>
        public Fixed32 Sqrt()
        {
            if (value < 0)
            {
                throw new Exception();
            }

            var val = (ulong)value;
            var bit = 1UL << (TOTAL_BITS - 2);
            while (bit > val) bit >>= 2;

            var res = 0UL;
            for (int i = 0; i < 2; i++)
            {
                while (bit != 0)
                {
                    if (val >= res + bit)
                    {
                        val -= res + bit;
                        res = (res >> 1) + bit;
                    }
                    else
                    {
                        res >>= 1;
                    }
                    bit >>= 2;
                }

                if (i == 0)
                {
                    if (val > (1UL << HALF_TOTAL_BITS) - 1)
                    {
                        val -= res;
                        val = (val << HALF_TOTAL_BITS) - 0x80000000UL;
                        res = (res << HALF_TOTAL_BITS) + 0x80000000UL;
                    }
                    else
                    {
                        val <<= HALF_TOTAL_BITS;
                        res <<= HALF_TOTAL_BITS;
                    }

                    bit = 1UL << (HALF_TOTAL_BITS - 2);
                }
            }

            if (val > res) res++;
            return From((long)res);
        }

        /// <summary>
        /// 自然对数（e为底）
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Fixed32 Log()
        {
            if (value <= 0)
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
            if (value <= 0)
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
