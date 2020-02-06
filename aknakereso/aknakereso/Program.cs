using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aknakereso
{
    class Program
    {
        
        static void Main(string[] args)
        {
            char[,] pálya = new char[10, 10];
            Feltöltés(pálya);
            Kirajzoló(pálya);
            Tippelő(pálya);

            Console.ReadKey();
        }
        static void Feltöltés(char[,] pálya)
        {
            for (int i = 0; i < pálya.GetLength(0); i++)
			{
               for (int j = 0; j < pálya.GetLength(1); j++)
               {
                    pálya[i, j] = '_';
               }
			}
            Random gép = new Random();
            int sor, oszlop;
            
            for (int i = 0; i < 10; i++)
            {
                do
                {
                    sor = gép.Next(10);
                    oszlop = gép.Next(10);

                } while (pálya[sor,oszlop]=='B');
                pálya[sor, oszlop] = 'B';
            }
        }
        static void Kirajzoló(char[,]pálya)
        {
            for (int sor = 0; sor < pálya.GetLength(0); sor++)
            {
                for (int oszlop = 0; oszlop < pálya.GetLength(1); oszlop++)
                {
                    Console.Write($"{pálya[sor,oszlop]}|");
                }
                Console.WriteLine();
            }
        }
        static void Tippelő(char[,]pálya)
        {
            Console.WriteLine("Kérem a sor tippet 1-10 között:");
            int sortipp = int.Parse(Console.ReadLine());
            Console.WriteLine("Kérem az oszlop tippet 1-10 között:");
            int oszloptipp = int.Parse(Console.ReadLine());
            for (int i = 0; i < sortipp.Length; i++)
			{
               for (int j = 0; j < oszloptipp.Length; j++)
               {
                    pálya[i, j] = '_';
               }
			}
            Console.Write("X");
            for (int i = sortipp; i < pálya.GetLength(0); i++)
			{
               for (int j = oszloptipp; j < pálya.GetLength(1); j++)
               {
                    pálya[i, j] = '_';
               }
			}
            Kirajzoló(pálya);
        }
    }
}
