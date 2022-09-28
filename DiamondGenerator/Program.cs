// See https://aka.ms/new-console-template for more information

using DiamondGenerator;

Console.WriteLine("Please enter a letter (A-Z) and press enter!");
var key = Console.ReadLine();
if (!string.IsNullOrEmpty(key) && key.Length == 1)
{
    var spaceFiller = ' ';
#if DEBUG
    spaceFiller = '_';
#endif

    try
    {
        var diamond = new Diamond(key[0]);
        Console.WriteLine(diamond.Create(spaceFiller));
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}
else
{
    Console.WriteLine("Invalid input!!");
}