using System;
using System.Net.NetworkInformation;

namespace Save_the_ocean
{
    public abstract class Animal
    {
        const string DEF_NAME = "Animal per defecte", DEF_SUPERFAMILIA = "Superfamília per defecte", DEF_ESPECIE = "Especie per defecte";
        const double DEF_PES = 15.5;

        public string Nom { get; set; }
        public string SuperFamilia { get; set; }
        public string Especie { get; set; }
        public double Pes { get; set; }

        Animal(string nom, string superFamilia, string especie, double pes)
        {
            Nom = nom;
            SuperFamilia = superFamilia;
            Especie = especie;
            Pes = pes;
        }

        Animal() : this(DEF_NAME, DEF_SUPERFAMILIA, DEF_ESPECIE, DEF_PES)
        {

        }

        public abstract int CalculateNewGa(int ga, int x);

        public int GetXP(int ga)
        {
            if (ga >= 5)
            {
                return -20;
            }
            return 50;
        }
    }
}
