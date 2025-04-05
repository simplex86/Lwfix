namespace Lwkit.Fixed
{
    /// <summary>
    /// 数学库
    /// </summary>
    public static partial class FMath
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="n"></param>
        /// <returns></returns>
        public static T Sqrt<T>(int n) where T : struct, IFixed<T>
        {
            var f = (T)n;
            return f.Sqrt();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="n"></param>
        /// <returns></returns>
        public static T Sqrt<T>(long n) where T : struct, IFixed<T>
        {
            var f = (T)n;
            return f.Sqrt();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="n"></param>
        /// <returns></returns>
        public static T Sqrt<T>(T n) where T : struct, IFixed<T>
        {
            return n.Sqrt();
        }
    }
}
