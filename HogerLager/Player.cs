using System;
using System.Collections.Generic;
using System.Text;

namespace HogerLager
{
    class Player
    {
        public int Balance { get; set; }       // Balance property.
        public int PlayerBet { get; set; }      // PlayerBet property.
        private bool HasWon = false;

        public Player()
        {
            Balance = 500;
        }

        public void AdjustBalance()
        {
            if (HasWon)
                Balance += PlayerBet;
            else
                Balance -= PlayerBet;
        }
    }
}