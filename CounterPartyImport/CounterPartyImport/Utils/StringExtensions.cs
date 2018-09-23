using CounterPartyImport.Enums;
using System;

namespace CounterPartyImport.Utils
{
    public static class StringExtensions
    {
        public static bool ToBoolean(this string str)
        {
            return Convert.ToBoolean(Enum.Parse(typeof(BooleanAliases), str));
        }
    }
}
