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

            var mask = rawvalue >> 63;
            return From((rawvalue + mask) ^ mask);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Fixed32 Floor()
        {
            return From(rawvalue & INTEGRAL_MASK);
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
        /// <param name="value"></param>
        /// <returns></returns>
        public Fixed32 Reciprocal()
        {
            return (this == Zero) ? NaN
                                  : One / this;
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
            return From((long)res);
        }
    }
}
