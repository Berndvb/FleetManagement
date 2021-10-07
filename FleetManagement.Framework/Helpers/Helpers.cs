using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public static bool IsAfterAllphiStartdate(this DateTime date)
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

        public static int StringToInt(this string input)
        {
            return int.Parse(input);
        }

        public static bool IsValidEmail(this string source)
        {
            return new EmailAddressAttribute().IsValid(source);
        }

        public static bool IsValidNationalInsuranceNumber(this string source)
        {
            //Algemeen: 11 cijfers
            if (source.Length != 11 || 
                !int.TryParse(source, out _))
            {
                return false;
            }

            //Groep 1: 6cijfers
            //yyMMdd (m en dag mag null 00) - indien niet exact bekend
            //bisnummer: m + 20 of 40 (indien geslacht bekend)  -> ongeldig  stuk tussen 32 en 41
            //voortvluchtig: m en d op 00
            var mm = source.Substring(2, 2).StringToInt();
            var dd = source.Substring(4, 2).StringToInt();
            if (mm < 0 ||
                (mm > 32 && mm < 41) || 
                mm > 52 ||
                dd < 0 || 
                dd > 31)
            {
                return false;
            }

            //Groep 2: 3 cijfers
            // even voor vrouw, oneven voor man
            // dagteller geboortes, van man 1-997, vrouw 2-998
            var secondGroup = source.Substring(6, 3).StringToInt();
            if (secondGroup < 1 ||
                secondGroup > 998)
            {
                return false;
            }

            //Groep 3: 2 cijfers
            //controlegetal op basis van 9 voorgaande cijfers: alle 9 opeenvolgend delen door 97.
            //De rest wordt van 97 afgetrokken. Dat is het controlenummer
            //geboren na 2000: een 2 voor de 9 cijfers
            var thirdGroup = source.Substring(9, 2).StringToInt();
            var totalNumbersAfter2000 = ("2" + source).StringToInt();
            var totalNumbers = source.StringToInt();
            int remainder;
            int remainderAfter2000;
            Math.DivRem(totalNumbers, 97, out remainder);
            Math.DivRem(totalNumbersAfter2000, 97, out remainderAfter2000);

            if (thirdGroup != (97 - remainder) &&
                thirdGroup != (97 - remainderAfter2000))
            {
                return false;
            }

            return true;
        }
    }
}
