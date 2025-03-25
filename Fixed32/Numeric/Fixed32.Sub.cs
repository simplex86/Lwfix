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
            // 零减去任何数，等于相反数
            if (a.IsZero()) return new Fixed32(-b);
            // 任何数减去零，等于该数本身
            if (b.IsZero()) return a;
            // 正无穷减任何数，得正无穷
            if (a.IsPositiveInfinity()) return PositiveInfinity;
            // 负无穷减任何数，得负无穷
            if (a.IsNegativeInfinity()) return NegativeInfinity;
            // 最小值减正数，得最小值
            if (a.IsMin() && b.IsPositive()) return NegativeInfinity;
            // 最大值减负数，得最大值
            if (a.IsMax() && b.IsNegative()) return PositiveInfinity;

            return Sub(a.rawvalue, (long)b << INTEGRAL_BITS, out var _);
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
            // 零减去任何数，等于相反数
            if (a.IsZero()) return -b;
            // 任何数减去零，等于该数本身
            if (b.IsZero()) return new Fixed32(a);
            // 任何数减正无穷，得负无穷
            if (b.IsPositiveInfinity()) return NegativeInfinity;
            // 任何数减负无穷，得正无穷
            if (b.IsNegativeInfinity()) return PositiveInfinity;
            // 正数减最小值，得正无穷
            if (b.IsMin() && a.IsPositive()) return PositiveInfinity;
            // 负数减最大值，得负无穷
            if (b.IsMax() && a.IsNegative()) return NegativeInfinity;

            return Sub((long)a << INTEGRAL_BITS, b.rawvalue, out var _);
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
            // 零减去任何数，等于相反数
            if (a.IsZero()) return -b;
            // 零减去任何数，都等于该数本身
            if (b.IsZero()) return a;
            // 正无穷减正无穷，得NaN
            if (a.IsPositiveInfinity() && b.IsPositiveInfinity()) return NaN;
            // 负无穷减负无穷，得NaN
            if (a.IsNegativeInfinity() && b.IsNegativeInfinity()) return NaN;
            // 负无穷减任何数 或 任何数减正无穷，得负无穷
            if (a.IsNegativeInfinity() || b.IsPositiveInfinity()) return NegativeInfinity;
            // 正无穷减任何数 或 任何数减负无穷，得正无穷
            if (a.IsPositiveInfinity() || b.IsNegativeInfinity()) return PositiveInfinity;
            // 正数减最小值，得正无穷
            if (b.IsMin() && a.IsPositive()) return PositiveInfinity;
            // 负数减最大值，得负无穷
            if (b.IsMax() && a.IsNegative()) return NegativeInfinity;

            return Sub(a.rawvalue, b.rawvalue, out var _);
        }

        /// <summary>
        /// 相反数
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator -(Fixed32 n)
        {
            if (n == NaN) return NaN;
            if (n == Zero) return Zero;
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
        private static Fixed32 Sub(long a, long b, out bool overflow)
        {
            overflow = false;
            var r = OverflowSub(a, b, ref overflow);

            if (overflow)
            {
                if (a > 0) return PositiveInfinity;
                return NegativeInfinity;
            }
            else
            {
                if (r < MinValue.rawvalue) return NegativeInfinity;
                if (r > MaxValue.rawvalue) return PositiveInfinity;
            }

            return FromRaw(r);
        }

        /// <summary>
        /// 计算减法，并获知结果是否溢出
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="overflow"></param>
        /// <returns></returns>
        private static long OverflowSub(long a, long b, ref bool overflow)
        {
            var r = a - b;
            overflow |= (((a ^ b) & (a ^ r)) & long.MinValue) != 0;

            return r;
        }
    }
}
