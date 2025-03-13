namespace Lwkit.Fixed
{
    /// <summary>
    /// 定点数 - 余弦
    /// </summary>
    public partial struct Fixed32
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 Cos(Fixed32 radian)
        {
            return Sin(radian + Half_PI);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static Fixed32 FastCos(Fixed32 radian)
        {
            return FastSin(radian + Half_PI);
        }
    }
}
