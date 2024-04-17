using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace feleves_feladat_TQPGSS
{
    class Terkep
    {
        int[,] tabla;

        public int[,] Betoltes(string fajlnev)
        {
            string[] adatok = File.ReadAllLines(fajlnev);
            tabla = new int[adatok.Length, adatok[0].Length];
            for (int i = 0; i < adatok.Length; i++)
            {
                for (int j = 0; j < adatok[i].Length; j++)
                {
                    tabla[i, j] = (int)adatok[i][j] - 48;

                }
            }

            //Kiir(tabla);
            return tabla;
        }

        public void Kiir(int[,] matrix)
        {
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                Console.ResetColor();
                
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    if (tabla[i,j]==-1)
                    {
                        //helyes utvonal
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write("  ");
                    }
                    else
                    {
                        if (tabla[i, j] == 1)
                        {
                            //beton
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write("  ");
                        }
                        else
                        {
                            if (tabla[i, j] == 2)
                            {
                                //foldut
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write("  ");
                            }
                            else
                            {
                                if (tabla[i, j] == 3)
                                {
                                    //erdei ut
                                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                                    Console.Write("  ");
                                }
                                else
                                {
                                    if (tabla[i, j] == 4)
                                    {
                                        //erdo
                                        Console.BackgroundColor = ConsoleColor.Green;
                                        Console.Write("  ");
                                    }
                                    else
                                    {
                                        if (tabla[i, j] == 5)
                                        {
                                            //szikla
                                            Console.BackgroundColor = ConsoleColor.DarkRed;
                                            Console.Write("  ");
                                        }
                                        else
                                        {
                                            if (tabla[i, j] == 6)
                                            {
                                                //ingatlan
                                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                                Console.Write("  ");
                                            }
                                            else
                                            {
                                                //szakadek
                                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                                Console.Write("  ");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
