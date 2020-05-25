using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kemia
{
    class KemiaAdat
    {

        public string Ev { get; set; }

        public string ElemNev { get; set; }

        public string Vegyjel { get; set; }

        public int Rendszam { get; set; }

        public string Felfedezo { get; set; }

        public KemiaAdat()
        {

        }

        public KemiaAdat(string sor)
        {
            string[] seged = sor.Split(';');
            Ev = seged[0];
            ElemNev = seged[1];
            Vegyjel = seged[2];
            Rendszam = int.Parse(seged[3]);
            Felfedezo = seged[4];
        }
    }
}
