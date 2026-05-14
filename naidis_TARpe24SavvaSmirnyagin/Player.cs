using System;
using System.Collections.Generic;
using System.Text;

namespace naidis_TARpe24SavvaSmirnyagin
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        public void AddPoint()
        {
            Score++;
        }
    }
}
