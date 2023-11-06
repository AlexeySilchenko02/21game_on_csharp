using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLibrary
{
    public abstract class Player : IPlay, INotifyPropertyChanged
    {
        public string Name { get; set; }
        public ObservableCollection<Card> CardSet { get; set; }
        private int money;
        private int bet;
        private int score;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Money
        {
            get { return money; }
            set
            {
                money = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Money"));
            }
        }
        public int Bet
        {
            get { return bet; }
            set
            {
                bet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bet"));
            }
        }
        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Score"));
            }
        }
        protected Player(string name, int money)
        {
            Name = name;
            Money = money;
            CardSet = new ObservableCollection<Card>();
        }
        public void PickCard(Card card)
        {

            if (score + card.Points > 21)
            {
                if (card.Label == "A")
                    score -= 10;
                else
                {
                    int realScore = 0;
                    foreach (Card p in CardSet)
                    {
                        realScore += p.Points;
                        if (p.Label == "A")
                        {

                            realScore -= 10;
                        }
                    }
                    if (realScore != score)
                    {
                        score = realScore;
                    }
                }

            }
            CardSet.Add(card);
            score += card.Points;
        }
        public void DiscardSet()
        {
            CardSet.Clear();
            score = 0;
        }
    }
}
