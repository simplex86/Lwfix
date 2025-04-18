namespace Lwfix
{
    /// <summary>
    /// 定点数 - 常量
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        #region values

        /// <summary>
        /// 
        /// </summary>
        private const long S_MAX_RAW_VALUE = long.MaxValue - 1; // 0x7FFFFFFFFFFFFFFE
        /// <summary>
        /// 
        /// </summary>
        private const long S_MIN_RAW_VALUE = long.MinValue + 2; // 0x8000000000000002

        /// <summary>
        /// 
        /// </summary>
        private readonly static Fixed32 S_ADDITIVE_IDENTITY = new Fixed32(0);
        /// <summary>
        /// 
        /// </summary>
        private readonly static Fixed32 S_MULTIPLICATIVE_IDENTITY = new Fixed32(1);
        /// <summary>
        /// 0
        /// </summary>
        private readonly static Fixed32 S_ZERO = new Fixed32(0);
        /// <summary>
        /// 
        /// </summary>
        private readonly static Fixed32 S_HALF = FromRaw(1L << 31);
        /// <summary>
        /// 1
        /// </summary>
        private readonly static Fixed32 S_ONE = new Fixed32(1);
        /// <summary>
        /// -1
        /// </summary>
        private readonly static Fixed32 S_NEGATIVE_ONE = new Fixed32(-1);
        /// <summary>
        /// 1
        /// </summary>
        private readonly static Fixed32 S_TWO = new Fixed32(2);
        /// <summary>
        /// ln(2)
        /// </summary>
        private readonly static Fixed32 S_LN2 = FromRaw(2977044472);
        /// <summary>
        /// ln(10)
        /// </summary>
        private readonly static Fixed32 S_LN10 = FromRaw(9889527671);
        /// <summary>
        /// 非数字
        /// </summary>
        private readonly static Fixed32 S_NaN = FromRaw(long.MinValue); // 0x8000000000000000
        /// <summary>
        /// 精度
        /// </summary>
        private readonly static Fixed32 S_EPSILON = FromRaw(EPSILON_VALUE);

        /// <summary>
        /// 自然常数e
        /// </summary>
        private readonly static Fixed32 S_E = FromRaw(11674931554);
        /// <summary>
        /// π
        /// </summary>
        private readonly static Fixed32 S_PI = FromRaw(13493037705);
        /// <summary>
        /// π/ 2
        /// </summary>
        private readonly static Fixed32 S_HALF_PI = FromRaw(6746518852);
        /// <summary>
        /// π/ 4
        /// </summary>
        private readonly static Fixed32 S_QUARTER_PI = FromRaw(3373259426);
        /// <summary>
        /// 2π
        /// </summary>
        private readonly static Fixed32 S_TWO_PI = FromRaw(26986075409);

        /// <summary>
        /// 10^-1
        /// </summary>
        private readonly static Fixed32 S_TPN1 = FromRaw(429496730);
        /// <summary>
        /// 10^-2
        /// </summary>
        private readonly static Fixed32 S_TPN2 = FromRaw(42949673);
        /// <summary>
        /// 10^-3
        /// </summary>
        private readonly static Fixed32 S_TPN3 = FromRaw(4294967);
        /// <summary>
        /// 10^-4
        /// </summary>
        private readonly static Fixed32 S_TPN4 = FromRaw(429497);

        /// <summary>
        /// 180
        /// </summary>
        private readonly static Fixed32 S_N180 = FromRaw(773094113280);
        /// <summary>
        /// 360
        /// </summary>
        private readonly static Fixed32 S_N360 = FromRaw(1546188226560);

        /// <summary>
        /// 正无穷
        /// </summary>
        private readonly static Fixed32 S_POSITIVE_INFINITY = FromRaw(long.MaxValue); // 0x7FFFFFFFFFFFFFFF;
        /// <summary>
        /// 负无穷
        /// </summary>
        private readonly static Fixed32 S_NEGATIVE_INFINITY = FromRaw(long.MinValue + 1); // 0x8000000000000001

        #endregion

        #region properties

        /// <summary>
        /// 最大值
        /// </summary>
        public static Fixed32 MaxValue => FromRaw(S_MAX_RAW_VALUE);
        /// <summary>
        /// 最小值
        /// </summary>
        public static Fixed32 MinValue => FromRaw(S_MIN_RAW_VALUE);
        /// <summary>
        /// 
        /// </summary>
        public static Fixed32 AdditiveIdentity => S_ADDITIVE_IDENTITY;
        /// <summary>
        /// 
        /// </summary>
        public static Fixed32 MultiplicativeIdentity => S_MULTIPLICATIVE_IDENTITY;
        /// <summary>
        /// 0
        /// </summary>
        public static Fixed32 Zero => S_ZERO;
        /// <summary>
        /// 
        /// </summary>
        public static Fixed32 Half => S_HALF;
        /// <summary>
        /// 1
        /// </summary>
        public static Fixed32 One => S_ONE;
        /// <summary>
        /// -1
        /// </summary>
        public static Fixed32 NegativeOne => S_NEGATIVE_ONE;
        /// <summary>
        /// 1
        /// </summary>
        public static Fixed32 Two => S_TWO;
        /// <summary>
        /// ln(2)
        /// </summary>
        public static Fixed32 Ln2 => S_LN2;
        /// <summary>
        /// ln(10)
        /// </summary>
        public static Fixed32 Ln10 => S_LN10;
        /// <summary>
        /// 非数字
        /// </summary>
        public static Fixed32 NaN => S_NaN;
        /// <summary>
        /// 精度
        /// </summary>
        public static Fixed32 Epsilon => S_EPSILON;

        /// <summary>
        /// 自然常数e
        /// </summary>
        public static Fixed32 E => S_E;
        /// <summary>
        /// π
        /// </summary>
        public static Fixed32 PI => S_PI;
        /// <summary>
        /// π/ 2
        /// </summary>
        public static Fixed32 Half_PI => S_HALF_PI;
        /// <summary>
        /// π/ 4
        /// </summary>
        public static Fixed32 Quarter_PI => S_QUARTER_PI;
        /// <summary>
        /// 2π
        /// </summary>
        public static Fixed32 Two_PI => S_TWO_PI;

        /// <summary>
        /// 10^-1
        /// </summary>
        public static Fixed32 TPN1 => S_TPN1;
        /// <summary>
        /// 10^-2
        /// </summary>
        public static Fixed32 TPN2 => S_TPN2;
        /// <summary>
        /// 10^-3
        /// </summary>
        public static Fixed32 TPN3 => S_TPN3;
        /// <summary>
        /// 10^-4
        /// </summary>
        public static Fixed32 TPN4 => S_TPN4;

        /// <summary>
        /// 180
        /// </summary>
        public static Fixed32 N180 => S_N180;
        /// <summary>
        /// 360
        /// </summary>
        public static Fixed32 N360 => S_N360;

        /// <summary>
        /// 正无穷
        /// </summary>
        public static Fixed32 PositiveInfinity => S_POSITIVE_INFINITY;
        /// <summary>
        /// 负无穷
        /// </summary>
        public static Fixed32 NegativeInfinity => S_NEGATIVE_INFINITY;

        #endregion
    }
}
