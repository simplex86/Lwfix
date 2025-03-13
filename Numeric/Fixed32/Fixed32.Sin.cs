namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 正弦
    /// </summary>
    public partial struct Fixed32
    {
        private static readonly Fixed32 C3  = From(715827882); // 1/(3!) 
        private static readonly Fixed32 C5  = From(35791394);  // 1/(5!) 
        private static readonly Fixed32 C7  = From(852176);    // 1/(7!) 
        private static readonly Fixed32 C9  = From(11836);     // 1/(9!) 
        private static readonly Fixed32 C11 = From(108);       // 1/(11!)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 Sin(Fixed32 radian)
        {
            var normalized = NormalizeRadian(radian);
            var sign = ToFirstQuadrant(normalized, out var reference);
            var result = TaylorEvaluate(reference);

            return sign ? -result : result;
        }

        /// <summary>
        /// 泰勒展开在接近2π时误差极大，进一步利用对称性缩减到[0, π/2]
        /// </summary>
        /// <param name="radian"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        internal static bool ToFirstQuadrant(Fixed32 radian, out Fixed32 reference)
        {
            var sign = false;
            reference = Zero;

            var quadrant = (radian.value << 1) / PI.value;
            switch (quadrant)
            {
                case 0: // 第一象限 [0, π/2)
                    reference = radian;
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

            return sign;
        }

        /// <summary>
        /// 泰勒展开估值
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static Fixed32 TaylorEvaluate(Fixed32 x)
        {
            var x1  = x;
            var x2  = x1 * x1;
            var x3  = x1 * x2;
            var x5  = x3 * x2;
            var x7  = x5 * x2;
            var x9  = x7 * x2;
            var x11 = x9 * x2;

            return x - x3 * C3 + x5 * C5 - x7 * C7 + x9 * C9 - x11 * C11;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 FastSin(Fixed32 radian)
        {
            var normalized = NormalizeRadian(radian);
            var sign = ToFirstQuadrant(normalized, out var reference);

            //var index = normalized.value >> 15;
            //if (index >= SinLut.Length) index = SinLut.Length - 1;
            //if (normalized >= Half_PI)  index = SinLut.Length - 1 - index;
            var index = reference.value >> 15;

            var nearest = SinLut[index];
            if (sign) nearest = -nearest;

            return From(nearest);
        }
    }
}
