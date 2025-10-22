using System;

class Program
{
    static void Main()
    {
        string metn = "Salam dünya, proqramlaşdırma çox maraqlıdır";

      
        string[] sozler = metn.Split(' ');

        string enUzunSoz = "";
        int maxUzunluq = 0;

        for (int i = 0; i < sozler.Length; i++)
        {
            if (sozler[i].Length > maxUzunluq)
            {
                maxUzunluq = sozler[i].Length;
                enUzunSoz = sozler[i];
            }
        }

        Console.WriteLine("Ən uzun söz: " + enUzunSoz);
    }
}
