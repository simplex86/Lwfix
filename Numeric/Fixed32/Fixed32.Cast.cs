namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 类型转换
    /// </summary>
    public partial struct Fixed32
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fixed32 From(long value)
        {
            return new Fixed32() { rawvalue = value };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator byte(Fixed32 n) => n.ToByte();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator short(Fixed32 n) => n.ToShort();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator int(Fixed32 n) => n.ToInt();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator long(Fixed32 n) => n.ToLong();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator float(Fixed32 n) => n.ToFloat();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator double(Fixed32 n) => n.ToDouble();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static implicit operator Fixed32(byte n) => new Fixed32(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static implicit operator Fixed32(short n) => new Fixed32(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static implicit operator Fixed32(int n) => new Fixed32(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator Fixed32(long n) => new Fixed32(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator Fixed32(float n) => new Fixed32(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator Fixed32(double n) => new Fixed32(n);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte ToByte()
        {
            return (byte)ToLong();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public short ToShort()
        {
            return (short)ToLong();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ToInt()
        {
            return (int)ToLong();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long ToLong()
        {
            return rawvalue >> FRACTIONAL_BITS;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float ToFloat()
        {
            return (float)ToDouble();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double ToDouble()
        {
            return rawvalue / FRACTIONAL_MULTIPLIER;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this == NaN) return "NaN";
            return ToDouble().ToString();
        }

        /// <summary>
        /// 获取整数部分
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Integral(Fixed32 n)
        {
            return From(n.rawvalue & INTEGRAL_MASK);
        }

        /// <summary>
        /// 获取小数部分
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Fractional(Fixed32 n)
        {
            return From(n.rawvalue & FRACTIONAL_MASK);
        }
    }
}
