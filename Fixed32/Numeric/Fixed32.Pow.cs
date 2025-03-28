namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 幂
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// n次幂
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Fixed32 Pow(int n)
        {
            var n_rawvalue = Int32ToRaw(n);
            if (PreprocessLog(rawvalue, n_rawvalue, out var r))
            {
                return r;
            }
        
            var m = this;
            if (n < 0)
            {
                m = Reciprocal();
                n = -n;
            }
        
            var c = One;
            while (n > 0)
            {
                if (n % 2 == 1)
                {
                    c *= m;
                }
                m *= m;
                n /= 2;
            }
        
            return c;
        }

        /// <summary>
        /// m的n次幂
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Pow(Fixed32 m, int n)
        {
            return m.Pow(n);
        }

        /// <summary>
        /// n次幂
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Fixed32 Pow(Fixed32 n)
        {
            if (n.IsFractional())
            {
                if (IsNegative()) return NaN;
                return (n * Log()).Exp(); // m^n = e^(n * ln(m))
            }

            return Pow(n.ToInt());
        }

        /// <summary>
        /// m的n次幂
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Pow(Fixed32 m, Fixed32 n)
        {
            return m.Pow(n);
        }

        /// <summary>
        /// 预处理特殊边界值
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static bool PreprocessLog(long m, long n, out Fixed32 r)
        {
            // 有NaN参与的运算，都等于NaN
            if (m == NaN.rawvalue || n == NaN.rawvalue) { r = NaN; return true; }
            // 任何数（非NaN）的0次幂，都等于1
            if (n == Zero.rawvalue) { r = One; return true; }
            // 负数的小数次幂，等于NaN
            if (m < 0 && (n & FRACTIONAL_MASK) != 0) { r = NaN; return true; }
            if (m == Zero.rawvalue) { r = (n < 0) ? PositiveInfinity : Zero; return true; }
            if (m == NegativeOne.rawvalue && (n == PositiveInfinity.rawvalue || n == NegativeInfinity.rawvalue)) { r = One; return true; }
            if (m > NegativeOne.rawvalue && m < One.rawvalue)
            {
                if (n == PositiveInfinity.rawvalue) { r = Zero; return true; }
                if (n == NegativeInfinity.rawvalue) { r = PositiveInfinity; return true; }
            }
            else if (m < NegativeOne.rawvalue || m > One.rawvalue)
            {
                if (n == PositiveInfinity.rawvalue) { r = PositiveInfinity; return true; }
                if (n == NegativeInfinity.rawvalue) { r = Zero; return true; }
            }

            r = Zero;
            return false;
        }

        public Fixed32 Pow2(Fixed32 x)
        {
            var s = x.IsNegative();
            x = x.Abs();

            var integer = x.ToInt();
            x = x.Fractional();

            // 计算 e^r 的泰勒级数展开
            var ter = One;
            var sum = One;
            var idx = 0;
            while (ter != Zero)
            {
                idx++;
                ter = ter * x * Ln2 / new Fixed32(idx);
                sum += ter;
            }

            sum = FromRaw(sum.rawvalue << integer);
            if (s) sum = sum.Reciprocal();

            return sum;
        }

        /// <summary>
        /// 是否为2的幂
        /// </summary>
        /// <returns></returns>
        public bool IsPowerOfTwo()
        {
            if (rawvalue <= 0) return false;
            return (rawvalue & (rawvalue - 1)) == 0;
        }

        /// <summary>
        /// 是否为2的幂
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPowerOfTwo(Fixed32 value)
        {
            return value.IsPowerOfTwo();
        }

        /// <summary>
        /// 最接近的2的幂
        /// </summary>
        /// <returns></returns>
        public Fixed32 ClosestPowerOfTwo()
        {
            // 非正数的情况，返回最小的2^0
            if (rawvalue <= 0)
            {
                return One;
            }

            var raw = (ulong)rawvalue;
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
                var diffLower = rawvalue - lower;
                var diffUpper = upper - rawvalue;

                return (diffLower < diffUpper) ? FromRaw(lower)
                                               : FromRaw(upper);
            }

            return FromRaw(lower); // 上界溢出时返回下界
        }

        /// <summary>
        /// 最接近的2的幂
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fixed32 ClosestPowerOfTwo(Fixed32 value)
        {
            return value.ClosestPowerOfTwo();
        }

        /// <summary>
        /// 下一个2的幂
        /// </summary>
        /// <returns></returns>
        public Fixed32 NextPowerOfTwo()
        {
            var raw = (ulong)rawvalue;
            var pos = TOTAL_BITS - 1;

            // 找到最高有效位的位置
            while (pos >= 0 && (raw & (1UL << pos)) == 0)
            {
                pos--;
            }

            return FromRaw(1 << (pos + 1));
        }

        /// <summary>
        /// 下一个2的幂
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fixed32 NextPowerOfTwo(Fixed32 value)
        {
            return value.NextPowerOfTwo();
        }
    }
}
