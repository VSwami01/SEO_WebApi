namespace SEO_WebApi.Extentions
{
    public static class StringExtension
    {
        /// <summary>
        /// Trim characters '*', '.', ' ', '/', '\\' from the string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string TrimSpecialChars(this string text)
        {
            if (text.IsNullOrEmpty())
                return string.Empty;

            char[] charsToTrim = { '*', '.', ' ', '/', '\\' };
            return text.Trim(charsToTrim);
        }

        /// <summary>
        /// Check if string is null or empty. Return true or false
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string text)
        {
            return (text == null || text.Trim().Length == 0);
                
        }
    }
}
