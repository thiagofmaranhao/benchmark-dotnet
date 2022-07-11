using System;
using System.Collections.Generic;

namespace LinqToLookupToDict_ForEach_For.Entities
{
    public class EntityLevel1
    {
        public Guid Key { get; set; }
        
        public List<EntityLevel2> EntitiesLevel2 { get; set; }
    }
}