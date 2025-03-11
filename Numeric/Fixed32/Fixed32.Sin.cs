namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 正弦
    /// </summary>
    public partial struct Fixed32
    {
        private static readonly Fixed32 C1 = From(-0x155555555); // -1/6    -0.1666667
        private static readonly Fixed32 C2 = From( 0x022222222); //  1/45    0.0222222
        private static readonly Fixed32 C3 = From(-0x000B6DB6E); // -1/945  -0.0010582

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 Sin(Fixed32 radian)
        {
            var normalized = NormalizeRadian(radian);
            var sign = ToQuadrant(normalized, out var reference);
            var result = Evaluate(reference);

            return sign ? result : result * -1;
        }

        /// <summary>
        /// 多项式估值
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static Fixed32 Evaluate(Fixed32 x)
        {
            var x2 = x * x;
            var x3 = x2 * x;
            var x5 = x3 * x2;

            return x + x3 * C1 + x5 * (C2 + x2 * C3);
        }
    }
}
