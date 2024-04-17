using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_feladat_TQPGSS
{
    class NemMegkozelitheto : System.Exception
    {
        public NemMegkozelitheto(string uzenet):base(uzenet)
        {
        }
    }
}
