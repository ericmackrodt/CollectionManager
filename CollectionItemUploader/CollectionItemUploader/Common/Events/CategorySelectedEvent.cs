using Broadcaster;
using CollectionManagerBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionItemUploader.Common.Events
{
    public class CategorySelectedEvent : BroadcasterEvent<Category> { }
}
