using System;
using System.Collections.Generic;

namespace LinqToLookupToDict_ForEach_For.Entities
{
    public class EntityLevel2
    {
        public Guid Key { get; set; }
        
        public List<EntityLevel3> EntitiesLevel3 { get; set; }
    }
}