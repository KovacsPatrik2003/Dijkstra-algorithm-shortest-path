using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace feleves_feladat_TQPGSS
{
    class Dijkstra
    {
        private int AdottCsucsIndexe(Graf<Poziciok> G,int h, int sz)
        {
            int szamlalo = 0;
            for (int i = 0; i < G.Tartalom.Count; i++)
            {
                if (G.Tartalom[i].Hosszusag==h && G.Tartalom[i].Szelesseg==sz)
                {
                    return szamlalo;
                }
                szamlalo++;
            }
            return -1;
        }
        public List<Poziciok> DijkstraMegoldas(Graf<Poziciok> G, int hosszusag, int szelesseg)
        {
            List<Poziciok> d = new List<Poziciok>();
            List<Poziciok> s = new List<Poziciok>();
            List<Poziciok> pi=new List<Poziciok>();
            for (int i = 0; i < G.SzomszedsagiLista.Count; i++)
            {
                Poziciok x = G.Tartalom[i];
                d.Add(new Poziciok(int.MaxValue, G.Tartalom[i].Hosszusag, G.Tartalom[i].Szelesseg));
                s.Add(x);
                pi.Add(null);
            }
            d[AdottCsucsIndexe(G, hosszusag, szelesseg)].Ertek = 0;
            int maradek = Maradek(d);
            while (maradek!=0)
            {
                Poziciok u = MinKivesz(d);
                d[AdottCsucsIndexe(G, u.Hosszusag, u.Szelesseg)].VanE = true;
                //s[AdottCsucsIndexe(G, u.Hosszusag, u.Szelesseg)].VanE = true;
                List<Poziciok> segedLista = G.Szomszedok(s[AdottCsucsIndexe(G, u.Hosszusag, u.Szelesseg)]);
                for (int i = 0; i < segedLista.Count; i++)
                {
                    int seged = AdottCsucsIndexe(G, segedLista[i].Hosszusag, segedLista[i].Szelesseg);
                    if (d[AdottCsucsIndexe(G, u.Hosszusag, u.Szelesseg)].Ertek + segedLista[i].Ertek < d[seged].Ertek)
                    {
                        //d[G.Szomszedok(u)[i]].Ertek = d[AdottCsucsIndexe(G, u.Hosszusag, u.Szelesseg)].Ertek + G.Szomszedok(u)[i].Ertek;
                        d[seged].Ertek = d[AdottCsucsIndexe(G, u.Hosszusag, u.Szelesseg)].Ertek + segedLista[i].Ertek;
                        s[seged].Ertek = d[AdottCsucsIndexe(G, u.Hosszusag, u.Szelesseg)].Ertek + segedLista[i].Ertek;
                        //s[seged].VanE = true;
                        d[seged].UtSeged = u;
                    }
                }
                maradek = Maradek(d);
            }
            return d;
        }
        private Poziciok MinKivesz(List<Poziciok> L)
        {
            int min = 0;
            List<Poziciok> seged = new List<Poziciok>();
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].VanE==false)
                {
                    seged.Add(L[i]);
                }
            }
            for (int i = 0; i < seged.Count; i++)
            {
                if (seged[i].Ertek < seged[min].Ertek)
                {
                    min = i;
                }
            }
            return seged[min];
        }
        private int Maradek(List<Poziciok> L)
        {
            int db = 0;
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].VanE == false)
                {
                    db++;
                }
            }
            return db;
        }
    }
}
