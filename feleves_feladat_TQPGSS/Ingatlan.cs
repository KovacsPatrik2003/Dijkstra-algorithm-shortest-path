﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_feladat_TQPGSS
{
    class Ingatlan : IBejárhatatlanTerület
    {
        public Ingatlan(string nev, int hosszusag, int szelesseg)
        {
            Nev = nev;
            Szelesseg = szelesseg;
            Hosszusag = hosszusag;
        }

        public string Nev { get; set; }
        public int Szelesseg { get; set; }
        public int Hosszusag { get; set; }
        public override string ToString()
        {
            return $"Ingatlan: {Hosszusag}:{Szelesseg}";
        }
    }
}
