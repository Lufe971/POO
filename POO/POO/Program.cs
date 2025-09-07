using System;

class Program

{

    static void Main(string[] args)

    {

        Time t1 = new Time();

        Time t2 = new Time(2);

        Time t3 = new Time(9, 34);

        Time t4 = new Time(7, 45, 56);

        Time t5 = new Time(11, 3, 45, 678);

        t1.Print(t3, t4);

        t2.Print(t3, t4);

        t3.Print(t3, t4);

        t4.Print(t3, t4);

        t5.Print(t3, t4);

        try

        {

            Time invalid = new Time(45);

        }

        catch (ArgumentException e)

        {

            Console.WriteLine(e.Message);

        }

    }

}

