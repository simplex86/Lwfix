namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 对数
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /************************************************************************
         * 精度较低，弃用
         * 
        /// <summary>
        /// 自然对数（e为底）
        /// </summary>
        /// <returns></returns>
        public Fixed32 Log()
        {
            if (ProprocessLog(rawvalue, out var r))
            {
                return r;
            }

            // 1. 归一化到 [1, 2) 并记录指数
            var exponent = 0;
            var mantissa = this;

            while (mantissa >= Two)
            {
                mantissa = mantissa / Two;
                exponent++;
            }
            while (mantissa < One)
            {
                mantissa = mantissa * Two;
                exponent--;
            }
            var e = Ln2 * exponent;

            // 2. 计算 ln(mantissa) 的泰勒级数展开
            var x = mantissa - One;
            var p = x;
            var c = x;

            for (int i = 2; i < 300; i++)
            {
                p = p * x;
                c = (i % 2 == 0) ? c - p / i
                                 : c + p / i;
            }

            // 3. ln(n) = ln(mantissa) + exponent * ln(2)
            return c + e;
        }
        * 
        ************************************************************************/

        /// <summary>
        /// 自然对数（e为底）
        /// </summary>
        /// <returns></returns>
        public Fixed32 Log()
        {
            if (ProprocessLog(rawvalue, out var r))
            {
                return r;
            }

            return Log2() * Ln2;
        }
        /// <summary>
        /// 自然对数（e为底）
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Log(Fixed32 n)
        {
            return n.Log();
        }

        /************************************************************************
         * 精度较低，弃用
         * 
        /// <summary>
        /// 以2为底的对数
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Fixed32 Log2()
        {
            if (ProprocessLog(rawvalue, out var r))
            {
                return r;
            }

            // 1. 归一化到 [1, 2) 并记录指数
            var exponent = 0;
            var mantissa = this;

            // 2.计算 ln(mantissa) 的泰勒级数展开
            while (mantissa >= Two)
            {
                mantissa = mantissa / Two;
                exponent++;
            }
            while (mantissa < One)
            {
                mantissa = mantissa * Two;
                exponent--;
            }

            // Now mantissa is in [1, 2)
            var x = mantissa - One;
            var p = x;
            var c = x;

            for (int i = 2; i < 300; i++)
            {
                p = p * x;
                c = (i % 2 == 0) ? c - p / i
                                 : c + p / i;
            }
            c = c / Ln2;

            return c + exponent;
        }
        * 
        ************************************************************************/

        /// <summary>
        /// 以2为底的对数
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Fixed32 Log2()
        {
            if (ProprocessLog(rawvalue, out var r))
            {
                return r;
            }

            var b = 1L << (FRACTIONAL_BITS - 1);
            var y = 0L;

            var rawX = rawvalue;
            while (rawX < One.rawvalue)
            {
                rawX <<= 1;
                y -= One.rawvalue;
            }

            while (rawX >= Two.rawvalue)
            {
                rawX >>= 1;
                y += One.rawvalue;
            }

            var z = FromRaw(rawX);

            for (int i = 0; i < FRACTIONAL_BITS; i++)
            {
                z = z * z;
                if (z.rawvalue >= Two.rawvalue)
                {
                    z = FromRaw(z.rawvalue >> 1);
                    y += b;
                }
                b >>= 1;
            }

            return FromRaw(y);
        }

        /// <summary>
        /// 以2为底的对数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Log2(Fixed32 n)
        {
            return n.Log2();
        }

        /// <summary>
        /// 以10为底的对数
        /// </summary>
        /// <returns></returns>
        public Fixed32 Log10()
        {
            return Log() / Ln10;
        }

        /// <summary>
        /// 以10为底的对数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Log10(Fixed32 n)
        {
            return n.Log10();
        }

        /// <summary>
        /// 预处理特殊边界值
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private bool ProprocessLog(long n, out Fixed32 r)
        {
            if (n < 0 || n == NaN.rawvalue) { r = NaN; return true; }
            if (n == 0) { r = NegativeInfinity; return true; }
            if (n == PositiveInfinity.rawvalue) { r = PositiveInfinity; return true; }

            r = Zero;
            return false;
        }
    }
}
