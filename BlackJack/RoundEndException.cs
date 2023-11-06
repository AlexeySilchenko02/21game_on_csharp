using BlackJackLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class RoundEndException : Exception
    {
        public bool IsDealerWin { get; set; }
        public RoundEndException(Player player) : base("Победил " + player.Name)
        {
            IsDealerWin = player is Dealer;
        }
    }
}
