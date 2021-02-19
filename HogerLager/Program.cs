using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace HogerLager
{
    class Program
    {
        static private bool userWantsToPlay = true;
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.PrintDeck();

            /* Console.WriteLine("How many players would you like to play with? Type a number:"); //Choose player number
            int howManyPlayers = Convert.ToInt32(Console.ReadLine());
            List<Player> playersList = new List<Player>();
            for(int i = 0; i < howManyPlayers; i++)
            {
                playersList.Add(new Player());
            }
            Console.WriteLine(howManyPlayers + " players created."); //debug */
            Player mainPlayer = new Player();

            Program.PrintSlow("Welcome to Higher Lower!\n");                      // Introducing the game
            Program.PrintSlow("In a moment you are going to see two cards,\n");
            Program.PrintSlow("and you will have to guess if the second card,\n");
            Program.PrintSlow("is higher or lower than the first card!\n");
            Program.PrintSlow("Here we go.\n");

            while (userWantsToPlay)
            {
                Console.WriteLine("You now have $" + mainPlayer.Balance);
                while (mainPlayer.Balance > 0) //TODO: What to do when deck gets empty?
                {
                    // Ask the user which amount of money he wants to bet with.
                    Console.WriteLine("Which amount of money do you want to bet with? Type a number:");
                    int betInput;
                    try
                    {
                        betInput = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException) // If user inputs in the wrong format.
                    {
                        PrintError("Bet input needs to be in numbers.");
                        continue; // Restart from the bet amount question
                    }
                    catch (OverflowException)
                    {
                        PrintError("Bet input is too high to handle.");
                        continue; // Restart from the bet amount question
                    }

                    if (betInput > mainPlayer.Balance)
                    {
                        Console.WriteLine("Amount of bet is higher than your current balance. Using your full available balance of $" + mainPlayer.Balance + " instead.");
                        mainPlayer.PlayerBet = mainPlayer.Balance;
                    }
                    else
                    {
                        mainPlayer.PlayerBet = betInput;
                    }

                    // Ask if the second card is higher than the first card. If user thinks it is, he/she types "higher" or "h".
                    Console.WriteLine(deck.deck[0].Value); //DEBUG
                    Console.WriteLine(deck.deck[1].Value); //DEBUG
                    string guessInput = Console.ReadLine();
                    bool guess = (guessInput == "higher" || guessInput == "h") ? true : false; // If user inputs 'higher', the guess is that the second value is higher than first card's value. TODO: handling for lower and same etc.

                    if ((deck.deck[1].Value > deck.deck[0].Value && guess) || (deck.deck[1].Value < deck.deck[0].Value && !guess)) //TODO: WHAT IF THE VALUE IS THE SAME
                    {
                        //User has won bet.
                        //Run ChangeBalance(true); in current player instance;
                        mainPlayer.ChangeBalance(true);
                        Console.WriteLine("USER WON $" + mainPlayer.PlayerBet);
                    }
                    else
                    {
                        //User has lost the bet.
                        //Run ChangeBalance(false); in current player instance;
                        mainPlayer.ChangeBalance(false);
                        Console.WriteLine("USER LOST $" + mainPlayer.PlayerBet);
                    }

                    deck.deck.RemoveRange(0, 2); // Remove the first two cards now.
                    /* Console.WriteLine(deck.deck[0].Value);
                    Console.WriteLine(deck.deck[1].Value); */ //Debugging purpose

                    Console.WriteLine("You now have $" + mainPlayer.Balance);
                }
                if (mainPlayer.Balance <= 0)
                {
                    Console.WriteLine("The game is over, you lost all your money!");
                }

                Console.WriteLine("Do you want to play again? If so, type yes or y");
                if (Console.ReadLine() == "yes" || Console.ReadLine() == "y")
                {
                    userWantsToPlay = true;
                    deck.ResetDeck();
                    mainPlayer.Balance = 500;
                    Console.Clear();
                }
                else
                {
                    userWantsToPlay = false;
                }
            }

            Console.ReadLine();
        }
        public static void PrintSlow(string message)        // PrintSlow method
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}