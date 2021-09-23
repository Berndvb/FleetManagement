﻿using System;
using System.Collections.Generic;
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

        public static string Unify<TDatatype>(List<TDatatype> input)
        {
            return String.Join(SPLITTER, input);
        }
    }
}