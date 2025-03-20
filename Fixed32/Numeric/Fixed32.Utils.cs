namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 数学
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 获取前导零的数量
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        internal static int GetLeadingZeroCount(ulong n)
        {
            if (n == 0) return 64;

            var count = 0;
            {
                while ((n & 0xF000000000000000) == 0) { count += 4; n <<= 4; }
                while ((n & 0x8000000000000000) == 0) { count += 1; n <<= 1; }
            }
            return count;
        }

        /// <summary>
        /// 获取尾部零的数量
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        internal static int GetTrailingZeroCount(ulong n)
        {
            if (n == 0) return 64;

            var count = 0;
            {
                while ((n & 0xF) == 0) { count += 4; n >>= 4; }
                while ((n & 0x1) == 0) { count += 1; n >>= 1; }
            }
            return count;
        }

        /// <summary>
        /// 两个数符号是否相同
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static bool IsSameSign(long a, long b)
        {
            return ((a ^ b) & SIGN_BIT_MASK) == 0;
        }

        /// <summary>
        /// 角度规范化到[0, 2π]
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 NormalizeRadian(Fixed32 radian)
        {
            return NormalizeRadian(radian, Two_PI);
        }

        /// <summary>
        /// 角度规范化
        /// </summary>
        /// <param name="radian"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        internal static Fixed32 NormalizeRadian(Fixed32 radian, Fixed32 unit)
        {
            var remainder = radian.rawvalue % unit.rawvalue;
            if (remainder < 0) remainder += unit.rawvalue;

            return FromRaw(remainder);
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly static Fixed32 D2R = FromRaw(74961321);
        /// <summary>
        /// 
        /// </summary>
        private readonly static Fixed32 R2D = FromRaw(246083499208);

        /// <summary>
        /// 角度转弧度
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static Fixed32 DegreeToRadian(Fixed32 degree)
        {
            return degree * D2R;
        }

        /// <summary>
        /// 弧度转角度
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 RadianToDegree(Fixed32 radian)
        {
            return radian * R2D;
        }
    }
}
