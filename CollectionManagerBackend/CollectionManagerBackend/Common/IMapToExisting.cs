using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManagerBackend.Common
{
    public interface IMapToExisting<TSource, TTarget>
    {
        void Map(TSource source, TTarget target);
    }
}