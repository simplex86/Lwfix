namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 数学
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 是否为小数
        /// </summary>
        /// <returns></returns>
        internal bool IsFractional()
        {
            return (value & FRACTIONAL_MASK) != 0;
        }

        /// <summary>
        /// 获取前导零的数量
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        internal static int GetLeadingZeroCount(ulong n)
        {
            if (n == 0) return 64;

            var count = 0;
            {
                while ((n & 0xF000000000000000) == 0) { count += 4; n <<= 4; }
                while ((n & 0x8000000000000000) == 0) { count += 1; n <<= 1; }
            }
            return count;
        }

        /// <summary>
        /// 获取尾部零的数量
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        internal static int GetTrailingZeroCount(ulong n)
        {
            if (n == 0) return 64;

            var count = 0;
            {
                while ((n & 0xF) == 0) { count += 4; n >>= 4; }
                while ((n & 0x1) == 0) { count += 1; n >>= 1; }
            }
            return count;
        }

        /// <summary>
        /// 两个数符号是否相同
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static bool IsSameSign(long a, long b)
        {
            return ((a ^ b) & SIGN_BIT_MASK) == 0;
        }

        /// <summary>
        /// 角度规范化到[-2π, 2π]
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        internal static Fixed32 NormalizeRadian(Fixed32 radian)
        {
            // 周期数：n = radian / (2π)
            var cycles = radian.value / Two_PI.value;
            // 减去整数周期：radian = radian - n * 2π
            return From(radian.value - cycles * Two_PI.value);
        }

        /// <summary>
        /// 象限映射和符号处理
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        internal static bool ToQuadrant(Fixed32 angle, out Fixed32 reference)
        {
            // 确定象限
            var quadrant = (angle.value << 1) / PI.value;

            // 计算参考角
            var refvalue = angle.value;
            var sign = true;

            switch (quadrant)
            {
                case 0: // 第一象限 [0, π/2)
                    sign = false;
                    break;
                case 1: // 第二象限 [π/2, π)
                    refvalue = PI.value - refvalue;
                    sign = true;
                    break;
                case 2: // 第三象限 [π, 3π/2)
                    refvalue -= PI.value;
                    sign = true;
                    break;
                case 3: // 第四象限 [3π/2, 2π)
                    refvalue = Two_PI.value - refvalue;
                    sign = false;
                    break;
            }

            reference = From(refvalue);
            return sign;
        }

        /// <summary>
        /// 角度转弧度
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static Fixed32 DegreeToRadian(Fixed32 degree)
        {
            return (degree / 180) * PI;
        }

        /// <summary>
        /// 弧度转角度
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 RadianToDegree(Fixed32 radian)
        {
            return (radian / PI) * 180;
        }
    }
}
