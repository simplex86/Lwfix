namespace Lwfix
{
    /// <summary>
    /// 定点数 - 取余
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator %(Fixed32 a, int b)
        {
            var b_rawvalue = Int32ToRaw(b);
            return Mod(a.rawvalue, b_rawvalue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator %(int a, Fixed32 b)
        {
            var a_rawvalue = Int32ToRaw(a);
            return Mod(a_rawvalue, b.rawvalue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 operator %(Fixed32 a, Fixed32 b)
        {
            return Mod(a.rawvalue, b.rawvalue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static Fixed32 Mod(long a, long b)
        {
            if (PreprocessMod(a, b, out var r))
            {
                return r;
            }

            return FromRaw(a % b);
        }

        /// <summary>
        /// 预处理特殊边界值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static bool PreprocessMod(long a, long b, out Fixed32 r)
        {
            if (a.IsNaN() || b.IsNaN()) { r = NaN; return true; }
            if (a.IsInfinity()) { r = NaN; return true; }
            if (a.IsMin()) { r = Zero; return true; }
            if (b.IsNegativeOne()) { r = Zero; return true; }
            if (b.IsMinMax() || b.IsInfinity()) { r = new Fixed32(a); return true; }

            r = Zero;
            return false;
        }
    }
}
