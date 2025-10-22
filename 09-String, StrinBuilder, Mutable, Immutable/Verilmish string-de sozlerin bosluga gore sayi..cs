using System;

class Program
{
    static void Main()
    {
        string metn = "Salam bu gun imtahan nece kecdi";

       
        string[] sozler = metn.Split(' ');

        
        int say = 0;
        for (int i = 0; i < sozler.Length; i++)
        {
            if (sozler[i] != "") 
            {
                say++;
            }
        }

        Console.WriteLine("Sözlərin sayı: " + say);
    }
}
