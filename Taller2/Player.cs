using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_2
{
     class Player
    {
        private List<Card> deck = new List<Card>();
        private int barajaCp;
        private bool vivo;

        public Player(List<Card> deck, int barajacp,bool vivo)
        {
            Deck = deck;
            BarajaCp = barajacp;
            Vivo = vivo;
        }

        public int BarajaCp { get => barajaCp; set => barajaCp = value; }
        internal List<Card> Deck { get => deck; set => deck = value; }
        public bool Vivo { get => vivo; set => vivo = value; }

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
            Character CartaCharacter_5 = new Character("Cristian", "UltraRare", 1, 15, 40, EquipCharacter5, "Undead");

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
            Support_Skill support_Skill3 = new Support_Skill("Puñalada al esternon", "SuperRare", 1, "DestroyEquip", 0);
            Support_Skill support_Skill4 = new Support_Skill("Escupitajo", "UltraRare", 1, "ReduceAP", 2);
            Support_Skill support_Skill5 = new Support_Skill("Poción Magica", "UltraRare", 1, "RestoreRP", 0);

            RestarCP(CartaCharacter_1);
            RestarCP(CartaCharacter_2);
            RestarCP(CartaCharacter_3);
            RestarCP(CartaCharacter_4);
            RestarCP(CartaCharacter_5);

            RestarCP(CartaEquip1);
            RestarCP(CartaEquip2);
            RestarCP(CartaEquip3);
            RestarCP(CartaEquip4);
            RestarCP(CartaEquip5);
            RestarCP(CartaEquip6);
            RestarCP(CartaEquip7);
            RestarCP(CartaEquip8);
            RestarCP(CartaEquip9);
            RestarCP(CartaEquip10);

            RestarCP(support_Skill1);
            RestarCP(support_Skill2);
            RestarCP(support_Skill3);
            RestarCP(support_Skill4);
            RestarCP(support_Skill5);
           
        }
        public void RestarCP(Card Carta)
        {

            if(barajaCp>= Carta.CostPoints)
            {
                deck.Add(Carta);
                barajaCp = barajaCp - Carta.CostPoints;
            }
            
        }


        public void Atacar(Card CartaAtaque, Character Objetivo,Character Atacante,Player jugador,Player Enemigo)
        {
            if (CartaAtaque is Character)
            {
                Character CharacterTemporal = CartaAtaque as Character;


                if (CharacterTemporal.AttackPoint == Objetivo.AttackPoint)
                {
                    if (CharacterTemporal.Affinity == "Mage" && Objetivo.Affinity == "Undead")
                    {
                        CharacterTemporal.AttackPoint = CharacterTemporal.AttackPoint + 1;
                        Objetivo.AttackPoint = Objetivo.AttackPoint - 1;

                        
                    }
                    else if (CharacterTemporal.Affinity == "Undead" && Objetivo.Affinity == "Knight")
                    {
                        CharacterTemporal.AttackPoint = CharacterTemporal.AttackPoint + 1;
                        Objetivo.AttackPoint = Objetivo.AttackPoint - 1;
                    }
                    else if (CharacterTemporal.Affinity == "Knight" && Objetivo.Affinity == "Mage")
                    {
                        CharacterTemporal.AttackPoint = CharacterTemporal.AttackPoint + 1;
                        Objetivo.AttackPoint = Objetivo.AttackPoint - 1;
                    }
                    else
                    {
                        CharacterTemporal.AttackPoint = CharacterTemporal.AttackPoint - 1;
                        Objetivo.AttackPoint = Objetivo.AttackPoint + 1;
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
                CartaAtaque = CharacterTemporal;
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
                    if (Objetivo.EquipCharacter.Count() > 0)//
                    {
                        if (Objetivo.EquipCharacter[0].TargetAttribute == "AP")
                        {
                            Objetivo.AttackPoint = Objetivo.AttackPoint - Objetivo.EquipCharacter[0].EffectivePoints;
                        }
                        if (Objetivo.EquipCharacter[0].TargetAttribute == "RP")
                        {
                            Objetivo.ResistPoints = Objetivo.ResistPoints - Objetivo.EquipCharacter[0].EffectivePoints;
                        }
                        if (Objetivo.EquipCharacter[0].TargetAttribute == "ALL")
                        {
                            Objetivo.AttackPoint = Objetivo.AttackPoint - Objetivo.EquipCharacter[0].EffectivePoints;
                            Objetivo.ResistPoints = Objetivo.ResistPoints - Objetivo.EquipCharacter[0].EffectivePoints;
                        }
                        Objetivo.EquipCharacter.RemoveAt(0);
                    }                      
                }
                else if (SupportSkillTemporal.TypeEffect == "ReduceALL")
                {
                    Objetivo.AttackPoint = Objetivo.AttackPoint - SupportSkillTemporal.EffectPoints;
                    Objetivo.ResistPoints = Objetivo.ResistPoints - SupportSkillTemporal.EffectPoints;
                    
                }
                else if (SupportSkillTemporal.TypeEffect == "RestoreRP")
                {
                    Character CharacterTemporal = Atacante as Character;
                    if(CharacterTemporal.Rarity== "UltraRare")
                    {
                        Atacante.ResistPoints = 40;
                    }
                    if (CharacterTemporal.Rarity == "SuperRare")
                    {
                        Atacante.ResistPoints = 30;
                    }
                    if (CharacterTemporal.Rarity == "Rare")
                    {
                        Atacante.ResistPoints = 20;
                    }
                    if (CharacterTemporal.Rarity == "Common")
                    {
                        Atacante.ResistPoints = 10;
                    }


                }
                CartaAtaque = SupportSkillTemporal;

            }
            if (Objetivo.ResistPoints == 0)
            {
                Enemigo.Deck.Remove(Objetivo);
                int cont = 0;

                for(int i = 0; i < Enemigo.Deck.Count; i++)
                {
                    if(Enemigo.Deck[i] is Character)
                    {
                        cont++;
                    }
                }
                if(cont < 1)
                {
                    Enemigo.vivo = false;
                }


            }
            Character CharacterTempora2 = Atacante as Character;
            if (CharacterTempora2.ResistPoints <= 0)
            {
                jugador.Deck.Remove(CartaAtaque);

                int cont = 0;

                for (int i = 0; i < jugador.Deck.Count; i++)
                {
                    if (jugador.Deck[i] is Character)
                    {
                        cont++;
                    }
                }
                if (cont < 1)
                {
                    jugador.vivo = false;
                }
            }

        }
        public void UsarEquip(Equip Equiptemp,Character personaje)
        {
            personaje.EquipCharacter.Add(Equiptemp);

            
                if (Equiptemp.TargetAttribute == "AP")
                {
                personaje.AttackPoint = personaje.AttackPoint + Equiptemp.EffectivePoints;
                }
                if (Equiptemp.TargetAttribute == "RP")
                {
                personaje.ResistPoints = personaje.ResistPoints + Equiptemp.EffectivePoints;
                }
                if (Equiptemp.TargetAttribute == "ALL")
                {
                personaje.AttackPoint = personaje.AttackPoint + Equiptemp.EffectivePoints;
                personaje.ResistPoints = personaje.ResistPoints + Equiptemp.EffectivePoints;
                }
                          
            Deck.Remove(Equiptemp);

        }

    }
}
