namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        private const long MAX_RAW_VALUE = long.MaxValue - 1; // 0x7FFFFFFFFFFFFFFE
        private const long MIN_RAW_VALUE = long.MinValue + 2; // 0x8000000000000002

        /// <summary>
        /// 最大值
        /// </summary>
        public static Fixed32 MaxValue => FromRaw(MAX_RAW_VALUE);
        /// <summary>
        /// 最小值
        /// </summary>
        public static Fixed32 MinValue => FromRaw(MIN_RAW_VALUE);
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
        public readonly static Fixed32 Half = FromRaw(1L << 31);
        /// <summary>
        /// 1
        /// </summary>
        public readonly static Fixed32 One = new Fixed32(1);
        /// <summary>
        /// -1
        /// </summary>
        public readonly static Fixed32 NegativeOne = new Fixed32(-1);
        /// <summary>
        /// 1
        /// </summary>
        public readonly static Fixed32 Two = new Fixed32(2);
        /// <summary>
        /// ln(2)
        /// </summary>
        public readonly static Fixed32 Ln2 = FromRaw(2977044472);
        /// <summary>
        /// ln(10)
        /// </summary>
        public readonly static Fixed32 Ln10 = FromRaw(9889527671);
        /// <summary>
        /// 非数字
        /// </summary>
        public readonly static Fixed32 NaN = FromRaw(long.MinValue); // 0x8000000000000000
        /// <summary>
        /// 精度
        /// </summary>
        public readonly static Fixed32 Epsilon = FromRaw(EPSILON_VALUE);

        /// <summary>
        /// 自然常数e
        /// </summary>
        public readonly static Fixed32 E = FromRaw(11674931554);
        /// <summary>
        /// π
        /// </summary>
        public readonly static Fixed32 PI = FromRaw(13493037705);
        /// <summary>
        /// π/ 2
        /// </summary>
        public readonly static Fixed32 Half_PI = FromRaw(6746518852);
        /// <summary>
        /// π/ 4
        /// </summary>
        public readonly static Fixed32 Quarter_PI = FromRaw(3373259426);
        /// <summary>
        /// 2π
        /// </summary>
        public readonly static Fixed32 Two_PI = FromRaw(26986075409);

        /// <summary>
        /// 10^-1
        /// </summary>
        public static readonly Fixed32 TPN1 = FromRaw(429496730);
        /// <summary>
        /// 10^-2
        /// </summary>
        public static readonly Fixed32 TPN2 = FromRaw(42949673);
        /// <summary>
        /// 10^-3
        /// </summary>
        public static readonly Fixed32 TPN3 = FromRaw(4294967);
        /// <summary>
        /// 10^-4
        /// </summary>
        public static readonly Fixed32 TPN4 = FromRaw(429497);

        /// <summary>
        /// 180
        /// </summary>
        public static readonly Fixed32 N180 = FromRaw(773094113280);
        /// <summary>
        /// 360
        /// </summary>
        public static readonly Fixed32 N360 = FromRaw(1546188226560);

        /// <summary>
        /// 正无穷
        /// </summary>
        public static readonly Fixed32 PositiveInfinity = FromRaw(long.MaxValue); // 0x7FFFFFFFFFFFFFFF;
        /// <summary>
        /// 负无穷
        /// </summary>
        public static readonly Fixed32 NegativeInfinity = FromRaw(long.MinValue + 1); // 0x8000000000000001
    }
}
