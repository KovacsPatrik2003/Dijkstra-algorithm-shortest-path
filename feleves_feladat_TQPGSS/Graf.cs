using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_feladat_TQPGSS
{
    class Graf<T>
    {
        List<T> tartalom = new List<T>();
        List<List<T>> szomszedsagiLista = new List<List<T>>();
        public List<T> Tartalom { get => tartalom; set => tartalom = value; }
        public List<List<T>> SzomszedsagiLista { get => szomszedsagiLista; set => szomszedsagiLista = value; }

        
        public void CsucsFelvetel(T csucs)
        {
            tartalom.Add(csucs);
            szomszedsagiLista.Add(new List<T>());
        }

        
        public void ElFelvetel(T honnan, T hova) 
        {
            int indexHonnan = tartalom.IndexOf(honnan); 
            int indexHova = tartalom.IndexOf(hova); 

            szomszedsagiLista[indexHonnan].Add(hova); 
            
        }

        
        public bool VezetEl(T honnan, T hova)
        {
            int indexHonnan = tartalom.IndexOf(honnan);
            int indexHova = tartalom.IndexOf(hova);

            return szomszedsagiLista[indexHonnan].Contains(tartalom[indexHova]);
        }

        
        public List<T> Szomszedok(T csucs)
        {
            int index = tartalom.IndexOf(csucs);
            return szomszedsagiLista[index];
        }
        
        
    }
}
