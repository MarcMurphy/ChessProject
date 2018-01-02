using Gfi.Hiring.Utils;
using NUnit.Framework;

namespace Gfi.Hiring.Tests
{
    [TestFixture]
    public class ChessBoardCoordinateTranslator_Tests
    {
        [TestCase(0, "a")]
        [TestCase(1, "b")]
        [TestCase(2, "c")]
        [TestCase(3, "d")]
        [TestCase(4, "e")]
        [TestCase(5, "f")]
        [TestCase(6, "g")]
        [TestCase(7, "h")]
        public void Raw_Column_Values_Should_Correctly_Translate_To_Chess_Notation(int index, string expectedValue)
        {
            string result = ChessBoardCoordinateTranslator.TranslateColumnIndexToDisplay(index);
            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [TestCase(0, 'a')]
        [TestCase(1, 'b')]
        [TestCase(2, 'c')]
        [TestCase(3, 'd')]
        [TestCase(4, 'e')]
        [TestCase(5, 'f')]
        [TestCase(6, 'g')]
        [TestCase(7, 'h')]
        public void Display_Column_Values_Should_Correctly_Translate_To_Raw_Notation(int expectedValue, char index)
        {
            int result = ChessBoardCoordinateTranslator.TranslateColumnDisplayToIndex(index);
            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [TestCase(-1)]
        [TestCase(8)]
        public void Raw_Column_Values_Should_Translate_To_An_Empty_String_If_Index_Is_Not_Valid(int index)
        {
            string result = ChessBoardCoordinateTranslator.TranslateColumnIndexToDisplay(index);
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [TestCase(0, "1")]
        [TestCase(7, "8")]
        public void Raw_Row_Value_Should_Translate_To_Its_Equivalent_Plus_One(int index, string expectedValue)
        {
            string result = ChessBoardCoordinateTranslator.TranslateRowIndexToDisplay(index);
            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [TestCase(0, '1')]
        [TestCase(7, '8')]
        public void Display_Row_Value_Should_Translate_To_Its_Equivalent_Minus_One(int expectedValue, char index)
        {
            int result = ChessBoardCoordinateTranslator.TranslateRowDisplayToIndex(index);
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}