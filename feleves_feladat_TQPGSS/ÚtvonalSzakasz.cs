using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_feladat_TQPGSS
{
    class ÚtvonalSzakasz : IComparable
    {
        
        public enum Tipus { betonUt=1, foldUt, erdeiOsveny, erdo}

        public int CompareTo(object obj)
        {
            if ((int)obj==(int)Tipus.betonUt)
            {
                return 1;
            }
            else
            {
                if ((int)obj==(int)Tipus.foldUt)
                {
                    return 2;
                }
                else
                {
                    if ((int)obj == (int)Tipus.erdeiOsveny)
                    {
                        return 3;
                    }
                    else
                    {
                        if ((int)obj == (int)Tipus.erdo)
                        {
                            return 4;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
        }

        public int Nehézség(int[,] tabla, int hosszusag, int szelesseg)
        {
            
            return CompareTo(tabla[hosszusag,szelesseg]);
        }

        public override string ToString()
        {
            return $"Utvonal szakasz tostring";
        }

        //public int UtszakaszErteke(int[,] ut)
        //{
        //    int ertek = 0;
        //    for (int i = 0; i < ut.GetLength(1); i++)
        //    {
        //        ertek += Nehézség(ut,ut[i, 0], ut[i, 1]);
        //    }
        //    return ertek;
        //}

        
    }
}
