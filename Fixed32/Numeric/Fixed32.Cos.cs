namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 余弦
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 余弦
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 Cos(Fixed32 radian)
        {
            if (PreprocessSin(radian, out var r))
            {
                return r;
            }

            return Sin(radian + Half_PI);
        }

        /// <summary>
        /// 快速计算余弦
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 FastCos(Fixed32 radian)
        {
            if (PreprocessSin(radian, out var r))
            {
                return r;
            }

            return FastSin(radian + Half_PI);
        }

        /// <summary>
        /// 预处理特殊边界值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static bool PreprocessCos(Fixed32 radian, out Fixed32 r)
        {
            if (radian == NaN ||
                radian == PositiveInfinity ||
                radian == NegativeInfinity)
            {
                r = NaN;
                return true;
            }

            r = Zero;
            return false;
        }

        /// <summary>
        /// 反余弦
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fixed32 Acos(Fixed32 value)
        {
            if (value < NegativeOne || value > One)
            {
                throw new ArgumentOutOfRangeException("Must between NegativeOne and One", "value");
            }

            if (value.IsZero()) return Half_PI;

            var result = Atan(Sqrt(One - value * value) / value);
            return value.IsNegative() ? result + PI : result;
        }
    }
}
