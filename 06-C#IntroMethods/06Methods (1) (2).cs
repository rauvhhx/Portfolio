using System;

class Program
{
    // 1. Həm 4-ə, həm də 5-ə bölünən elementlərin cəmi
    static void Hem4eVe5eBolunenlerinCemi()
    {
        int[] ededler = { 14, 20, 35, 40, 57, 60, 100 };
        int cem = 0;

        for (int i = 0; i < ededler.Length; i++)
        {
            if (ededler[i] % 4 == 0 && ededler[i] % 5 == 0)
            {
                cem += ededler[i];
            }
        }

        Console.WriteLine("Həm 4-ə, həm də 5-ə bölünən elementlərin cəmi: " + cem);
    }

    // 2. İki ədədin cəmi
    static int Topla(int x, int y)
    {
        return x + y;
    }

    static int OxuEded(string mesaj)
    {
        Console.Write(mesaj);
        return int.Parse(Console.ReadLine());
    }

    static void CemiTap()
    {
        int a = OxuEded("Birinci ədədi daxil edin: ");
        int b = OxuEded("İkinci ədədi daxil edin: ");

        int netice = Topla(a, b);
        Console.WriteLine("Cəmi: " + netice);
    }

    // 3. Çıxma əməliyyatı
    static void CixmaTap()
    {
        Console.Write("Birinci ədədi daxil edin: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("İkinci ədədi daxil edin: ");
        int b = int.Parse(Console.ReadLine());

        int cixma;
        if (a > b)
        {
            cixma = a - b;
            Console.WriteLine($"Birinci ədəd böyükdür, çıxma: {cixma}");
        }
        else if (b > a)
        {
            cixma = b - a;
            Console.WriteLine($"İkinci ədəd böyükdür, çıxma: {cixma}");
        }
        else
        {
            Console.WriteLine("Ədədlər bərabərdir, çıxma 0-dır");
        }
    }

    // 4. Bölmə əməliyyatı
    static void BolmeTap()
    {
        Console.Write("Birinci ədədi daxil edin: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("İkinci ədədi daxil edin: ");
        int b = int.Parse(Console.ReadLine());

        if (a == 0 || b == 0)
        {
            Console.WriteLine("0 ilə bölmə mümkün deyil!");
        }
        else
        {
            double netice;

            if (a > b)
            {
                netice = (double)a / b;
                Console.WriteLine($"Birinci ədəd böyükdür, bölmə: {netice}");
            }
            else if (b > a)
            {
                netice = (double)b / a;
                Console.WriteLine($"İkinci ədəd böyükdür, bölmə: {netice}");
            }
            else
            {
                netice = 1; 
                Console.WriteLine("Ədədlər bərabərdir, bölmə 1-dir");
            }
        }
    }

    // 5. Vurma əməliyyatı
    static void VurmaTap()
    {
        Console.Write("Birinci ədədi daxil edin: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("İkinci ədədi daxil edin: ");
        int b = int.Parse(Console.ReadLine());

        int vurma = a * b;
        Console.WriteLine("Vurma: " + vurma);
    }

    // 6. Simvol sayma
    static void SimvolSay()
    {
        Console.Write("Cümləni daxil edin: ");
        string cumle = Console.ReadLine();

        Console.Write("Axtarılacaq simvolu daxil edin: ");
        char simvol = char.Parse(Console.ReadLine());

        int say = 0;

        for (int i = 0; i < cumle.Length; i++)
        {
            if (cumle[i] == simvol)
            {
                say++;
            }
        }

        Console.WriteLine($"Simvol '{simvol}' cümlədə {say} dəfə təkrarlanıb.");
    }

    // MAIN
    static void Main()
    {
        Hem4eVe5eBolunenlerinCemi();
        CemiTap();
        CixmaTap();
        BolmeTap();
        VurmaTap();
        SimvolSay();
    }
}
