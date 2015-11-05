﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressMapper
{
    public interface IMappingServiceProvider
    {
        void Compile();
        void PrecompileCollection<T, TN>();
        TN Map<T, TN>(T src);
        TN Map<T, TN>(T src, TN dest);
        TN Map<T, TN>(T src, ICustomTypeMapper<T, TN> customMapper);
        TN Map<T, TN>(T src, ICustomTypeMapper<T, TN> customMapper, TN dest);
        object Map(Type srcType, Type dstType, object src);
        object Map(Type srcType, Type dstType, object src, object dest);
        IMemberConfiguration<T, TN> Register<T, TN>();
        void RegisterCustom<T, TN, TMapper>() where TMapper : ICustomTypeMapper<T, TN>;
        void RegisterCustom<T, TN>(Func<T, TN> mapFunc);
        void Reset();
        int CalculateCacheKey(Type src, Type dest);
        Dictionary<int, Func<ICustomTypeMapper>> CustomMappers { get; }
        IQueryable<TN> Project<T, TN>(IQueryable<T> source);
    }
}
