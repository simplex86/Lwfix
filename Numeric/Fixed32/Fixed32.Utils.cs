namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 数学
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 两个数符号是否相同
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static bool IsSigns(long a, long b)
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
        private static Fixed32 NormalizeRadian(Fixed32 radian, Fixed32 unit)
        {
            var remainder = radian.rawvalue % unit.rawvalue;
            if (remainder < 0) remainder += unit.rawvalue;

            return FromRaw(remainder);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Fixed32 DegToRad { get; } = FromRaw(74961321);
        /// <summary>
        /// 
        /// </summary>
        public static Fixed32 RadToDeg { get; } = FromRaw(246083499208);

        /// <summary>
        /// 角度转弧度
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static Fixed32 DegreeToRadian(Fixed32 degree)
        {
            return degree * DegToRad;
        }

        /// <summary>
        /// 弧度转角度
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 RadianToDegree(Fixed32 radian)
        {
            return radian * RadToDeg;
        }
    }
}
