using naidis_TARpe24SavvaSmirnyagin;
using System;
using System.Collections.Generic;
using System.Text;

namespace naidis_TARpe24SavvaSmirnyagin
{
    public class Game
    {
        public List<Card> Cards { get; set; }

        public Game()
        {
            List<string> symbols =
            [
                "🍎","🍎",
                "🔥","🔥",
                "🎮","🎮",
                "⚽","⚽",
                "🐱","🐱",
                "🚗","🚗",
                "🌙","🌙",
                "🎵","🎵"
            ];

            Random rnd = new();
            Cards = symbols.OrderBy(x => rnd.Next())
                           .Select(x => new Card(x))
                           .ToList();
        }
    }
}