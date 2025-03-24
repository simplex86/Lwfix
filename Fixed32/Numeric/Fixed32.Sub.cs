namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 减法
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(Fixed32 a, int b)
        {
            // NaN减任何数，得NaN
            if (a.IsNaN()) return NaN;
            // 正无穷减任何数，得正无穷
            if (a.IsPositiveInfinity()) return PositiveInfinity;
            // 负无穷减任何数，得负无穷
            if (a.IsNegativeInfinity()) return NegativeInfinity;
            // 最小值减正数，得最小值
            if (a.IsMin() && b > 0) return NegativeInfinity;
            // 最大值减负数，得最大值
            if (a.IsMax() && b < 0) return PositiveInfinity;

            //return FromRaw(a.rawvalue - ((long)b <<  INTEGRAL_BITS));
            var result = Sub(a.rawvalue, (long)b << INTEGRAL_BITS, out var _);
            return FromRaw(result);
        }

        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(int a, Fixed32 b)
        {
            // 任何数减NaN，得NaN
            if (b.IsNaN()) return NaN;
            // 任何数减正无穷，得负无穷
            if (b.IsPositiveInfinity()) return NegativeInfinity;
            // 任何数减负无穷，得正无穷
            if (b.IsNegativeInfinity()) return PositiveInfinity;
            // 正数减最小值，得正无穷
            if (b.IsMin() && a > 0) return PositiveInfinity;
            // 负数减最大值，得负无穷
            if (b.IsMax() && a < 0) return NegativeInfinity;

            //return FromRaw(((long)a << INTEGRAL_BITS) - b.rawvalue);
            var result = Sub((long)a << INTEGRAL_BITS, b.rawvalue, out var _);
            return FromRaw(result);
        }

        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(Fixed32 a, Fixed32 b)
        {
            // NaN减任何数，得NaN
            if (a.IsNaN() || b.IsNaN()) return NaN;
            // 负无穷减负无穷，得NaN
            if (a.IsNegativeInfinity() && b.IsNegativeInfinity()) return NaN;
            // 负无穷减任何数，得负无穷
            if (a.IsNegativeInfinity()) return NegativeInfinity;
            // 任何数减负无穷，得正无穷
            if (b.IsNegativeInfinity()) return PositiveInfinity;

            var result = Sub(a.rawvalue, b.rawvalue, out var _);
            return FromRaw(result);
        }

        /// <summary>
        /// 相反数
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(Fixed32 n)
        {
            if (n == NaN) return NaN;
            if (n == PositiveInfinity) return NegativeInfinity;
            if (n == NegativeInfinity) return PositiveInfinity;

            return FromRaw(-n.rawvalue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static long Sub(long a, long b, out bool overflow)
        {
            var r = a - b;

            overflow = false;
            if ((a ^ b) < 0) // 符号不同
            {
                overflow = (a > 0 && r < 0) || (a < 0 && r > 0);// 相加后的符号是否改变（溢出标志）
                if (overflow)
                {
                    return (a < 0) ? NegativeInfinity.rawvalue
                                   : PositiveInfinity.rawvalue;
                }
            }

            if (!overflow)
            {
                if (r < MinValue.rawvalue) r = NegativeInfinity.rawvalue;
                if (r > MaxValue.rawvalue) r = PositiveInfinity.rawvalue;
            }

            return r;
        }
    }
}
