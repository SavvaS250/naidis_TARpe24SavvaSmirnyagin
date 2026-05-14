using System;
using System.Collections.Generic;
using System.Text;

namespace naidis_TARpe24SavvaSmirnyagin
{
    public class Card
    {
        public string Symbol { get; set; }
        public bool IsOpened { get; set; }
        public bool IsMatched { get; set; }

        public Card(string symbol)
        {
            Symbol = symbol;
            IsOpened = false;
            IsMatched = false;
        }
    }
}