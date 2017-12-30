using System.Collections.Generic;

namespace Gfi.Hiring.Utils
{
    public static class ChessBoardCoordinateTranslator
    {
        private static Dictionary<int, string> columnTranslator = new Dictionary<int, string>()
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

        public static string TranslateColumn(int rawColumnValue)
        {
            string translatedCoordinate;
            if(columnTranslator.TryGetValue(rawColumnValue, out translatedCoordinate))
            {
                return translatedCoordinate;
            }
            return string.Empty;
        }

        public static string TranslateRow(int rawRowValue)
        {
            int translatedRowValue = rawRowValue + 1;
            return translatedRowValue.ToString();
        }
    }
}