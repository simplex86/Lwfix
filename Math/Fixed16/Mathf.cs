namespace Lwkit.Fixed
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Mathf
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 Min(Fixed16 a, Fixed16 b)
        {
            return a < b ? a : b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed16 Max(Fixed16 a, Fixed16 b)
        {
            return a > b ? a : b;
        }
    }
}
