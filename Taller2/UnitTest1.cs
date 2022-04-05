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

        public void CrearJugadores()
        {
            
            jugador = new Player(LJugador,20,true);
            jugador = new Player(LEnemigo, 20, true);
            jugador.AñadirCartas();
            Enemigo.AñadirCartas();
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
            CrearJugador();
            Assert.IsTrue(jugador.Deck.Count>0);//su baraja ya no esta vacia 
            Assert.IsTrue(jugador.BarajaCp==0);//al recibir 20 cartas se queda sin cp pues empieza con 20

        }
    }
}