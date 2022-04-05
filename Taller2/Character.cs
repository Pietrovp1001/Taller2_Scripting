using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_2
{
    internal class Character : Card
    {

        public int AttackPoint;
        public int ResistPoints;
        public List<Equip> EquipCharacter = new List<Equip>();
        public string Affinity;
        public Character(string name, string rarity, int costPoints, int attackPoint, int resistPoints, List<Equip> equipCharacter, string affinity) : base(name, rarity, costPoints)
        {
            AttackPoint1 = attackPoint;
            ResistPoints1 = resistPoints;
            EquipCharacter1 = equipCharacter;
            Affinity1 = affinity;
        }
        
        public int AttackPoint1 { get => AttackPoint; set => AttackPoint = value; }
        public int ResistPoints1 { get => ResistPoints; set => ResistPoints = value; }
        internal List<Equip> EquipCharacter1 { get => EquipCharacter; set => EquipCharacter = value; }
        public string Affinity1 { get => Affinity; set => Affinity = value; }
    }

    
    

}
