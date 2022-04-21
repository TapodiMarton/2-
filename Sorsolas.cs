using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vizsgagyakorlas

{
    class Sorsolas
    {
        public int hat;
        public int szam1;
        public int szam2;
        public int szam3;
        public int szam4;
        public int szam5;


        public Sorsolas(string hat, string szam1, string szam2, string szam3, string szam4, string szam5)
        {
            this.hat = int.Parse(hat);
            this.szam1 = int.Parse(szam1);
            this.szam2 = int.Parse(szam2);
            this.szam3 = int.Parse(szam3);
            this.szam4 = int.Parse(szam4);
            this.szam5 = int.Parse(szam5);

        }
    }
}
