using System;
using System.Collections.Generic;

namespace ImmersiveMiracast.Util
{
    /// <summary>
    /// common class extensions used in the app
    /// </summary>
    public static class ClassExtension
    {
        /// <summary>
        /// shorthand for string.Format()
        /// </summary>
        /// <param name="s">the string to format</param>
        /// <param name="o">formatting for the string</param>
        /// <returns>the formatted string</returns>
        public static string Format(this string s, params object[] o)
        {
            return string.Format(s, o);
        }

        /// <summary>
        /// replace all keys with their value in the map
        /// </summary>
        /// <param name="s">the string to replace in</param>
        /// <param name="map">the replacement map</param>
        /// <param name="ignoreCase">should upper / lower case be ignored for replace function?</param>
        /// <returns>the final string</returns>
        public static string ReplaceMap(this string s, Dictionary<string, string> map, bool ignoreCase = false)
        {
            foreach (string key in map.Keys)
                s = s.Replace(key, map[key], ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

            return s;
        }
    }
}
