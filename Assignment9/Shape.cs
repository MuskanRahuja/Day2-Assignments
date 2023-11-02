namespace AbstractClassInterfaceDemo
{
    abstract class Shape
    {
        protected int area;
        public abstract void GetDimensions();
        public abstract void CalculateArea();
        public void DisplayArea()
        {
            Console.WriteLine("Area is " + area);
        }
    }
    class Square : Shape
    {
        int side;

        public override void CalculateArea()
        {
            area = side * side;
        }

        public override void GetDimensions()
        {
            Console.WriteLine("Enter side");
            side = Byte.Parse(Console.ReadLine());
        }
    }
    class Rectangle : Shape
    {
        int length, breadth;

        public override void GetDimensions()
        {
            Console.WriteLine("Enter length");
            length = Byte.Parse(Console.ReadLine());
            Console.WriteLine("Enter breadth");
            breadth = Byte.Parse(Console.ReadLine());
        }
        public override void CalculateArea()
        {
            area = length * breadth;
        }


    }




    class CheckShape
    {
        public void Checkshape(Shape shape)
        {
            if (shape is Square)
            {
                shape = (Square)shape;

            }
            else if (shape is Rectangle)
            {
                shape = (Rectangle)shape;

            }
            shape.GetDimensions();
            shape.CalculateArea();
            shape.DisplayArea();
        }
    }
}