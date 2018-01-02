using System;
using System.Collections.Generic;

namespace Gfi.Hiring.Utils
{
    public static class ChessBoardCoordinateTranslator
    {
        private static Dictionary<int, string> columnIndexToDisplayTranslator 
            = new Dictionary<int, string>()
        {
             {0, "a"}
            ,{1, "b"}
            ,{2, "c"}
            ,{3, "d"}
            ,{4, "e"}
            ,{5, "f"}
            ,{6, "g"}
            ,{7, "h"}
        };

        private static Dictionary<char, int> displayToColumnIndexTranslator 
            = new Dictionary<char, int>()
        {
             {'a', 0}
            ,{'b', 1}
            ,{'c', 2}
            ,{'d', 3}
            ,{'e', 4}
            ,{'f', 5}
            ,{'g', 6}
            ,{'h', 7}
        };

        public static string TranslateColumnIndexToDisplay(int rawColumnValue)
        {
            string translatedCoordinate;
            if(columnIndexToDisplayTranslator.TryGetValue(rawColumnValue, out translatedCoordinate))
            {
                return translatedCoordinate;
            }
            return string.Empty;
        }

        public static int TranslateColumnDisplayToIndex(char displayValue)
        {
            int translatedCoordinate;
            if (displayToColumnIndexTranslator.TryGetValue(displayValue, out translatedCoordinate))
            {
                return translatedCoordinate;
            }
            return -1;

        }

        public static string TranslateRowIndexToDisplay(int rawRowValue)
        {
            int translatedRowValue = rawRowValue + 1;
            return translatedRowValue.ToString();
        }

        public static int TranslateRowDisplayToIndex(char rowdisplay)
        {
            try
            {
                int translatedRowValue = int.Parse(rowdisplay.ToString()) - 1;
                return translatedRowValue;
            }
            catch (FormatException e)
            {
                return -1;
            }
        }
    }
}