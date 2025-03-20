namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 余切
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        private static readonly Fixed32 K1  = FromRaw(1431655765); // 1/3 
        private static readonly Fixed32 K3  = FromRaw(95443718);  // 1/45
        private static readonly Fixed32 K5  = FromRaw(9089878);  // 2/945

        /// <summary>
        /// 余切
        /// TODO：通过泰勒展开求解，但误差较大
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        //public static Fixed32 Cot(Fixed32 radian)
        //{
        //    var normalized = NormalizeRadian(radian, PI);
        //
        //    if (normalized == Zero) return MaxValue;
        //    if (normalized == PI) return MinValue;
        //    if (normalized == Half_PI) return Zero;
        //
        //    var referenced = ReduceRadian4Cot(normalized, out var sign);
        //    var result = TaylorEvaluate4Cot(referenced);
        //
        //    return sign ? -result : result;
        //}

        /// <summary>
        /// 余切
        /// 注：越接近π误差越大
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 Cot(Fixed32 radian)
        {
            // cot(x) = 1/tan(x)
            var tan = Tan(radian);
            if (tan.rawvalue == 0)
            {
                return (radian.rawvalue < 0) ? MinValue : MaxValue;
            }

            return tan.Reciprocal();
        }

        /// <summary>
        /// 泰勒展开
        /// </summary>
        /// <param name="radian"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        internal static Fixed32 ReduceRadian4Cot(Fixed32 radian, out bool sign)
        {
            sign = false;

            var referenced = radian;
            if (referenced < Half_PI)
            {
                sign = true;
                referenced = PI - referenced;
            }

            return referenced;
        }

        /// <summary>
        /// 泰勒展开估值
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static Fixed32 TaylorEvaluate4Cot(Fixed32 x)
        {
            var x1 = x;
            var x2 = x1 * x1;
            var x3 = x1 * x2;
            var x5 = x3 * x2;

            return x.Pow(-1) - x1 * K1 - x3 * K3 - x5 * K5;
        }

        /// <summary>
        /// 快速计算余切
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 FastCot(Fixed32 radian)
        {
            var tan = FastTan(radian);
            if (tan.rawvalue == 0)
            {
                return (radian.rawvalue < 0) ? MinValue : MaxValue;
            }

            return tan.Reciprocal();
        }
    }
}
