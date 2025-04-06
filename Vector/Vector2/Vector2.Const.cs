namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct Vector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// (0, 0)
        /// </summary>
        public readonly static Vector2<T> Zero = new Vector2<T>();

        /// <summary>
        /// (1, 1)
        /// </summary>
        public readonly static Vector2<T> One = new Vector2<T>(T.One, T.One);

        /// <summary>
        /// (0, 1)
        /// </summary>
        public readonly static Vector2<T> Up = new Vector2<T>(T.Zero, T.One);

        /// <summary>
        /// (0, -1)
        /// </summary>
        public readonly static Vector2<T> Down = new Vector2<T>(T.Zero, T.NegativeOne);

        /// <summary>
        /// (-1, 0)
        /// </summary>
        public readonly static Vector2<T> Left = new Vector2<T>(T.NegativeOne, T.Zero);

        /// <summary>
        /// (1, 0)
        /// </summary>
        public readonly static Vector2<T> Right = new Vector2<T>(T.One, T.Zero);
    }
}
