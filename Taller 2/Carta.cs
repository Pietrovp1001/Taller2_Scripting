using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_2
{
    internal class Carta
    {
        private string name;
        private string[] rarity = new string[4] { "common", "rare", "super rare", "Ultra Rare" };
        private int costPoints;

        public string Name { get => name; set => name = value; }
        public string[] Rarity { get => rarity; set => rarity = value; }
        public int CostPoints { get => costPoints; set => costPoints = value; }

        public Carta(string name, string[] rarity, int costPoints)
        {
            Name = name;
            Rarity = rarity;
            CostPoints = costPoints;
        }
    }
    
}
