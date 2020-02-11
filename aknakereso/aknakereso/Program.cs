using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aknakereso
{
    class Program
    {
        //Készíts fvényt, ami megadja, hogy az adott hely szomszédjában hány bomba van!
        static void Main(string[] args)
        {
            char[,] pálya = new char[10, 10];
            Feltöltés(pálya);
            BomBasorsoló(pálya);
            Kirajzoló(pálya, false);
            int lépx;
            int lépy;
            do
            {
                Lépés(pálya, out lépx, out lépy);
            } while (pálya[lépx, lépy] != 'B');

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
        }
        static void BomBasorsoló(char[,] pálya)
        {
            Random gép = new Random();
            Console.WriteLine("Add meg a bombák számát:");
            int bombaSzám = int.Parse(Console.ReadLine());
            int sor, oszlop;
            for (int i = 0; i < bombaSzám; i++)
            {
                do
                {
                    sor = gép.Next(10);
                    oszlop = gép.Next(10);
                } while (pálya[sor, oszlop] == 'B');
                pálya[sor, oszlop] = 'B';
            }
        }
        static void Kirajzoló(char[,] pálya, bool legyenBomba)
        {
            for (int i = 0; i < pálya.GetLength(0); i++)
            {
                for (int j = 0; j < pálya.GetLength(1); j++)
                {
                    if (legyenBomba)
                    {
                        Console.Write($"{pálya[i, j]}");
                    }
                    else if (pálya[i, j] != 'X')
                    {
                        Console.Write('_');
                    }
                    Console.Write('|');
                }
                Console.WriteLine();
            }

        }
        static void Lépés(char[,] pálya, out int lépx, out int lépy)
        {
            Console.WriteLine("Kérem a sort:");
            lépx = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Kérem az oszlopot:");
            lépy = int.Parse(Console.ReadLine()) - 1;
            if (pálya[lépx, lépy] == 'B')
            {
                Kirajzoló(pálya, true);
                Console.WriteLine("Felrobbantál!");
            }
            else
            {
                pálya[lépx, lépy] = 'X';
                Kirajzoló(pálya, false);
            }

        }

    }
}
