namespace Lwkit.Fixed
{
    /// <summary>
    /// 二维向量 - 角度
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct Vector2<T> where T : struct, IFixed<T>
    {
        /// <summary>
        /// 两向量的角度（单位：度）
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static T Angle(Vector2<T> from, Vector2<T> to)
        {
            var magnitude = FMath.Sqrt(from.SqrMagnitude * to.SqrMagnitude);
            if (magnitude.IsZero()) return T.Zero;

            var acos = FMath.Acos(FMath.Clamp(Dot(from, to) / magnitude, T.NegativeOne, T.One));
            return T.RadianToDegree(acos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static T SignedAngle(Vector2<T> from, Vector2<T> to)
        {
            return Angle(from, to) * FMath.Sign(from.X * to.Y - from.Y * to.X);
        }
    }
}
