using System;
using System.Collections.Generic;
using System.Text;

namespace HogerLager
{
    public class Player
    {
        public int Balance { get; set; }     // Balance property. Value is (currently) in USD.
        public int PlayerBet { get; set; }      // PlayerBet property.

        public Player()
        {
            Balance = 500;
        }

        /* Method ChangeBalance
         * 
         * Parameter hasWon: If true, the player's last best will be doubled and added back to the balance.
         */
        public void ChangeBalance(bool hasWon)
        {
            if (hasWon)
            {
                this.Balance += PlayerBet;
            }
            else
            {
                this.Balance -= PlayerBet;
            }
        }
    }
}