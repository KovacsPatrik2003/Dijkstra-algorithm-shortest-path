using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleves_feladat_TQPGSS
{
    class BinarisKeresoFa
    {
        class Node
        {
            public LancoltLista<Poziciok> value;
            public Node left;
            public Node right;
        }
        Node root;

        void PrivateAdd(ref Node p, LancoltLista<Poziciok> value)
        {
            if (p == null)
            {
                p = new Node();
                p.value = value;
            }
            else
            {
                int compare = p.value.fej.tartalom.Ertek.CompareTo(value.fej.tartalom.Ertek);
                if (compare == 1)
                {
                    PrivateAdd(ref p.left, value);
                }
                else
                {
                    if (compare == -1)
                    {
                        PrivateAdd(ref p.right, value);
                    }
                }
            }
        }

        public void Add(LancoltLista<Poziciok> value)
        {
            PrivateAdd(ref root, value);
        }

        public void PreOrder(int hosszusag,int szelesseg)
        {
            PrivatePreOrder(ref root,hosszusag,szelesseg);
        }
        public event Kimenet nehezseg;
        void PrivatePreOrder(ref Node p, int hosszusag,int szelesseg)
        {
            if (p != null)
            {
                LancoltLista<Poziciok> seged = p.value;
                while (seged.fej!=null)
                {
                    if (seged.fej.tartalom.Hosszusag==hosszusag && seged.fej.tartalom.Szelesseg==szelesseg)
                    {
                        if (seged.fej.tartalom.Ertek==int.MaxValue)
                        {
                            throw new NemMegkozelitheto("A helyszín sajnos nem megkozelitheto!");
                        }
                        nehezseg?.Invoke(p.value.fej.tartalom.Ertek);
                    }
                    seged.fej = seged.fej.kovetkezo;
                }
                
                PrivatePreOrder(ref p.left,hosszusag,szelesseg);
                PrivatePreOrder(ref p.right,hosszusag,szelesseg);
            }
        }

    }


}
