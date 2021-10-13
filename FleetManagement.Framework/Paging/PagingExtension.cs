using System.Collections.Generic;

namespace FleetManagement.Framework.Paging
{
    public static class PagingExtension
    {
        public static List<List<T>> InPages<T>(this List<T> queryResult, int pageSize)
        {
            var pageToFill = new List<T>();
            var pagedResult = new List<List<T>>();

            for (int i = 0; i < queryResult.Count; i++)
            {
                if (i % pageSize == 0)
                {
                    pagedResult.Add(pageToFill);
                    pageToFill.Clear();
                }
                pageToFill.Add(queryResult[i]);
            }

            return pagedResult;
        }
    }
}
