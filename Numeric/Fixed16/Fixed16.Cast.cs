namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 类型转换
    /// </summary>
    public partial struct Fixed16
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fixed16 From(int value)
        {
            return new Fixed16() { value = value };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator byte(Fixed16 n) => n.ToByte();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator short(Fixed16 n) => n.ToShort();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator int(Fixed16 n) => n.ToInt();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator long(Fixed16 n) => n.ToLong();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator float(Fixed16 n) => n.ToFloat();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator double(Fixed16 n) => n.ToDouble();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static implicit operator Fixed16(byte n) => new Fixed16(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static implicit operator Fixed16(short n) => new Fixed16(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static implicit operator Fixed16(int n) => new Fixed16(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator Fixed16(long n) => new Fixed16(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator Fixed16(float n) => new Fixed16(n);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public static explicit operator Fixed16(double n) => new Fixed16(n);

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
            return value >> FRACTIONAL_BITS;
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
            return value / FRACTIONAL_MULTIPLIER;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return IsFractional() ? ToDouble().ToString()
                                  : ToLong().ToString();
        }
    }
}
