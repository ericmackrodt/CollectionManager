using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CollectionManagerWebApi.Common
{
    [DataContract]
    public class ObjectResponse<T>
    {
        public ObjectResponse()
        {

        }

        public ObjectResponse(T value)
        {
            Value = value;
        }

        [DataMember(Name = "value")]
        public T Value { get; set; }
    }
}