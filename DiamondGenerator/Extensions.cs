namespace DiamondGenerator;

public static class Extensions
{
    public static string Reverse(this string stringToReverse, string separator)
    {
        var revertedStringLines = stringToReverse.Split(separator, StringSplitOptions.RemoveEmptyEntries).Reverse();
        var result = string.Join(separator, revertedStringLines);
        return result;
    }

    public static void ThrowIfNotUpperCase(this char letter, string parameter)
    {
        if (!char.IsUpper(letter))
        {
            throw new ArgumentException("Character can only be an uppercase letter.", parameter);
        }
    }
}