using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLibrary
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, int money) : base(name, money)
        {

        }
        public void MakeBet(int bet)
        {
            if (Money > bet)
            {
                Money -= bet;
                Bet = bet;
            }
            else
            {
                Bet = Money;
                Money = 0;
            }
        }
    }
}
