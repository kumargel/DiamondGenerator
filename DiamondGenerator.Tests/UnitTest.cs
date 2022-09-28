using System;
using FluentAssertions;
using Xunit;

namespace DiamondGenerator.Tests
{
    public class UnitTest
    {
        [Fact]
        public void Diamond_With_A_produces_A()
        {
            Assert.Equal("A", new Diamond('A').Create());
        }

        [Theory]
        [InlineData('\\')]
        [InlineData('a')]
        [InlineData('b')]
        [InlineData('m')]
        [InlineData('1')]
        [InlineData('2')]
        [InlineData(' ')]
        [InlineData('$')]
        [InlineData('\n')]
        [InlineData('@')]
        [InlineData('#')]
        [InlineData('¬')]
        [InlineData('%')]
        public void Invalid_Char_Throws_Exception(char character)
        {
            Action action = () => new Diamond(character);
            action.Should().Throw<ArgumentException>().WithParameterName("character");
        }

        [Theory]
        [InlineData('A', "A")]
        [InlineData('B', " A \nB B\n A ")]
        [InlineData('C', "  A  \n B B \nC   C\n B B \n  A  ")]
        [InlineData('D', "   A   \n  B B  \n C   C \nD     D\n C   C \n  B B  \n   A   ")]
        public void Valid_Input_Generates_Valid_Diamond(char letter, string expectedResult)
        {
            var result = new Diamond(letter).Create();
            Assert.Equal(expectedResult.Trim(), result.Trim());
        }

        [Theory]
        [InlineData('A', '$', "A")]
        [InlineData('B', '$', "$A$\nB$B\n$A$")]
        [InlineData('C', '-', "--A--\n-B-B-\nC---C\n-B-B-\n--A--")]
        [InlineData('D', '=', "===A===\n==B=B==\n=C===C=\nD=====D\n=C===C=\n==B=B==\n===A===")]
        public void Valid_Input_Generates_Valid_Diamond_With_Correct_Space_Filler(char letter, char spaceFiller, string expectedResult)
        {
            var result = new Diamond(letter).Create(spaceFiller);
            Assert.Equal(expectedResult.Trim(), result.Trim());
        }
    }
}