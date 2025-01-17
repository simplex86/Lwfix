namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数
    /// </summary>
    public partial struct Fixed16 : IFixed<Fixed16>
    {
        /// <summary>
        /// 
        /// </summary>
        private int value = 0;

        /// <summary>
        /// 整数部分占用的位宽
        /// </summary>
        private const byte INTEGRAL_BITS = 16;
        /// <summary>
        /// 小数部分占用的位宽
        /// </summary>
        private const byte FRACTIONAL_BITS = 32 - INTEGRAL_BITS;
        /// <summary>
        /// 小数精度
        /// </summary>
        private const float FRACTIONAL_MULTIPLIER = ushort.MaxValue + 1.0f;
        /// <summary>
        /// 小数部分的掩码
        /// </summary>
        private const int FRACTIONAL_MASK = (1 << FRACTIONAL_BITS) - 1;

        /// <summary>
        /// 
        /// </summary>
        public Fixed16()
        {
            value = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed16(byte value)
            : this((long)value)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed16(short value)
            : this((long)value)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed16(int value)
        {
            this.value = value << FRACTIONAL_BITS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed16(long value)
            : this((int)value)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed16(float value)
        {
            this.value = (int)(value * FRACTIONAL_MULTIPLIER);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed16(double value)
            : this((float)value)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public Fixed16(Fixed16 other)
        {
            this.value = other.value;
        }

        /// <summary>
        /// 最大值
        /// </summary>
        public static Fixed16 MaxValue => new Fixed16(short.MaxValue);
        /// <summary>
        /// 最小值
        /// </summary>
        public static Fixed16 MinValue => new Fixed16(short.MinValue);
        /// <summary>
        /// 
        /// </summary>
        public readonly static Fixed16 AdditiveIdentity = new Fixed16(0);
        /// <summary>
        /// 
        /// </summary>
        public readonly static Fixed16 MultiplicativeIdentity = new Fixed16(1);
        /// <summary>
        /// 0
        /// </summary>
        public readonly static Fixed16 Zero = new Fixed16(0);
        /// <summary>
        /// 1
        /// </summary>
        public readonly static Fixed16 One = new Fixed16(1);
        /// <summary>
        /// -1
        /// </summary>
        public readonly static Fixed16 NegativeOne = new Fixed16(-1);
        /// <summary>
        /// 
        /// </summary>
        public readonly static Fixed16 NaN = new Fixed16(1f / 0f);
        /// <summary>
        /// 精度
        /// </summary>
        public readonly static Fixed16 Epsilon = From(1);

        /// <summary>
        /// 圆周率
        /// </summary>
        public readonly static Fixed16 E = new Fixed16(2.71828183f);
        /// <summary>
        /// 圆周率
        /// </summary>
        public readonly static Fixed16 PI = new Fixed16(3.14159265f);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// 是否为小数
        /// </summary>
        /// <returns></returns>
        public bool IsFractional()
        {
            return IsFractional(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsFractional(long value)
        {
            return (value & FRACTIONAL_MASK) != 0;
        }
    }
}
