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
            return Sin(radian + Half_PI);
        }

        /// <summary>
        /// 快速计算余弦
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 FastCos(Fixed32 radian)
        {
            return FastSin(radian + Half_PI);
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

            if (value.rawvalue == 0) return Half_PI;

            var result = Atan(Sqrt(One - value * value) / value);
            return value.rawvalue < 0 ? result + PI : result;
        }
    }
}
