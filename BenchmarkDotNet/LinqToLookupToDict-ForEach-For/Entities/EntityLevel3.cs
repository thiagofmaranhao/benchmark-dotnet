using System;
using System.Collections.Generic;

namespace LinqToLookupToDict_ForEach_For.Entities
{
    public class EntityLevel3
    {
        public Guid Key { get; set; }
        
        public List<EntityLevel4> EntitiesLevel4 { get; set; }
    }
}