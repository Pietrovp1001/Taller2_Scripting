using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_2
{
    internal class Player
    {
        private List<Card> deck = new List<Card>();
        private int barajaCp;

        public Player(List<Card> deck, int barajacp)
        {
            Deck = deck;
            BarajaCp = barajacp;
        }

        public int BarajaCp { get => barajaCp; set => barajaCp = value; }
        internal List<Card> Deck { get => deck; set => deck = value; }       
             
        public void AñadirCartas()
        {
            List<Equip> EquipCharacter1 = new List<Equip>();
            Character CartaCharacter_1 = new Character("Ceberus", "UltraRare", 1, 10, 40, EquipCharacter1,"Knight") ;

            List<Equip> EquipCharacter2 = new List<Equip>();
            Character CartaCharacter_2 = new Character("Campillo", "SuperRare", 1, 5, 30, EquipCharacter2, "Mage");

            List<Equip> EquipCharacter3 = new List<Equip>();
            Character CartaCharacter_3 = new Character("Manolito", "Rare", 1, 5, 20, EquipCharacter3, "Undead");

            List<Equip> EquipCharacter4 = new List<Equip>();
            Character CartaCharacter_4 = new Character("Victor", "Common", 1, 5, 10, EquipCharacter4, "Knight");

            List<Equip> EquipCharacter5 = new List<Equip>();
            Character CartaCharacter_5 = new Character("Cristian", "UltraRare", 1, 5, 10, EquipCharacter5, "Undead");

            Equip CartaEquip1 = new Equip("Sword", "Common", 1, "AP" , 2, "Knight");
            Equip CartaEquip2 = new Equip("Shield", "Rare", 1, "RP", 3, "Mage");
            Equip CartaEquip3 = new Equip("Armature", "SuperRare", 1, "ALL", 4, "Undead");
            Equip CartaEquip4 = new Equip("Helmet", "UltraRare", 1, "RP", 5, "Knight");
            Equip CartaEquip5 = new Equip("Boots", "UltraRare", 1, "ALL", 5, "ALL");
            Equip CartaEquip6 = new Equip("Book", "UltraRare", 1, "ALL", 5, "ALL");
            Equip CartaEquip7 = new Equip("Katana", "Common", 1, "ALL", 2, "Knight");
            Equip CartaEquip8 = new Equip("Magic shield", "SuperRare", 1, "RP", 4, "Mage");
            Equip CartaEquip9 = new Equip("Magic sword", "Rare", 1, "AP", 3, "Undead");
            Equip CartaEquip10 = new Equip("Magic armature", "UltraRare", 1, "ALL", 5, "ALL");

            Support_Skill support_Skill1 = new Support_Skill("Infect", "Common", 1, "ReduceRP", 2);
            Support_Skill support_Skill2 = new Support_Skill("Fire Ball", "Rare", 1, "ReduceALL", 3);
            Support_Skill support_Skill3 = new Support_Skill("Puñalada al esternon", "SuperRare", 1, "DestroyEquip", 4);
            Support_Skill support_Skill4 = new Support_Skill("Escupitajo", "UltraRare", 1, "ReduceAP", 5);
            Support_Skill support_Skill5 = new Support_Skill("Poción Magica", "UltraRare", 1, "RestoreRP", 5);

            deck.Add(CartaCharacter_1);
            deck.Add(CartaCharacter_2);
            deck.Add(CartaCharacter_3);
            deck.Add(CartaCharacter_4);
            deck.Add(CartaCharacter_5);
            
            deck.Add(CartaEquip1);
            deck.Add(CartaEquip2);
            deck.Add(CartaEquip3);
            deck.Add(CartaEquip4);
            deck.Add(CartaEquip5);
            deck.Add(CartaEquip6);
            deck.Add(CartaEquip7);
            deck.Add(CartaEquip8);
            deck.Add(CartaEquip9);
            deck.Add(CartaEquip10);

            deck.Add(support_Skill1);
            deck.Add(support_Skill2);
            deck.Add(support_Skill3);
            deck.Add(support_Skill4);
            deck.Add(support_Skill5);
           
        }
        public void Atacar(Card CartaAtaque, Character Objetivo)
        {
            if (CartaAtaque is Character)
            {
                Character CharacterTemporal = CartaAtaque as Character;


                if (CharacterTemporal.AttackPoint == Objetivo.AttackPoint)
                {
                    if (CharacterTemporal.Affinity == "Mage" && Objetivo.Affinity == "Undead")
                    {
                        CharacterTemporal.AttackPoint = CharacterTemporal.AttackPoint + 1;
                        Objetivo.ResistPoints = Objetivo.ResistPoints - 1;
                    }
                    else if (CharacterTemporal.Affinity == "Undead" && Objetivo.Affinity == "Knight")
                    {
                        CharacterTemporal.AttackPoint = CharacterTemporal.AttackPoint + 1;
                        Objetivo.ResistPoints = Objetivo.ResistPoints - 1;
                    }
                    else if (CharacterTemporal.Affinity == "Knight" && Objetivo.Affinity == "Mage")
                    {
                        CharacterTemporal.AttackPoint = CharacterTemporal.AttackPoint + 1;
                        Objetivo.ResistPoints = Objetivo.ResistPoints - 1;
                    }
                    else
                    {
                        CharacterTemporal.AttackPoint = CharacterTemporal.AttackPoint - 1;
                        Objetivo.ResistPoints = Objetivo.ResistPoints + 1;
                    }
                }

                if (CharacterTemporal.AttackPoint > Objetivo.AttackPoint)
                {
                    Objetivo.ResistPoints = Objetivo.ResistPoints - CharacterTemporal.AttackPoint;
                }

                if (CharacterTemporal.AttackPoint < Objetivo.AttackPoint)
                {
                    CharacterTemporal.ResistPoints = CharacterTemporal.ResistPoints - Objetivo.AttackPoint;
                }
            }
            else if (CartaAtaque is Support_Skill)
            {
                Support_Skill SupportSkillTemporal = CartaAtaque as Support_Skill;
                if (SupportSkillTemporal.TypeEffect == "ReduceAP")
                {
                    Objetivo.AttackPoint = Objetivo.AttackPoint - SupportSkillTemporal.EffectPoints;
                }
                else if (SupportSkillTemporal.TypeEffect == "ReduceRP")
                {
                    Objetivo.ResistPoints = Objetivo.ResistPoints - SupportSkillTemporal.EffectPoints;
                }
                else if (SupportSkillTemporal.TypeEffect == "DestroyEquip")
                {
                                                 

                }
                else if (SupportSkillTemporal.TypeEffect == "ReduceALL")
                {
                    Objetivo.AttackPoint = Objetivo.AttackPoint - SupportSkillTemporal.EffectPoints;
                    Objetivo.ResistPoints = Objetivo.ResistPoints - SupportSkillTemporal.EffectPoints;
                    
                }
                else if (SupportSkillTemporal.TypeEffect == "RestoreRP")
                {

                }
            }
                  
        }      
    }
}
