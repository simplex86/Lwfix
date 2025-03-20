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
        private const byte HALF_TOTAL_BITS = TOTAL_BITS / 2;

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

            var mask = rawvalue >> 63;
            return FromRaw((rawvalue + mask) ^ mask);
        }

        /// <summary>
        /// 绝对值
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Abs(Fixed32 n)
        {
            return n.Abs();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Fixed32 Floor()
        {
            return FromRaw(rawvalue & INTEGRAL_MASK);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Floor(Fixed32 n)
        {
            return n.Floor();
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
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Ceil(Fixed32 n)
        {
            return n.Ceil();
        }

        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <returns></returns>
        public Fixed32 Round()
        {
            var frac = rawvalue & FRACTIONAL_MASK;

            if (frac < 0x80000000) return Floor();
            if (frac > 0x80000000) return Ceil();

            return (rawvalue & One.rawvalue) == 0 ? Floor()
                                                  : Ceil();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Round(Fixed32 n)
        {
            return n.Round();
        }

        /// <summary>
        /// 倒数
        /// </summary>
        /// <returns></returns>
        public Fixed32 Reciprocal()
        {
            if (rawvalue == 0)
            {
                throw new DivideByZeroException("Cannot compute reciprocal of zero.");
            }

            //// 1. 处理符号和绝对值
            //var negative = rawvalue < 0;
            //var value = (ulong)(negative ? -rawvalue : rawvalue);

            //// 2. 计算初始近似值（基于整数部分的倒数）
            //var integer = value >> 32; // 提取整数部分的高32位
            //if (integer == 0) integer = 1; // 防止除零

            //// 初始值公式: initial = (2^64 / integer) >> 32 (转换为 Q32.32)
            //ulong quotient = (0x1000000000000000UL / integer) >> 32;
            //var x = FromRaw((long)(quotient >> 32));

            //// 3. 牛顿迭代（3次迭代达到Q32.32精度）
            //x = x * (Two - (this * x)); // 第1次迭代
            //x = x * (Two - (this * x)); // 第2次迭代
            //x = x * (Two - (this * x)); // 第3次迭代

            //return negative ? -x : x;

            // NOTE: 用牛顿迭代误差比较大，还不知道问题在哪里，先用简单的除法实现
            return One / this;
        }

        /// <summary>
        /// 倒数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Reciprocal(Fixed32 n)
        {
            return n.Reciprocal();
        }

        /// <summary>
        /// 开方
        /// </summary>
        /// <returns></returns>
        public Fixed32 Sqrt()
        {
            if (rawvalue < 0)
            {
                throw new Exception();
            }

            var val = (ulong)rawvalue;
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
            return FromRaw((long)res);
        }

        /// <summary>
        /// 开方
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Sqrt(Fixed32 n)
        {
            return n.Sqrt();
        }

        /// <summary>
        /// 符号
        /// </summary>
        /// <returns></returns>
        public int Sign()
        {
            if (rawvalue == 0) return 0;
            return rawvalue < 0 ? -1 : 1;
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

        /// <summary>
        /// 最小值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 Min(Fixed32 a, Fixed32 b)
        {
            return a < b ? a : b;
        }

        /// <summary>
        /// 最小值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Fixed32 Min(Fixed32 a, Fixed32 b, Fixed32 c)
        {
            return Min(a, Min(b, c));
        }

        /// <summary>
        /// 最大值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 Max(Fixed32 a, Fixed32 b)
        {
            return a > b ? a : b;
        }

        /// <summary>
        /// 最大值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Fixed32 Max(Fixed32 a, Fixed32 b, Fixed32 c)
        {
            return Max(a, Max(b, c));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static Fixed32 Clamp(Fixed32 value, Fixed32 min, Fixed32 max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fixed32 Clamp01(Fixed32 value)
        {
            if (value < Fixed32.Zero) return Fixed32.Zero;
            if (value > Fixed32.One) return Fixed32.One;

            return value;
        }

        /// <summary>
        /// Hermite插值
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="tangent1"></param>
        /// <param name="value2"></param>
        /// <param name="tangent2"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Fixed32 Hermite(Fixed32 value1, Fixed32 tangent1, Fixed32 value2, Fixed32 tangent2, Fixed32 amount)
        {
            // All transformed to Fixed32 not to lose precission
            // Otherwise, for high numbers of param:amount the result is NaN instead of Infinity
            if (amount == Fixed32.Zero) return value1;
            if (amount == Fixed32.One) return value2;

            var s1 = amount;
            var s2 = s1 * s1;
            var s3 = s1 * s2;

            var result = (2 * value1 - 2 * value2 + tangent2 + tangent1) * s3 +
                         (3 * value2 - 3 * value1 - 2 * tangent1 - tangent2) * s2 +
                         tangent1 * s1 + value1;

            return result;
        }

        /// <summary>
        /// 线性插值
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Fixed32 Lerp(Fixed32 value1, Fixed32 value2, Fixed32 amount)
        {
            if (value1 == value2 ||
                amount == Fixed32.Zero)
            {
                return value1;
            }

            return value1 + (value2 - value1) * Clamp01(amount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Fixed32 InverseLerp(Fixed32 value1, Fixed32 value2, Fixed32 amount)
        {
            if (value1 == value2) return Fixed32.Zero;
            return Clamp01((amount - value1) / (value2 - value1));
        }

        /// <summary>
        /// 平滑插值
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static Fixed32 SmoothStep(Fixed32 value1, Fixed32 value2, Fixed32 amount)
        {
            amount = Clamp01(amount);
            return Hermite(value1, Fixed32.Zero, value2, Fixed32.Zero, amount);
        }
    }
}
