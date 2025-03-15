﻿namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 正切
    /// </summary>
    public partial struct Fixed32
    {
        private static readonly Fixed32 T3  = FromRaw(1431655765); // 1/3 
        private static readonly Fixed32 T5  = FromRaw(572662306);  // 2/15
        private static readonly Fixed32 T7  = FromRaw(231791886);  // 17/315
        private static readonly Fixed32 T9  = FromRaw(93928738);   // 62/2835
        private static readonly Fixed32 T11 = FromRaw(38067306);   // 1382/155925
        private static readonly Fixed32 T13 = FromRaw(15428072);   // 21844/6081075
        private static readonly Fixed32 T15 = FromRaw(6252761);    // 929569/638512875

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 Tan(Fixed32 radian)
        {
            var normalized = NormalizeRadian(radian, PI);
            var referenced = ReduceRadian4Tan(normalized, out var sign);

            var result = Zero;
            if (referenced < Quarter_PI)
            {
                result = TaylorEvaluate4Tan(referenced);
            }
            else
            {
                var temp = TaylorEvaluate4Tan(referenced - Quarter_PI);
                result = (One + temp) / (One - temp);
            }

            return sign ? -result : result;
        }

        /// <summary>
        /// 泰勒展开在接近π/ 2时误差极大，进一步缩减到[0, π/4]
        /// </summary>
        /// <param name="radian"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        internal static Fixed32 ReduceRadian4Tan(Fixed32 radian, out bool sign)
        {
            sign = false;

            var referenced = radian;
            if (referenced >= Half_PI)
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
        private static Fixed32 TaylorEvaluate4Tan(Fixed32 x)
        {
            var x1 = x;
            var x2 = x1 * x1;
            var x3 = x1 * x2;
            var x5 = x3 * x2;
            var x7 = x5 * x2;
            var x9 = x7 * x2;
            var x11 = x9 * x2;
            var x13 = x11 * x2;
            var x15 = x13 * x2;

            return x1 + x3 * T3 + x5 * T5 + x7 * T7 + x9 * T9 + x11 * T11 + x13 * T13 + x15 * T15;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 FastTan(Fixed32 radian)
        {
            return Zero;
        }
    }
}
