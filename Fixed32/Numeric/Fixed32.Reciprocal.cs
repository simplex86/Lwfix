namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 倒数
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 倒数
        /// TODO: 用牛顿迭代求解，但不知为啥误差比较大
        /// </summary>
        /// <returns></returns>
        //public Fixed32 Reciprocal()
        //{
        //    if (IsZero())
        //    {
        //        throw new DivideByZeroException("Cannot compute reciprocal of zero.");
        //    }
        //
        //    // 1. 处理符号和绝对值
        //    var negative = rawvalue < 0;
        //    var value = (ulong)(negative ? -rawvalue : rawvalue);
        //
        //    // 2. 计算初始近似值（基于整数部分的倒数）
        //    var integer = value >> 32; // 提取整数部分的高32位
        //    if (integer == 0) integer = 1; // 防止除零
        //
        //    // 初始值公式: initial = (2^64 / integer) >> 32 (转换为 Q32.32)
        //    ulong quotient = (0x1000000000000000UL / integer) >> 32;
        //    var x = FromRaw((long)(quotient >> 32));
        //
        //    // 3. 牛顿迭代（3次迭代达到Q32.32精度）
        //    x = x * (Two - (this * x)); // 第1次迭代
        //    x = x * (Two - (this * x)); // 第2次迭代
        //    x = x * (Two - (this * x)); // 第3次迭代
        //
        //    return negative ? -x : x;
        //}

        /// <summary>
        /// 倒数
        /// </summary>
        /// <returns></returns>
        public Fixed32 Reciprocal()
        {
            if (IsNaN()) return NaN;
            if (IsZero()) return PositiveInfinity;
            if (IsInfinity()) return Zero;

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
    }
}
