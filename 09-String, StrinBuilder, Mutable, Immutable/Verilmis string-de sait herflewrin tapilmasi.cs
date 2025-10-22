using System;

namespace StringTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            VowelFinder finder = new VowelFinder();
            finder.FindVowelsInSentence();
        }
    }

    public class VowelFinder
    {
        public void FindVowelsInSentence()
        {
            Console.Write("Bir cümlə daxil edin: ");
            string sentence = Console.ReadLine();

           
            string vowels = "aAeEiIıİoOöÖuUüÜəƏ";

            string foundVowels = "";
             
            int count = 0;

            
            for (int i = 0; i < sentence.Length; i++)
            {
                string c = sentence[i].ToString(); 

             
                if (vowels.Contains(c))
                {
                    foundVowels += c + ",";
                    count++;
                }
            }

      
            if (foundVowels.Length > 0)
                Console.WriteLine($"Cümlədəki saitlər: {foundVowels.Trim()}");
            else
                Console.WriteLine("Cümlədə sait yoxdur.");

            Console.WriteLine("Cümlədəki saitlərin sayı", count);
        }
    }
}
