﻿using System;
using System.Collections.Generic;

namespace Lwkit.Fixed
{
    /// <summary>
    /// 随机数
    /// </summary>
    public class FRandom
    {
        /// <summary>
        /// 
        /// </summary>
        public static FRandom Shared { get; } = new FRandom();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<Type, IRandom> randoms = new Dictionary<Type, IRandom>();

        /// <summary>
        /// 
        /// </summary>
        private FRandom()
        {
            randoms.Add(typeof(Fixed32), new FRandom32());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Next<T>() where T : struct, IFixed<T>
        {
            var random = Get<T>();
            return random.Next();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public T Next<T>(T min, T max) where T : struct, IFixed<T>
        {
            var random = Get<T>();
            return random.Next(min, max);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private IRandom<T> Get<T>() where T : struct, IFixed<T>
        {
            if (!randoms.TryGetValue(typeof(T), out var random))
            {
                random = null;
                randoms.Add(typeof(T), random);
            }

            return random as IRandom<T>;
        }
    }
}
