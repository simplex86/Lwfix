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
            var frac = rawvalue & FRACTIONAL_MASK;

            if (frac < 0x80000000) return Floor();
            if (frac > 0x80000000) return Ceil();

            return (rawvalue & One.rawvalue) == 0 ? Floor()
                                                  : Ceil();
        }

        /// <summary>
        /// 倒数
        /// </summary>
        /// <returns></returns>
        public Fixed32 Reciprocal()
        {
            if (this == Zero)
            {
                throw new DivideByZeroException("Cannot compute reciprocal of zero.");
            }

            return One / this;

            //if (rawvalue == 0)
            //    throw new DivideByZeroException("Cannot compute reciprocal of zero.");

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
        }

        /// <summary>
        /// 
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
    }
}
