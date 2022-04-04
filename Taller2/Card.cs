using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_2
{
    internal class Card
    {
        private string name;
        private string rarity;
        private int costPoints;

        public string Name { get => name; set => name = value; }
        public string Rarity { get => rarity; set => rarity = value; }
        public int CostPoints { get => costPoints; set => costPoints = value; }

        public Card(string name, string rarity, int costPoints)
        {
            Name = name;
            Rarity = rarity;
            CostPoints = costPoints;
        }
    }
    
}
