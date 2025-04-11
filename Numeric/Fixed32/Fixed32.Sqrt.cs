namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 开方
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 半位宽
        /// </summary>
        private const byte HALF_TOTAL_BITS = TOTAL_BITS / 2;

        /// <summary>
        /// 平方根
        /// </summary>
        /// <returns></returns>
        public Fixed32 Sqrt()
        {
            if (IsNaN()) return NaN;
            if (IsPositiveInfinity()) return PositiveInfinity;
            if (IsZero()) return NaN;

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
        /// 平方根
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Sqrt(Fixed32 n)
        {
            return n.Sqrt();
        }

        /// <summary>
        /// 立方根
        /// </summary>
        /// <returns></returns>
        public Fixed32 Cbrt()
        {
            return Exp(Log() / 3);
        }

        /// <summary>
        /// 立方根
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Cbrt(Fixed32 n)
        {
            return n.Cbrt();
        }
    }
}
