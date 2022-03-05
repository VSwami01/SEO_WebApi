using System.Collections.Generic;
using System.Linq;

namespace SEO_WebApi.Extentions
{
    public static class ListExtension
    {
        /// <summary>
        /// Find indexes of all occurences of the match and offset index by 1
        /// </summary>
        /// <param name="stringList"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        public static IList<int> FindAllIndexOffsetOne(this IEnumerable<string> stringList, string match)
        {
            var indexes = new List<int>();

            if (stringList == null || !stringList.Any()
                || match == null || match.Trim().Length == 0)
            {
                return indexes;
            }

            foreach (var item in stringList.Select((value, i) => new { i, value }))
            {
                if (item.value.Contains(match))
                    indexes.Add(item.i + 1);
            }

            return indexes;
        }
    }
}
