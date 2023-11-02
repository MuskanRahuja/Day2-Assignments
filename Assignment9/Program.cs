using AbstractClassInterfaceDemo;

internal class Program
{
    static void Main(string[] args)
    {

        Shape shape = null;
        Console.WriteLine("Enter shape type");
        int c = Byte.Parse(Console.ReadLine());
        if (c == 1)
        {
            shape = new Square();

        }
        else if (c == 2)
        {
            shape = new Rectangle();

        }
        CheckShape checkShape = new CheckShape();
        checkShape.Checkshape(shape);


    }
}