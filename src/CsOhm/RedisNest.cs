using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackExchange.Redis;

namespace CsOhm
{
    internal class RedisNest<T>
    {
        private readonly IDatabase _database;
        private readonly Type _type;

        public RedisNest(IDatabase database, T obj)
        {
            _database = database ?? throw new CsOhmException("Call Connect() once before attempting to use CsOhm.");
            _type = obj.GetType();
        }

        public long Incr()
        {
            var key = Key();
            var value = _database.StringIncrement(key);
            return value;
        }

        public void Hmset(long id, IDictionary<string, string> fieldValues)
        {
            var hashEntries = fieldValues.Select(e => new HashEntry(e.Key, e.Value)).ToArray();
            _database.HashSet(Key(id), hashEntries);
        }

        public IDictionary<string, string> Hgetall(long id)
        {
            var hashEntries = _database.HashGetAll(Key(id));
            return hashEntries.ToDictionary<HashEntry, string, string>(entry => entry.Name, entry => entry.Value);
        }

        public bool Exists(long id)
        {
            var key = Key(id);
            return _database.KeyExists(key);
        }

        private string Key(object field = null)
        {
            var sb = new StringBuilder();
            sb.Append(CsOhm.Prefix);
            sb.Append(':');
            sb.Append(_type.Name);
            if (field != null)
            {
                sb.Append(':');
                sb.Append(field);
            }
            var key = sb.ToString();
            return key;
        }
    }
}
