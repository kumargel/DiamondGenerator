using System.Text;

namespace DiamondGenerator
{
    public class Diamond
    {
        private readonly char _character;
        private const char StartLetter = 'A';
        private const string NewLine = "\n";
        private const char DefaultSpaceFiller = ' ';
        private int DiamondHeight => (_character - StartLetter + 1) * 2 - 1;


        public Diamond(char character)
        {
            _character = character;
            character.ThrowIfNotUpperCase(nameof(character));
        }

        public string Create(char spaceFiller = DefaultSpaceFiller)
        {
            if (_character == StartLetter)
            {
                return StartLetter.ToString();
            }

            var result = new StringBuilder();

            // Get the top part first, excluding the middle line, since middle line will be single and will not be plotted in reverse direction 
            var topPart = CreatedDiamondTopPart(spaceFiller);
            result.Append(topPart);

            // Get the middle line, representing the actual character passed
            AddMiddlePart(result, spaceFiller);

            // We already have the top part. No need to go through the whole loop again. Just reverse the top part
            var bottomPart = topPart.Reverse(NewLine);
            result.Append($"{bottomPart}{NewLine}");

            return result.ToString();
        }

        private string CreatedDiamondTopPart(char spaceFiller)
        {
            var totalLength = _character - StartLetter;
            var topDiamondPart = new StringBuilder();
            for (var i = 0; i < totalLength; i++)
            {
                var currentLineCharacter = Convert.ToChar(StartLetter + i);
                var numberOfSpacesAtStartAndEnd = totalLength - i;
                var numberOfSpacesInTheMiddle = DiamondHeight - numberOfSpacesAtStartAndEnd * 2 - 2;

                var startAndEndSpaces = new string(spaceFiller, numberOfSpacesAtStartAndEnd);

                // Add the start spaces
                topDiamondPart.Append(startAndEndSpaces);

                // Add current line character
                topDiamondPart.Append(currentLineCharacter);

                // Add spaces in the middle, if needed
                if (numberOfSpacesInTheMiddle > 0)
                {
                    topDiamondPart.Append(new string(spaceFiller, numberOfSpacesInTheMiddle));

                    // Add current line character
                    topDiamondPart.Append(currentLineCharacter);
                }

                // Add the start spaces, along with new line
                topDiamondPart.Append($"{startAndEndSpaces}{NewLine}");
            }

            return topDiamondPart.ToString();
        }

        private void AddMiddlePart(StringBuilder builder, char spaceFiller)
        {
            builder.Append(_character);
            builder.Append(new string(spaceFiller, DiamondHeight - 2));
            builder.Append($"{_character}{NewLine}");
        }
    }
}