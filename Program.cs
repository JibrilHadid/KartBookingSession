namespace MoreLines
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Line stripe = new Line(10, '+');
            stripe.draw();

            Line stripe2 = new Line(30, '@');
            stripe.draw();
            Line newLine = new Line();
        } // main method
    } // moreLines class
}

