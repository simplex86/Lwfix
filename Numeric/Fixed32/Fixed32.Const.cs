namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 最大值
        /// </summary>
        public static Fixed32 MaxValue => From(long.MaxValue); // 0x7FFFFFFFFFFFFFFF
        /// <summary>
        /// 最小值
        /// </summary>
        public static Fixed32 MinValue => From(long.MinValue + 1); // 0x8000000000000001
        /// <summary>
        /// 
        /// </summary>
        public readonly static Fixed32 AdditiveIdentity = new Fixed32(0);
        /// <summary>
        /// 
        /// </summary>
        public readonly static Fixed32 MultiplicativeIdentity = new Fixed32(1);
        /// <summary>
        /// 0
        /// </summary>
        public readonly static Fixed32 Zero = new Fixed32(0);
        /// <summary>
        /// 
        /// </summary>
        public readonly static Fixed32 Half = From(1L << 31);
        /// <summary>
        /// 1
        /// </summary>
        public readonly static Fixed32 One = new Fixed32(1);
        /// <summary>
        /// -1
        /// </summary>
        public readonly static Fixed32 NegativeOne = new Fixed32(-1);
        /// <summary>
        /// ln(2)
        /// </summary>
        public readonly static Fixed32 LN2 = From(2977044472);
        /// <summary>
        /// ln(10)
        /// </summary>
        public readonly static Fixed32 LN10 = From(9889527671);
        /// <summary>
        /// 非数字
        /// </summary>
        public readonly static Fixed32 NaN = From(long.MinValue); // 0x8000000000000000
        /// <summary>
        /// 精度
        /// </summary>
        public readonly static Fixed32 Epsilon = From(EPSILON_VALUE);

        /// <summary>
        /// 自然常数e
        /// </summary>
        public readonly static Fixed32 E = From(11674931554);
        /// <summary>
        /// 圆周率π
        /// </summary>
        public readonly static Fixed32 PI = From(13493037705);
        /// <summary>
        /// π/2
        /// </summary>
        public readonly static Fixed32 Half_PI = From(6746518852);
        /// <summary>
        /// 2π
        /// </summary>
        public readonly static Fixed32 Two_PI = From(26986075409);
    }
}
