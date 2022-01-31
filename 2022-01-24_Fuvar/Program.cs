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


            /*
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






                Console.ReadKey();
        }
    }
}
