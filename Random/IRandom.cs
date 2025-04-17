using System;

namespace Lwkit.Fixed
{
    /// <summary>
    /// 随机数 - 接口
    /// </summary>
    public interface IRandom
    {

    }

    /// <summary>
    /// 随机数 - 接口
    /// </summary>
    public interface IRandom<T> : IRandom where T : struct, IFixed<T>
    {
        T Next();

        T Next(T min, T max);
    }

    /// <summary>
    /// 
    /// </summary>
    public class FRandomEntryAttribute<T> : Attribute where T : struct, IFixed<T>
    {
        public Type Type { get; }

        public FRandomEntryAttribute()
        {
            Type = typeof(T);
        }
    }
}
