using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLibrary
{
    public interface IPlay
    {
        void PickCard(Card card);
        void DiscardSet();
    }
}
