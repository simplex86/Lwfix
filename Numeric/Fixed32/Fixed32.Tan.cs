namespace Lwfix
{
    /// <summary>
    /// 定点数 - 正切
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        private static readonly Fixed32 T3  = FromRaw(1431655765); // 1/3 
        private static readonly Fixed32 T5  = FromRaw(572662306);  // 2/15
        private static readonly Fixed32 T7  = FromRaw(231791886);  // 17/315
        private static readonly Fixed32 T9  = FromRaw(93928738);   // 62/2835
        private static readonly Fixed32 T11 = FromRaw(38067306);   // 1382/155925
        private static readonly Fixed32 T13 = FromRaw(15428072);   // 21844/6081075
        private static readonly Fixed32 T15 = FromRaw(6252761);    // 929569/638512875
        private static readonly Fixed32 T17 = FromRaw(2534149);    // 
        private static readonly Fixed32 T19 = FromRaw(1027052);    // 

        /// <summary>
        /// 正切
        /// 注：将radian规范化到[-π/2, π/2]范围内，其值越接近(±π/2)误差越大。
        /// 经测试，与(±π/2)差值小于0.0017时，误差将大于0.1
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 Tan(Fixed32 radian)
        {
            if (PreprocessTan(radian, out var r))
            {
                return r;
            }

            var normalized = NormalizeRadian(radian, PI);
            var referenced = ReduceRadian4Tan(normalized, out var sign);

            if (referenced == Zero)       return Zero;
            if (referenced == Half_PI)    return sign ? MinValue : MaxValue;
            if (referenced == Quarter_PI) return sign ? NegativeOne : One;

            var result = Zero;
            if (referenced < Quarter_PI)
            {
                result = TaylorEvaluate4Tan(referenced);
            }
            else
            {
                var temp = TaylorEvaluate4Tan(Half_PI - referenced);
                result = temp.Reciprocal();
            }

            return sign ? -result : result;
        }

        /// <summary>
        /// 泰勒展开
        /// </summary>
        /// <param name="radian"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        internal static Fixed32 ReduceRadian4Tan(Fixed32 radian, out bool sign)
        {
            sign = false;

            var referenced = radian;
            if (referenced > Half_PI)
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
            var x1  = x;
            var x2  = x1 * x1;
            var x3  = x1 * x2;
            var x5  = x3 * x2;
            var x7  = x5 * x2;
            var x9  = x7 * x2;
            var x11 = x9 * x2;
            var x13 = x11 * x2;
            var x15 = x13 * x2;
            var x17 = x15 * x2;
            var x19 = x17 * x2;

            return x1        + 
                   x3  * T3  + 
                   x5  * T5  + 
                   x7  * T7  + 
                   x9  * T9  + 
                   x11 * T11 + 
                   x13 * T13 + 
                   x15 * T15 + 
                   x17 * T17 + 
                   x19 * T19;
        }

        /// <summary>
        /// 快速计算正切
        /// 注：将radian规范化到[-π/2, π/2]范围内，其值越接近(±π/2)误差越大。
        /// 误差大于Tan函数，但计算速度比Tan函数更快
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 FastTan(Fixed32 radian)
        {
            if (PreprocessTan(radian, out var r))
            {
                return r;
            }

            var normalized = NormalizeRadian(radian, PI);
            var referenced = ReduceRadian4Tan(normalized, out var sign);

            if (referenced == Zero)       return Zero;
            if (referenced == Half_PI)    return sign ? MinValue : MaxValue;
            if (referenced == Quarter_PI) return sign ? NegativeOne : One;

            var index = referenced * (TanLut.Length - 1) / Half_PI;
            var round = index.Round();
            var error = index - round;

            var nearest1 = FromRaw(TanLut[(int)round]);
            var nearest2 = FromRaw(TanLut[(int)round + error.Sign()]);

            var delta = error * (nearest1 - nearest2).Abs();
            var interpolated = nearest1.rawvalue + delta.rawvalue;
            if (sign) interpolated = -interpolated;

            return FromRaw(interpolated);
        }

        /// <summary>
        /// 预处理特殊边界值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static bool PreprocessTan(Fixed32 radian, out Fixed32 r)
        {
            if (radian.IsNaN() ||
                radian.IsPositiveInfinity() ||
                radian.IsNegativeInfinity())
            {
                r = NaN;
                return true;
            }

            r = Zero;
            return false;
        }

        /// <summary>
        /// 反余切
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fixed32 Atan(Fixed32 z)
        {
            if (z.IsZero()) return Zero;

            // Force positive values for argument: Atan(-z) = -Atan(z).
            var neg = z.IsNegative();
            if (neg) z = -z;

            var invert = z > One;
            if (invert) z = z.Reciprocal();

            var result = One;
            var term = One;
            var two = Two;
            var three = new Fixed32(3);

            var sq1 = z * z;
            var sq2 = sq1 * two;
            var sqp1 = sq1 + One;
            var sqp2 = sqp1 * two;
            var dividend = sq2;
            var divisor = sqp1 * three;

            for (var i = 2; i < 30; ++i)
            {
                term *= dividend / divisor;
                result += term;

                dividend += sq2;
                divisor += sqp2;

                if (term.IsZero()) break;
            }

            result = result * z / sqp1;
            if (invert) result = Half_PI - result;

            return neg ? -result : result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Fixed32 Atan2(Fixed32 y, Fixed32 x)
        {
            var yl = y.rawvalue;
            var xl = x.rawvalue;

            if (xl == 0)
            {
                if (yl > 0)  return Half_PI;
                if (yl == 0) return Zero;
                return -Half_PI;
            }
            
            var z = y / x;
            var sm = TPN2 * 28;
            // Deal with overflow
            if (One + sm * z * z == MaxValue)
            {
                return y < Zero ? -Half_PI : Half_PI;
            }

            var atan = Zero;
            if (Abs(z) < One)
            {
                atan = z / (One + sm * z * z);
                if (xl < 0) return (yl < 0) ? atan - PI : atan + PI;
            }
            else
            {
                atan = Half_PI - z / (z * z + sm);
                if (yl < 0) return atan - PI;
            }

            return atan;
        }
    }
}
