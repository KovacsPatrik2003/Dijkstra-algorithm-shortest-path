using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_feladat_TQPGSS
{
    public class Poziciok
    {
        int ertek;
        int hosszusag;
        int szelesseg;
        bool vanE;
        Poziciok utSeged;
        public Poziciok(int ertek, int hosszusag, int szelesseg)
        {
            Ertek = ertek;
            this.Hosszusag = hosszusag;
            this.Szelesseg = szelesseg;
            VanE = false;
            UtSeged = null;
            
        }

        public int Ertek { get => ertek; set => ertek = value; }
        public int Hosszusag { get => hosszusag; set => hosszusag = value; }
        public int Szelesseg { get => szelesseg; set => szelesseg = value; }
        public bool VanE { get => vanE; set => vanE = value; }
        public Poziciok UtSeged { get => utSeged; set => utSeged = value; }
    }
}
