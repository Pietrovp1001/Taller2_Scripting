using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_2
{
    internal class Support_Skill : Card
    {
        public string TypeEffect;
        public int EffectPoints;
       
        public Support_Skill(string name, string rarity, int costPoints, string typeEffect, int effectPoints) : base(name, rarity, costPoints)
        {
            TypeEffect = typeEffect;
            EffectPoints = effectPoints;
        }
    }
}
