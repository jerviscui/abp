using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace Volo.Abp.Reflection
{
    //todo cuizj: done!
    public class AttributeCache
    {
        private readonly ConcurrentDictionary<string, Attribute[]> _caches;

        public AttributeCache()
        {
            _caches = new ConcurrentDictionary<string, Attribute[]>();
        }

        private string GetKey(Type type, Type attributeType)
        {
            return $"{type.FullName}+{attributeType.FullName}";
        }

        public IEnumerable<TAttribute> GetAttributesOrAdd<TAttribute>(Type type, Func<string, Attribute[]> valueFunc)
            where TAttribute : Attribute, new()
        {
            return _caches.GetOrAdd(GetKey(type, typeof(TAttribute)), valueFunc).OfType<TAttribute>();
        }

        public IEnumerable<TAttribute> GetAttributes<TAttribute>(Type type) where TAttribute : Attribute, new()
        {
            //todo cuizj: update to standard 2.1 for support using System.Collections.Generic;
            //var nullarray = _caches.GetValueOrDefault("test");
            //var emptyarray = _caches.GetValueOrDefault("test2", new Item[0]);
            
            return _caches.GetOrDefault(GetKey(type, typeof(TAttribute))).OfType<TAttribute>();
        }

        //todo cuizj: enable null
        [CanBeNull]
        public TAttribute GetFirstAttribute<TAttribute>(Type type) where TAttribute : Attribute, new()
        {
            return GetAttributes<TAttribute>(type).FirstOrDefault();
        }
    }
}
