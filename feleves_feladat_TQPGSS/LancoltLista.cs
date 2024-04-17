using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_feladat_TQPGSS
{
    
    class LancoltLista<T> where T : class
    {
        public class ListaElem
        {
            public T tartalom;
            public ListaElem kovetkezo;
        }
        public ListaElem fej;
        public void Beszuras(T elem)
        {
            ListaElem uj = new ListaElem();
            uj.tartalom = elem;
            if (fej==null)
            {
                fej = uj;
            }
            else
            {
                ListaElem p = fej;
                while (p.kovetkezo!=null)
                {
                    
                    p = p.kovetkezo;
                }
                p.kovetkezo = uj;
            }
        }
        
    }
}
