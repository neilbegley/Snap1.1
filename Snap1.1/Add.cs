using System;
using System.Collections.Generic;
using System.Text;

namespace Snap2
{
    public class Card : ICard
    {
        public string CardSuit { get; set; }
        public string CardValue { get; set; }
    }
}
