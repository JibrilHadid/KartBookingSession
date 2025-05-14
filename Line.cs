using System;

public class Line(int s, char p)
{

    public int MyProperty { get; set; }

    public char pattern { get; set; }
    public void draw()
    {
        for (int i = 1; i <= s; i++)
        { Console.Write(p); }
        Console.WriteLine();
        

    } // draw method
      // Line class


}
