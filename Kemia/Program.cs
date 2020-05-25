using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kemia
{
    class Program
    {
        static List<KemiaAdat> kemia;
        static string bekertVegyjel = "";

        static void Main(string[] args)
        {

            //2. feladat
            kemia = new List<KemiaAdat>();

            StreamReader sr = new StreamReader("felfedezesek.csv");
            string fejlec = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                KemiaAdat k = new KemiaAdat(sor);
                kemia.Add(k);
            }
            sr.Close();

            //3. feladat

            Console.Write("3. feladat: ");
            Console.WriteLine($"Elemek száma: {kemia.Count}");

            //4. feladat

            Console.Write("4. feladat: ");
            Console.WriteLine($"Felfedezések száma az ókorban: {kemia.Count(x=>x.Ev.Contains("kor"))}");

            //5.feladat

            bool nemjo = true;
            
            while (nemjo)
            {

                Console.Write("5. feladat: ");
                Console.Write("Kérek egy vegyjelet: ");
                string vegyjel = Console.ReadLine();
                if (VegyjelEllenorzes(vegyjel) == true)
                {
                    nemjo = false;
                    bekertVegyjel = vegyjel;
                }
                else
                {
                    nemjo = true;
                }
                
            }
            
            bool VegyjelEllenorzes(string input)
            {
                char[] jel = input.ToCharArray();
                bool helyes = true;
                if (jel.Length > 2)
                {
                    helyes = false;
                }
                
                if (jel.Length == 1)
                {
                    if (!(jel[0] >= 65 && jel[0] <= 90 || jel[0] >= 97 && jel[0] <= 122))
                    {
                        helyes = false;
                    }
                }
                if (jel.Length == 2)
                {
                    if (!(jel[0] >= 65 && jel[0] <= 90 || jel[0] >= 97 && jel[0] <= 122))
                    {
                        helyes = false;
                    }
                    if (!(jel[1] >= 65 && jel[1] <= 90 || jel[1] >= 97 && jel[1] <= 122))
                    {
                        helyes = false;
                    }
                }
                return helyes;
            }

            //6. feladat

            Console.WriteLine("6. feladat: Keresés");
            if (kemia.Exists(x=>x.Vegyjel.ToLower() == bekertVegyjel.ToLower()) == true)
            {
                KemiaAdat keresett = kemia.Find(x => x.Vegyjel.ToLower() == bekertVegyjel.ToLower());
                Console.WriteLine($"\tAz elem vegyjele: {keresett.Vegyjel}");
                Console.WriteLine($"\tAz elem neve: {keresett.ElemNev}");
                Console.WriteLine($"\tRendszáma: {keresett.Rendszam}");
                Console.WriteLine($"\tFelfedezés éve: {keresett.Ev}");
                Console.WriteLine($"\tFelfedező: {keresett.Felfedezo}");
            }
            else
            {
                Console.WriteLine("\tNincs ilyen elem az adatforrásban!");
            }


            //7. feladat

            List<KemiaAdat> okorUtan = new List<KemiaAdat>();
            foreach (var item in kemia)
            {
                if (item.Ev.Contains("kor") == false)
                {
                    okorUtan.Add(item);
                }
            }

            int leghosszabb = 0;


            while (okorUtan.Count >= 2)
            {
                KemiaAdat egy = okorUtan.ElementAt(0);
                KemiaAdat ketto = okorUtan.ElementAt(1);

                if (int.Parse(ketto.Ev) - int.Parse(egy.Ev) > leghosszabb)
                {
                    leghosszabb = int.Parse(ketto.Ev) - int.Parse(egy.Ev);
                }

                okorUtan.Remove(egy);
                okorUtan.Remove(ketto);
            }

            Console.WriteLine($"7.feladat: {leghosszabb} év volt a leghosszabb időszak két elem felfedezéseközött.");


            //8.feladat

            Console.WriteLine("8. feladat statisztika");

            List<KemiaAdat> okorNelkuli = new List<KemiaAdat>();
            foreach (var item in kemia)
            {
                if (item.Ev.Contains("kor") == false)
                {
                    okorNelkuli.Add(item);
                }
           }

            Dictionary<string, int> stat = new Dictionary<string, int>();
            foreach (var item in okorNelkuli)
            {
                if (!stat.ContainsKey(item.Ev))
                {
                    stat.Add(item.Ev, 1);
                }
                else
                {
                    stat[item.Ev]++;
                }
            }

            foreach (var item in stat)
            {
                if (item.Value > 3)
                {
                    Console.WriteLine($"\t{item.Key}: {item.Value} db");
                }
            }

            Console.ReadKey();
        }
    }
}
