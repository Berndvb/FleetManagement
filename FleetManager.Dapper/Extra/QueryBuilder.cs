using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Dapper.Repositories
{
    public static class QueryBuilder
    {
        //    public static void Select<T>(this StringBuilder sb, params T[] entities) 
        //    {
        //        if (entities == null || entities.Length == 0)
        //            sb.Append($"SELECT * ");

        //        sb.Append("SELECT ");
        //        for (int i = 0; i < entities.Length; i++)
        //        {
        //            if (i == entities.Length -1)
        //            {
        //                sb.Append($"{entities}");
        //            }
        //            else
        //            {
        //                sb.Append($"{entities}, ");
        //            }
        //        }
        //    }

        //    public static void SelectDistinct<T>(this StringBuilder sb, params T[] entities) 
        //    {
        //        if (entities == null || entities.Length == 0)
        //            sb.Append($"SELECT DISTINCT * ");

        //        sb.Append("SELECT DISTINCT ");
        //        for (int i = 0; i < entities.Length; i++)
        //        {
        //            if (i == entities.Length - 1)
        //            {
        //                sb.Append($"{entities}");
        //            }
        //            else
        //            {
        //                sb.Append($"{entities}, ");
        //            }
        //        }
        //    }

        //    public static void From(this StringBuilder sb, object input)
        //    {
        //        sb.Append($"FROM {input.GetType()} ");
        //    }

        //    //public static void Where(this StringBuilder sb)
        //    //{

        //    //    sb.Append($"FROM {input.GetType()} ");
        //    //}

        //    public static void And(this StringBuilder sb)
        //    {

        //        sb.Append($"FROM {input.GetType()} ");
        //    }

        //    public static void Or(this StringBuilder sb)
        //    {

        //        sb.Append($"FROM {input.GetType()} ");
        //    }

        //    public static void Not(this StringBuilder sb)
        //    {

        //        sb.Append($"FROM {input.GetType()} ");
        //    }
    }
}
