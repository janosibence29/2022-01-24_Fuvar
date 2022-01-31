﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2022_01_24_Fuvar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fuvar> fuvarok = new List<Fuvar>();

            foreach (var sor in File.ReadAllLines("fuvar.csv").Skip(1))
            {
                fuvarok.Add(new Fuvar(sor));
            }

            Console.WriteLine($"3. feladat: {fuvarok.Count} fuvar");

            double Bevétel = 0;
            int db = 0;
            foreach (var f in fuvarok)
            {
                if (f.TaxiId == 6185)
                {
                    Bevétel += f.Viteldíj + f.Borravaló;
                    db++;
                }
            }
            Console.WriteLine($"4. feladat: {db} fuvar alatt: {Bevétel}");


            /* 5a
            int bankartyás = 0;
            int készpénz = 0;

            foreach (var f in fuvarok)
            {
                if (f.FizetésMód == "bankkártya")
                {
                    bankartyás++;
                }
                if (f.FizetésMód == "készpénz")
                {
                    készpénz++;
                }
            }*/

            // 5b
            Dictionary<string, int> stat = new Dictionary<string, int>();
            foreach (var f in fuvarok)
            {
                if (stat.ContainsKey(f.FizetésMód))
                {
                    stat[f.FizetésMód]++;
                }
                else
                {
                    stat.Add(f.FizetésMód, 1);
                }
            }
            Console.WriteLine($"5. feladat: ");
            foreach (var s in stat)
            {
                Console.WriteLine($"\t{s.Key}: {s.Value} fuvar");
            }

            // 5c
            /*
            fuvarok
                .GroupBy(x => x.FizetésMód)
                .Select(g => new { fizetésmód = g.Key, db = g.Count() })
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.fizetésmód}: {x.db} fuvar"));
            
                Console.ReadKey();
            */
        }
    }
}
