using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManagerBackend.Common
{
    public interface IMapToNew<TSource, TTarget>
    {
        TTarget Map(TSource data);
    }
}