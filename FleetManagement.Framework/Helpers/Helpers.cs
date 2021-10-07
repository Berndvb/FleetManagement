using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FleetManagement.Framework.Helpers
{
    public static class Helpers
    {
        public const char SPLITTER = ',';

        public static List<string> SplitToText(this string input)
        {
            return input.Trim().Split(SPLITTER).ToList();
        }

        public static List<int> SplitToNumbers(this string input)
        {
            var inputSplit = input.Trim().Split(SPLITTER).ToList();

            List<int> numbers = new List<int>();
            foreach (var item in inputSplit)
            {
                int convertedItem;
                if (!int.TryParse(item, out convertedItem))
                {
                    throw new Exception("Couldn't convert the string to its numerical counterpart.");
                }
                numbers.Add(convertedItem);
            }

            return numbers;
        }

        public static string Unify<TDatatype>(this List<TDatatype> input)
        {
            return String.Join(SPLITTER, input);
        }

        public static bool AfterAllphiStartdate(this DateTime date)
        { 
            var allphiStartdate = DateTime.ParseExact(Constants.Constants.Info.StartAllPhi, "yyyyMMdd", CultureInfo.InvariantCulture);
            switch (DateTime.Compare(date, allphiStartdate))
            {
                case > 0:
                    return true;
                default:
                    return false;
            }
        }

        public static DateTime AllphiStartdate()
        {
            var allphiStartdate = DateTime.ParseExact(Constants.Constants.Info.StartAllPhi, "yyyyMMdd", CultureInfo.InvariantCulture);
            return allphiStartdate;
        }

        public static int IdToInt(this string id)
        {
            return int.Parse(id);
        }
    }
}
