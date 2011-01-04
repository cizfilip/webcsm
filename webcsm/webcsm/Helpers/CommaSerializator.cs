using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webcsm.Helpers
{
    public static class CommaSerializator
    {
        public static string Serialize(IEnumerable<string> values)
        {
            return String.Join(", ", values);
        }

        public static IEnumerable<string> Deserialize(string values)
        {
            return values.Split(',').Select(v => v.Trim());
        }
    }
}