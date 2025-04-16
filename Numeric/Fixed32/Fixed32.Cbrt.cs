namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 立方根
    /// </summary>
    public partial struct Fixed32 : IFixed<Fixed32>
    {
        /// <summary>
        /// 立方根
        /// </summary>
        /// <returns></returns>
        public Fixed32 Cbrt()
        {
            return Exp(Log() / 3);
        }

        /// <summary>
        /// 立方根
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Fixed32 Cbrt(Fixed32 n)
        {
            return n.Cbrt();
        }
    }
}
