namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 正弦
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        private static readonly Fixed32 C3  = FromRaw(715827882); // 1/(3!) 
        private static readonly Fixed32 C5  = FromRaw(35791394);  // 1/(5!) 
        private static readonly Fixed32 C7  = FromRaw(852176);    // 1/(7!) 
        private static readonly Fixed32 C9  = FromRaw(11836);     // 1/(9!) 
        private static readonly Fixed32 C11 = FromRaw(108);       // 1/(11!)

        /// <summary>
        /// 正弦
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 Sin(Fixed32 radian)
        {
            var normalized = NormalizeRadian(radian);
            var referenced = ReduceRadian4Sin(normalized, out var sign);
            var result = TaylorEvaluate4Sin(referenced);

            return sign ? -result : result;
        }

        /// <summary>
        /// 泰勒展开在接近2π时误差极大，进一步利用对称性缩减到[0, π/2]
        /// </summary>
        /// <param name="radian"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        internal static Fixed32 ReduceRadian4Sin(Fixed32 radian, out bool sign)
        {
            sign = false;

            var reference = radian;
            var quadrant = (radian.rawvalue << 1) / PI.rawvalue;

            switch (quadrant)
            {
                case 0: // 第一象限 [0, π/2)
                    break;
                case 1: // 第二象限 [π/2, π)
                    reference = PI - radian;
                    break;
                case 2: // 第三象限 [π, 3π/2)
                    reference = radian - PI;
                    sign = true;
                    break;
                case 3: // 第四象限 [3π/2, 2π)
                    reference = Two_PI - radian;
                    sign = true;
                    break;
                default:
                    reference = Zero;
                    break;
            }

            return reference;
        }

        /// <summary>
        /// 泰勒展开估值
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static Fixed32 TaylorEvaluate4Sin(Fixed32 x)
        {
            var x1  = x;
            var x2  = x1 * x1;
            var x3  = x1 * x2;
            var x5  = x3 * x2;
            var x7  = x5 * x2;
            var x9  = x7 * x2;
            var x11 = x9 * x2;

            return x1 - x3 * C3 + x5 * C5 - x7 * C7 + x9 * C9 - x11 * C11;
        }

        /// <summary>
        /// 快速计算正弦
        /// 注：误差大于Sin函数
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 FastSin(Fixed32 radian)
        {
            var normalized = NormalizeRadian(radian);
            var referenced = ReduceRadian4Sin(normalized, out var sign);

            var index = referenced.rawvalue >> 15;
            if (index >= SinLut.Length) index = SinLut.Length - 1;

            var nearest = SinLut[index];
            if (sign) nearest = -nearest;

            return FromRaw(nearest);
        }

        /// <summary>
        /// 反正弦
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fixed32 Asin(Fixed32 value)
        {
            return Half_PI - Acos(value);
        }
    }
}
