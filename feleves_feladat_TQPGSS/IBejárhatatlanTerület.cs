using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace feleves_feladat_TQPGSS
{
    interface IBejárhatatlanTerület
    {
        public string Nev { get; set; }
        public int Szelesseg { get; set; }
        public int Hosszusag { get; set; }
    }
}
