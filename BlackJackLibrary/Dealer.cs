using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLibrary
{
    public class Dealer : Player, IBot
    {
        private Deck deck;
        public Dealer() : base("Pepe The Dealer", 5000)
        {
            deck = new Deck();
        }
        public Card GiveCard()
        {
            return deck.GetRandomCard();
        }
        public void ShuffleCards()
        {
            deck = new Deck();
        }
        public void MakeAutoMove(int point)
        {
            if (Score < 21 && Score < point)
            {
                PickCard(GiveCard());
            }
        }
    }
}
