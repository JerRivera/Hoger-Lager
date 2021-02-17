using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace HogerLager
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            

            Console.WriteLine("How many players would you like to play with? Type a number:"); //  Choose player number

            int howManyPlayers = Convert.ToInt32(Console.ReadLine());
            List<Player> playersList = new List<Player>();

            for(int i = 0; i < howManyPlayers; i++)
            {
                playersList.Add(new Player());
            }

            Console.WriteLine(howManyPlayers + " players created."); //debug
            
            /*Program.PrintSlow("Welcome to Higher Lower!\n");                      // Introducing the game
            Program.PrintSlow("In a moment you are going to see two cards,\n");
            Program.PrintSlow("and you will have to guess if the second card,\n");
            Program.PrintSlow("is higher or lower than the first card!\n");
            Program.PrintSlow("Here we go.\n");*/



            Console.ReadLine();
        }
        public static void PrintSlow(string message)        // PrintSlow method
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
        }
    }
}
