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
    }
}
