using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Taller_2
{
    public class Tests
    {
        Player jugador;
        Player Enemigo;
        List<Card> LJugador = new List<Card>();
        List<Card> LEnemigo = new List<Card>();

        public void InicializarJugadores()
        {
            
            jugador = new Player(LJugador,20,true);
            Enemigo = new Player(LEnemigo, 20, true);
            jugador.AñadirCartas();
            Enemigo.AñadirCartas();
        }
        public void InicializarJugadoresPerdedores()
        {

            jugador = new Player(LJugador, 20, true);
            Enemigo = new Player(LEnemigo, 20, true);
            jugador.AñadirCartas();
            Enemigo.AñadirCartaTipo2();
        }
        [TearDown]
        public void ClearAllStructures()
        {
            jugador.Deck.Clear();
            Enemigo.Deck.Clear();
            LJugador.Clear();
            LEnemigo.Clear();    
        }

        [Test]
        public void CrearJugador()
        {
            InicializarJugadores();
            Assert.IsTrue(jugador.Deck.Count>0);//su baraja ya no esta vacia 
            Assert.IsTrue(jugador.BarajaCp==0);//al recibir 20 cartas se queda sin cp pues empieza con 20

        }
        [Test]
        public void Atacar()
        {
            //Characters
            InicializarJugadores();
            Card Character3 = Enemigo.Deck[3];
            jugador.Atacar(jugador.Deck[0], (Character)Enemigo.Deck[3],(Character)jugador.Deck[0],jugador,Enemigo);
            Assert.IsFalse(Enemigo.Deck.Contains(Character3));//EL enemigo pierde la carta Character al quedarse sin puntos de resistencia

            Card Character2 = Enemigo.Deck[2];
            jugador.Atacar(jugador.Deck[0], (Character)Enemigo.Deck[2], (Character)jugador.Deck[0], jugador, Enemigo);
            Assert.IsTrue(Enemigo.Deck.Contains(Character2));//el character no se a quedado sin PR por lo que aun se mantiene en la baraja 
            Character Personaje2 = Enemigo.Deck[2] as Character;
            Assert.IsTrue(Personaje2.ResistPoints ==10);//el Character pierde 10 RP y queda con 10 RP de 20

            jugador.Atacar(jugador.Deck[3], (Character)Enemigo.Deck[1], (Character)jugador.Deck[3], jugador, Enemigo);
            Character Atacante = jugador.Deck[3] as Character;
            Character Defensor = Enemigo.Deck[1] as Character;
            Assert.IsTrue(Atacante.AttackPoint==6);//al empatar el atacante aumenta a 6 de AP al ser Knight y el defensor pierde un AP por ser Mage 
            Assert.IsTrue(Defensor.AttackPoint == 4);
            Assert.IsTrue(Defensor.ResistPoints == 24); // el perdedor pierde 6 PA de 30

            //SuportSkills

            //recuperar vida con recover RP                              a este le subiran la vida
            Enemigo.Atacar(Enemigo.Deck[18], (Character)jugador.Deck[1], (Character)Enemigo.Deck[1], Enemigo, jugador);
            Character Recuperado = Enemigo.Deck[1] as Character;
            Assert.IsTrue(Recuperado.ResistPoints == 30);//recupera su salud inicial segun su Rareza

            //suportSkills como ataque all
            jugador.Atacar(jugador.Deck[16], (Character)Enemigo.Deck[1], (Character)jugador.Deck[3], jugador, Enemigo);
            Character afectado = Enemigo.Deck[1] as Character;
            Assert.IsTrue(Recuperado.ResistPoints == 27);//pierde 3 AP y 3 RP
            Assert.IsTrue(Recuperado.AttackPoint == 1);
        }
        [Test]
        public void Perder()
        {
            InicializarJugadoresPerdedores();
            jugador.Atacar(jugador.Deck[1], (Character)Enemigo.Deck[0], (Character)jugador.Deck[1], jugador, Enemigo);

            Assert.IsTrue(Enemigo.Vivo==false);//El Enemigo solo tiene un Character y al morir, el enemigo pierde 

        }
        [Test]
        public void Equips()
        {
            InicializarJugadoresPerdedores();
            Enemigo.UsarEquip((Equip)Enemigo.Deck[1], (Character)Enemigo.Deck[0]);
            Character afectado = Enemigo.Deck[0] as Character;
            Assert.IsTrue(afectado.ResistPoints==4);
        

        }
        [Test]
        public void DestuirEquip()
        {
            InicializarJugadoresPerdedores();
            Enemigo.UsarEquip((Equip)Enemigo.Deck[1], (Character)Enemigo.Deck[0]);

            jugador.Atacar(jugador.Deck[17], (Character)Enemigo.Deck[0], (Character)jugador.Deck[1], jugador, Enemigo);


            Character afectado = Enemigo.Deck[0] as Character;
            Assert.IsTrue(afectado.ResistPoints == 1);//pierde su bonificacion


        }
        




    }
}