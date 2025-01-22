﻿namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 
        /// </summary>
        internal long value = 0;

        /// <summary>
        /// 总位宽
        /// </summary>
        private const byte TOTAL_BITS = sizeof(long) * 8;
        /// <summary>
        /// 整数部分占用的位宽
        /// </summary>
        private const byte INTEGRAL_BITS = TOTAL_BITS / 2;
        /// <summary>
        /// 小数部分占用的位宽
        /// </summary>
        private const byte FRACTIONAL_BITS = TOTAL_BITS - INTEGRAL_BITS;
        /// <summary>
        /// 小数精度
        /// </summary>
        private const double FRACTIONAL_MULTIPLIER = uint.MaxValue + 1.0;
        /// <summary>
        /// 小数部分的掩码
        /// </summary>
        private const long FRACTIONAL_MASK = (1L << FRACTIONAL_BITS) - 1L;

        /// <summary>
        /// 
        /// </summary>
        public Fixed32()
        {
            value = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed32(byte value)
            : this((long)value)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed32(short value)
            : this((long)value)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed32(int value)
            : this((long)value)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed32(long value)
        {
            this.value = value << FRACTIONAL_BITS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed32(float value)
            : this((double)value)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Fixed32(double value)
        {
            this.value = (long)(value * FRACTIONAL_MULTIPLIER);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public Fixed32(Fixed32 other)
        {
            this.value = other.value;
        }

        /// <summary>
        /// 最大值
        /// </summary>
        public static Fixed32 MaxValue => From(long.MaxValue);
        /// <summary>
        /// 最小值
        /// </summary>
        public static Fixed32 MinValue => From(long.MinValue + 1);
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
        public readonly static Fixed32 NaN = From(long.MinValue);
        /// <summary>
        /// 精度
        /// </summary>
        public readonly static Fixed32 Epsilon = From(1);

        /// <summary>
        /// 自然常数
        /// </summary>
        public readonly static Fixed32 E = new Fixed32(2.7182818284590452354);
        /// <summary>
        /// 圆周率
        /// </summary>
        public readonly static Fixed32 PI = new Fixed32(3.14159265358979323846);

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
