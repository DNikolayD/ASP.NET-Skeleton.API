﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Guid;

namespace ASP.NET_Skeleton.Common
{
    public static class GuidExtensions
    {
        public static TKey InitialiseId<TKey>(this Guid id)
        {
            return (new Guid().ToString().MapTo(typeof(TKey)) is TKey
                ? (TKey) NewGuid().ToString().MapTo(typeof(TKey))
                : default)!;
        } 
    }
}
