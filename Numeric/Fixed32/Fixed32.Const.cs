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
        /// 1
        /// </summary>
        public readonly static Fixed32 One = new Fixed32(1);
        /// <summary>
        /// -1
        /// </summary>
        public readonly static Fixed32 NegativeOne = new Fixed32(-1);
        /// <summary>
        /// 非数字
        /// </summary>
        public readonly static Fixed32 NaN = From(long.MinValue); // 0x8000000000000000
        /// <summary>
        /// 精度
        /// </summary>
        public readonly static Fixed32 Epsilon = From(EPSILON_VALUE);

        /// <summary>
        /// 自然常数
        /// </summary>
        public readonly static Fixed32 E = new Fixed32(2.7182818284590452354);
        /// <summary>
        /// 圆周率
        /// </summary>
        public readonly static Fixed32 PI = new Fixed32(3.14159265358979323846);
    }
}
