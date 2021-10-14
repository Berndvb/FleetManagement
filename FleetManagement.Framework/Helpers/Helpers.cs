using FleetManagement.Framework.Models.Enums;
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

        public static AppealStatus StringToAppealStatus(this string source)
        {
            if (!String.IsNullOrEmpty(source))
            {
                var sourceCorrected = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(source.ToLower());
                var appealStatus = Enum.Parse(typeof(AppealStatus), sourceCorrected);
                return (AppealStatus)appealStatus;
            }
            return 0;
        }

        public static DriversLicenseType StringToDriversLicense(this string source)
        {
            if (!String.IsNullOrEmpty(source))
            {
                var sourceCorrected = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(source.ToLower());
                var driversLicense = Enum.Parse(typeof(DriversLicenseType), sourceCorrected);
                return (DriversLicenseType)driversLicense;
            }
            return 0;
        }

        public static string CorrectStringInput(this string source)
        {
            var sourceCorrected = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(source.ToLower());
            return sourceCorrected;
        }

        public static bool IsValidNationalInsuranceNumber(this string source)
        {
            if (source.Length != 11 || 
                !long.TryParse(source, out _))
            {
                return false;
            }

            var mm = source.Substring(2,2).StringToInt();
            var dd = source.Substring(4,2).StringToInt();
            if (mm < 0 ||
                (mm > 32 && mm < 41) || 
                mm > 52 ||
                dd < 0 || 
                dd > 31)
            {
                return false;
            }

            var secondGroup = source.Substring(6,3).StringToInt();
            if (secondGroup < 1 ||
                secondGroup > 998)
            {
                return false;
            }

            var thirdGroup = long.Parse(source.Substring(9, 2));
            var firstTwoGroups2000 = long.Parse("2" + source.Substring(0, 9));
            var firstTwoGroups = long.Parse(source.Substring(0, 9));
            long remainder;
            long remainder2000;
            Math.DivRem(firstTwoGroups, 97, out remainder);
            Math.DivRem(firstTwoGroups2000, 97, out remainder2000);
            if (thirdGroup != (97 - remainder) &&
                thirdGroup != (97 - remainder2000))
            {
                return false;
            }

            return true;
        }

        public static bool IsValidDateOfBirth(this DateTime dateOfBirth, int minAge, int maxAge)
        {
            if (dateOfBirth.AddYears(minAge) > DateTime.Now ||
                dateOfBirth.AddYears(maxAge) < DateTime.Now)
                return false;

            return true;
        }

        public static bool IsValidPostcodeNL(this string postcode)
        {
            var postcodeTrimmed = postcode.Trim();

            if (postcodeTrimmed.Length != 7)
                return false;

            var digits = postcodeTrimmed.Substring(0,4);
            if (!int.TryParse(digits, out _))
                return false;

            var space = postcodeTrimmed[5];
            if (space != ' ')
                return false;

            var letters = postcodeTrimmed.Substring(5, 2);
            if (int.TryParse(letters, out _))
                return false;

            return true;
        }

        public static bool IsValidPostcodeB(this string postcode)
        {
            var postcodeTrimmed = postcode.Trim();

            if (postcodeTrimmed.Length != 4)
                return false;

            if (!int.TryParse(postcodeTrimmed, out _))
                return false;

            return true;
        }
    }
}
