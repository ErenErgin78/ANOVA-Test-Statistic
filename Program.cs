using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int k = 1;
        int n = 0;
        float[] r, Ort;
        float OrtOrt, SST, SSE, MST, MSE, F;
        Dictionary<int, List<float>> gruplar = [];

        Console.WriteLine("Elemanları eklemek için sayıları boşluk ile ayırın. Enter'a bastığınızda yeni gruba geçecek.");
        Console.WriteLine("Eğer yeni bir grup olmayacaksa elemanları yazdıktan sonra nokta işareti koyun.\n");


        //Kullanıcıdan değerleri al
        while (true)
        {
            Console.WriteLine($"{k}. Grup: ");

            string? input = Console.ReadLine();
            string[] değerler = input.Split(' ');

            List<float> grupListe = [];

            foreach (string number in değerler)
            {
                if (!string.IsNullOrWhiteSpace(number) && float.TryParse(number, out float num))
                {
                    grupListe.Add(num);
                    n++;
                    Console.WriteLine();
                }
                else if (!string.IsNullOrWhiteSpace(number)) { Console.WriteLine($"'{number}' geçerli bir sayı değil ve eklenemedi."); }
            }

            gruplar[k] = grupListe;

            if (input.EndsWith('.')) break;

            k++;
        }

        // r --> bir gruptaki eleman sayısı
        r = new float[k];
        Ort = new float[k];

        float toplam = 0;
        for (int i = 1; i <= k; i++)
        {
            r[i - 1] = gruplar[i].Count;
            for (int j = 1; j <= r[i - 1]; j++) { toplam += gruplar[i][j - 1]; }

            //Her grubun ortalaması hesaplandı
            Ort[i - 1] = toplam / r[i-1];
            toplam = 0;
        }

        //Ortalamaların ortalaması hesaplandı
        for (int i = 1; i <= k; i++) { toplam += Ort[i-1]; }
        OrtOrt = toplam / k;
        toplam = 0;


        //SST hesaplandı
        for(int i = 1; i <= k; i++) { toplam += r[i-1] * ((Ort[i-1]-OrtOrt) * (Ort[i - 1] - OrtOrt)); }
        SST = toplam;
        toplam = 0;


        //SSE hesaplandı
        for (int i = 1; i <= k; i++)
        {
            for (int j = 0; j < r[i - 1]; j++) { toplam += (gruplar[i][j] - Ort[i - 1]) * (gruplar[i][j] - Ort[i - 1]); }
        }
        SSE = toplam;

        //MST, MSE ve F
        MST = SST / (k - 1);
        MSE = SSE / (n - k);
        F = MST / MSE;

        Console.Clear();
        Console.WriteLine("MST: " + MST);
        Console.WriteLine("MSE: " + MSE);
        Console.WriteLine("F: " + F);
        

    }
}
