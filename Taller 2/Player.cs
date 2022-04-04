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
    }
}
