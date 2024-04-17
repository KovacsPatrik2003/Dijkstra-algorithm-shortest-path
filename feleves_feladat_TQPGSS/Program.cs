using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace feleves_feladat_TQPGSS
{
    public delegate void Kimenet(int nehezseg);
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Terkep terkep= new Terkep();
            int[,] matrix=terkep.Betoltes("nagyterkep.txt");
            Graf<Poziciok> g = new Graf<Poziciok>();
            
            
            terkep.Kiir(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]<=4)
                    {
                        g.CsucsFelvetel(new Poziciok(matrix[i, j], i, j));
                    }
                }
            }
            int szamlalo = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] <= 4)
                    {
                        if (i - 1 >= 0 && matrix[i - 1, j] <= 4)
                        {
                            Poziciok uj = new Poziciok(matrix[i - 1,j], i-1,j);
                            g.ElFelvetel(g.Tartalom[szamlalo], uj);
                        }
                        if (j - 1 >= 0 && matrix[i, j - 1] <= 4)
                        {
                            Poziciok uj = new Poziciok(matrix[i, j - 1], i, j - 1);
                            g.ElFelvetel(g.Tartalom[szamlalo], uj);
                        }
                        if (i+1<matrix.GetLength(0) && matrix[i+1,j]<=4)
                        {
                            Poziciok uj = new Poziciok(matrix[i + 1, j], i + 1, j);
                            g.ElFelvetel(g.Tartalom[szamlalo], uj);
                        }
                        if (j+1<matrix.GetLength(1) && matrix[i,j+1]<=4)
                        {
                            Poziciok uj = new Poziciok(matrix[i, j + 1], i, j + 1);
                            g.ElFelvetel(g.Tartalom[szamlalo], uj);
                        }
                        szamlalo++;
                    }
                    
                }
            }
            Console.WriteLine($"Hosszusag koordinatak: 0-{matrix.GetLength(0) - 1}");
            Console.WriteLine($"Szelesseg koordinatak: 0-{matrix.GetLength(1) - 1}");
            Console.Write($"Adja meg a START koordinatait: \nHosszusag: ");
            int hosszusag = int.Parse(Console.ReadLine());
            Console.Write("Szelesseg: ");
            int szelesseg = int.Parse(Console.ReadLine());
            Console.Write($"Adja meg a STOP koordinatait: \nHosszusag: ");
            int hosszusag2 = int.Parse(Console.ReadLine());
            Console.Write("Szelesseg: ");
            int szelesses2 = int.Parse(Console.ReadLine());
            try
            {
                if (matrix[hosszusag, szelesseg] >= 5 || matrix[hosszusag2, szelesses2] >= 5)
                {
                    throw new NemMegkozelitheto("A helyszín sajnos nem megkozelitheto!");
                }
                
                Dijkstra dijkstra = new Dijkstra();
                List<Poziciok> L = dijkstra.DijkstraMegoldas(g, hosszusag, szelesseg);
                szamlalo = 0;
                int[] ertekek = new int[L.Count];
                for (int i = 0; i < ertekek.Length; i++)
                {
                    ertekek[i] = int.MinValue;
                }
                for (int i = 0; i < L.Count; i++)
                {
                    if (!ertekek.Contains(L[i].Ertek))
                    {
                        ertekek[szamlalo] = L[i].Ertek;
                        szamlalo++;
                    }
                }
                LancoltLista<Poziciok>[] egyediListak = new LancoltLista<Poziciok>[szamlalo];
                int k = 0;
                bool peldanyositott = false;
                while (k < szamlalo)
                {
                    for (int j = 0; j < L.Count; j++)
                    {
                        if (L[j].Ertek == ertekek[k])
                        {
                            if (!peldanyositott)
                            {
                                egyediListak[k] = new LancoltLista<Poziciok>();
                                peldanyositott = true;
                            }
                            egyediListak[k].Beszuras(L[j]);
                        }
                    }
                    peldanyositott = false;
                    k++;
                }
                BinarisKeresoFa fa = new BinarisKeresoFa();
                fa.nehezseg += Fa_nehezseg;
                for (int i = 0; i < egyediListak.Length; i++)
                {
                    fa.Add(egyediListak[i]);
                }
                try
                {
                    fa.PreOrder(hosszusag2, szelesses2);
                }
                catch (NemMegkozelitheto e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("\nAz útvonal lépésről lépésre:");
                for (int i = 0; i < L.Count; i++)
                {
                    if (hosszusag2 == L[i].Hosszusag && L[i].Szelesseg == szelesses2)
                    {
                        bool seged = false;
                        Poziciok poz = L[i];
                        while (!seged)
                        {
                            if (poz.UtSeged != null)
                            {
                                Console.WriteLine($"Koordinatak: {poz.Hosszusag} : {poz.Szelesseg}");
                                matrix[poz.Hosszusag, poz.Szelesseg] = -1;
                            }
                            else
                            {
                                Console.WriteLine($"Koordinatak: {poz.Hosszusag} : {poz.Szelesseg}");
                                matrix[poz.Hosszusag, poz.Szelesseg] = -1;
                                seged = true;
                            }
                            poz = poz.UtSeged;
                        }
                    }
                }
                
                terkep.Kiir(matrix);

            }
            catch (NemMegkozelitheto e)
            {

                Console.WriteLine(e.Message);
            }
            
            
        }

        private static void Fa_nehezseg(int nehezseg)
        {
            Console.WriteLine("\nA megadott helyrol a celpontig a legkonnyebb ut nehezsege: " + nehezseg);
        }
    }
}
