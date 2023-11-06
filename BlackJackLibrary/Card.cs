using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BlackJackLibrary
{
    public class Card
    {
        public string Label { get; set; }
        public string Sign { get; set; }
        public int Points { get; set; }
        public CardSuit Suit { get; set; }
        public Brush Brush { get; set; }

        public Card(CardSuit suit, (string, int) cardTypes)
        {
            Label = cardTypes.Item1;
            Points = cardTypes.Item2;
            Suit = suit;
            switch (suit)
            {
                case CardSuit.Diamonds:
                    Sign = "♦";
                    Brush = new SolidColorBrush(Colors.Red);
                    break;
                case CardSuit.Hearts:
                    Sign = "♥";
                    Brush = new SolidColorBrush(Colors.Red);
                    break;
                case CardSuit.Spades:
                    Sign = "♠";
                    Brush = new SolidColorBrush(Colors.Black);
                    break;
                case CardSuit.Clubs:
                    Sign = "♣";
                    Brush = new SolidColorBrush(Colors.Black);
                    break;
            }
        }
    }
}
