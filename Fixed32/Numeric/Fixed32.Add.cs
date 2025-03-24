﻿namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 加法
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(Fixed32 a, int b)
        {
            // NaN加任何数，得NaN
            if (a.IsNaN()) return NaN;
            // 正无穷加任何数，得正无穷
            if (a.IsPositiveInfinity()) return PositiveInfinity;
            // 负无穷加任何数，得负无穷
            if (a.IsNegativeInfinity()) return NegativeInfinity;
            // 最大值加正数，得正无穷
            if (a.IsMax() && b > 0) return PositiveInfinity;
            // 最小值加负数，得负无穷
            if (a.IsMin() && b < 0) return NegativeInfinity;

            //return FromRaw(a.rawvalue + ((long)b << INTEGRAL_BITS));
            var result = Add(a.rawvalue, ((long)b) << INTEGRAL_BITS, out var _);
            return FromRaw(result);
        }

        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(int a, Fixed32 b)
        {
            return b + a;
        }

        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator +(Fixed32 a, Fixed32 b)
        {
            // NaN加任何数，得NaN
            if (a.IsNaN() || b.IsNaN()) return NaN;
            // 正负无穷相加，得NaN
            if (a.IsPositiveInfinity() && b.IsNegativeInfinity()) return NaN;
            if (a.IsNegativeInfinity() && b.IsPositiveInfinity()) return NaN;
            // 最大值加正数，得最大值
            if (a.IsMax() && b.IsPositive()) return MaxValue;
            // 最小值加负数，得最小值
            if (a.IsMin() && b.IsNegative()) return MinValue;
            // 正无穷加任何数，得正无穷
            if (a.IsPositiveInfinity() || b.IsPositiveInfinity()) return PositiveInfinity;
            // 负无穷加任何数，得负无穷
            if (a.IsNegativeInfinity() || b.IsNegativeInfinity()) return NegativeInfinity;

            var result = Add(a.rawvalue, b.rawvalue, out var _);
            return FromRaw(result);
        }

        /// <summary>
        /// 相加并检查溢出
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="overflow"></param>
        /// <returns></returns>
        private static long Add(long a, long b, out bool overflow)
        {
            overflow = false;
            var r = OverflowAdd(a, b, ref overflow);

            if (!overflow)
            {
                if (r < MinValue.rawvalue) r = NegativeInfinity.rawvalue;
                if (r > MaxValue.rawvalue) r = PositiveInfinity.rawvalue;
            }

            return r;
        }

        /// <summary>
        /// 计算加法，并获知结果是否溢出
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="overflow"></param>
        /// <returns></returns>
        private static long OverflowAdd(long a, long b, ref bool overflow)
        {
            var r = a + b;
            // a + b overflows if sign(a) ^ sign(b) != sign(r)
            overflow |= ((a ^ b ^ r) & long.MinValue) != 0;

            return r;
        }
    }
}
