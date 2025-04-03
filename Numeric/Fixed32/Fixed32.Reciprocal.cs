namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 倒数
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /************************************************************************
         * 用牛顿迭代求解，但不知为啥误差比较大，弃用
         * 
        /// <summary>
        /// 倒数
        /// </summary>
        /// <returns></returns>
        public Fixed32 Reciprocal()
        {
            if (PreprocessReciprocal(rawvalue, out var r))
            {
                return r;
            }

            // 处理符号和绝对值
            var negative = rawvalue < 0;
            var value = (ulong)(negative ? -rawvalue : rawvalue);

            // 计算初始近似值（基于整数部分的倒数）
            var integer = value >> 32; // 提取整数部分的高32位
            if (integer == 0) integer = 1; // 防止除零

            // initial = (2^64 / integer) >> 32
            ulong quotient = (0x1000000000000000UL / integer) >> 32;
            var x = FromRaw((long)(quotient >> 32));

            // 牛顿迭代（3次迭代达到Q32.32精度）
            x = x * (Two - (this * x)); // 第1次迭代
            x = x * (Two - (this * x)); // 第2次迭代
            x = x * (Two - (this * x)); // 第3次迭代

            return negative ? -x : x;
        }
        * 
        ************************************************************************/

        /// <summary>
        /// 倒数
        /// </summary>
        /// <returns></returns>
        public Fixed32 Reciprocal()
        {
            if (PreprocessReciprocal(rawvalue, out var r))
            {
                return r;
            }

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
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static bool PreprocessReciprocal(long n, out Fixed32 r)
        {
            if (n.IsNaN()) { r = NaN; return true; }
            if (n.IsZero()) { r = PositiveInfinity; return true; }
            if (n.IsInfinity()) { r = Zero; return true; }

            r = Zero;
            return false;
        }
    }
}
