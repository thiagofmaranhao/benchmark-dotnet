using LinqToLookupToDict_ForEach_For.Entities;

namespace LinqToLookupToDict_ForEach_For;

public class GenerateDictKeyEntityLev4ValuesKeyEntityLevel1
    {
        public Dictionary<Guid, IList<Guid>> GenerateWithLinqToLookupToDictionary(IEnumerable<EntityLevel1> entitiesLevel1)
        {
            var dictionary = entitiesLevel1.SelectMany(el1 =>
                    el1.EntitiesLevel2.SelectMany(el2 =>
                        el2.EntitiesLevel3.SelectMany(el3 =>
                            el3.EntitiesLevel4.Select(el4 => new { el4.Key, Value = el1.Key }
                            ))))
                .ToLookup(obj => obj.Key, obj => obj.Value)
                .ToDictionary(lookup => lookup.Key, lookup => (IList<Guid>)lookup.ToList());

            return dictionary;
        }
        
        public Dictionary<Guid, IList<Guid>> GenerateWithForEachOnly(IEnumerable<EntityLevel1> entitiesLevel1)
        {
            var dictionary = new Dictionary<Guid, IList<Guid>>();

            foreach (var entityLevel in entitiesLevel1)
            {
                foreach (var entityLevel2 in entityLevel.EntitiesLevel2)
                {
                    foreach (var entityLevel3 in entityLevel2.EntitiesLevel3)
                    {
                        foreach (var entityLevel4 in entityLevel3.EntitiesLevel4)
                        {
                            var keys = dictionary.ContainsKey(entityLevel4.Key)
                                ? dictionary[entityLevel4.Key]
                                : new List<Guid>();

                            keys.Add(entityLevel.Key);

                            dictionary[entityLevel4.Key] = keys;
                        }
                    }
                }
            }

            return dictionary;
        }
        
        public Dictionary<Guid, IList<Guid>> GenerateWithLinqAndForEach(IEnumerable<EntityLevel1> entitiesLevel1)
        {
            var dictionary = new Dictionary<Guid, IList<Guid>>();

            var listKeyValue = entitiesLevel1.SelectMany(el1 =>
                el1.EntitiesLevel2.SelectMany(el2 =>
                    el2.EntitiesLevel3.SelectMany(el3 =>
                        el3.EntitiesLevel4.Select(el4 => new { el4.Key, Value = el1.Key }
                        ))));

            foreach (var item in listKeyValue)
            {
                var keys = dictionary.ContainsKey(item.Key)
                    ? dictionary[item.Key]
                    : new List<Guid>();

                keys.Add(item.Value);

                dictionary[item.Key] = keys;
            }

            return dictionary;
        }
        
        public Dictionary<Guid, IList<Guid>> GenerateWithForOnly(IEnumerable<EntityLevel1> entitiesLevel1)
        {
            var dictionary = new Dictionary<Guid, IList<Guid>>();

            var list = entitiesLevel1.ToList();
            
            for (var indexPosition = 0; indexPosition < list.Count; indexPosition++)
            {
                var entityLevel1 = list[indexPosition];
                
                for (var index1 = 0; index1 < entityLevel1.EntitiesLevel2.Count; index1++)
                {
                    var entityLevel2 = entityLevel1.EntitiesLevel2[index1];
                    for (var i = 0; i < entityLevel2.EntitiesLevel3.Count; i++)
                    {
                        var entityLevel3 = entityLevel2.EntitiesLevel3[i];
                        for (var index = 0; index < entityLevel3.EntitiesLevel4.Count; index++)
                        {
                            var entityLevel4 = entityLevel3.EntitiesLevel4[index];
                            var keys = dictionary.ContainsKey(entityLevel4.Key)
                                ? dictionary[entityLevel4.Key]
                                : new List<Guid>();

                            keys.Add(entityLevel1.Key);

                            dictionary[entityLevel4.Key] = keys;
                        }
                    }
                }
            }

            return dictionary;
        }
    }