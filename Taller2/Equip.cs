using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_2
{
    internal class Equip : Card
    {
        public string TargetAttribute;
        public int EffectivePoints;
        public string Affinity;

        public Equip(string name, string rarity, int costPoints, string targetAttribute, int effectivePoints, string affinity) : base(name, rarity, costPoints)
        {
            TargetAttribute = targetAttribute;
            EffectivePoints = effectivePoints;
            Affinity = affinity;
        }

        public string TargetAttribute1 { get => TargetAttribute; set => TargetAttribute = value; }
        public int EffectivePoints1 { get => EffectivePoints; set => EffectivePoints = value; }
        public string Affinity1 { get => Affinity; set => Affinity = value; }
    }

   


}
