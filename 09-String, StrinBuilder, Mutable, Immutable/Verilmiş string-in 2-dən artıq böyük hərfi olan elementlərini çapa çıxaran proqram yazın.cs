using System;

class Program
{
    static void Main()
    {
        string metn = "Bu nümunədə BÖYÜK və kiçik sözlər VAR ABCD";

       
        string[] sozler = metn.Split(' ');

        for (int i = 0; i < sozler.Length; i++)
        {
            string soz = sozler[i];
            int boyukHarfSayi = 0;

           
            for (int j = 0; j < soz.Length; j++)
            {
                if (char.IsUpper(soz[j]))
                {
                    boyukHarfSayi++;
                }
            }

            if (boyukHarfSayi > 2)
            {
                Console.WriteLine($"Söz: {soz}");
            }
        }
    }
}
