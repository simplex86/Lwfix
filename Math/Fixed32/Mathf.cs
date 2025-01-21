namespace Lwkit.Fixed
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Mathf
    {
        public static Fixed32 Abs(Fixed32 n)
        {
            if (n == Fixed32.MinValue)
            {
                return Fixed32.MaxValue;
            }

            // branchless implementation, see http://www.strchr.com/optimized_abs_function
            var mask = n.value >> 63;
            return Fixed32.From((n.value + mask) ^ mask);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 Min(Fixed32 a, Fixed32 b)
        {
            return a < b ? a : b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fixed32 Max(Fixed32 a, Fixed32 b)
        {
            return a > b ? a : b;
        }
    }
}
