﻿using System;
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
            Console.WindowHeight = 50;
            Console.WindowWidth = 75;
            
            /* Console.WriteLine("How many players would you like to play with? Type a number:"); //Choose player number
            int howManyPlayers = Convert.ToInt32(Console.ReadLine());
            List<Player> playersList = new List<Player>();
            for(int i = 0; i < howManyPlayers; i++)
            {
                playersList.Add(new Player());
            }
            Console.WriteLine(howManyPlayers + " players created."); //debug */

            Player mainPlayer = new Player();

            DrawLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Program.WriteLineSlow("Welcome to Higher Lower!\n");                      // Introducing the game
            Program.WriteLineSlow("In a moment you are going to see two cards,\n");
            Program.WriteLineSlow("and you will have to guess if the second card,\n");
            Program.WriteLineSlow("is higher or lower than the first card!\n");
            Program.WriteLineSlow("Here we go.\n");
            Console.ResetColor();

            DrawLine();

            while (userWantsToPlay)
            {
                Program.WriteLineSlow("You now have $" + mainPlayer.Balance);
                while (mainPlayer.Balance > 0) //TODO: What to do when deck gets empty?
                {
                    // Ask the user which amount of money he wants to bet with.
                    Program.WriteSlow("Input the amount of money you'd like to bet: ");
                    int betInput;
                    try
                    {
                        betInput = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException) // If user inputs in the wrong format.
                    {
                        PrintError("Bet input needs to be in numbers.\n");
                        continue; // Restart from the bet amount question
                    }
                    catch (OverflowException)
                    {
                        PrintError("Bet input is too high to handle.\n");
                        continue; // Restart from the bet amount question
                    }

                    if (betInput > mainPlayer.Balance)
                    {
                        Console.WriteLine("Amount of bet is higher than your current balance. Using your full available balance of $" + mainPlayer.Balance + " instead.");
                        mainPlayer.PlayerBet = mainPlayer.Balance;
                    }
                    if (betInput % 10 != 0)
                    {
                        PrintError("\nYou can only bet in numbers of 10\n");
                        continue;
                    }
                    else
                    {
                        mainPlayer.PlayerBet = betInput;
                    }

                    try
                    {
                        // Ask if the second card is higher than the first card. If user thinks it is, he/she types "higher" or "h".
                        Program.WriteLineSlow("\nCard number 1: " + deck.deck[0].Name);
                        Program.WriteLineSlow("Do you think the next card will be higher, or lower than the previous one?");
                        string guessInput = Console.ReadLine();
                        bool guess = (guessInput == "higher" || guessInput == "h") ? true : false; // If user inputs 'higher', the guess is that the second value is higher than first card's value. TODO: handling for lower and same etc.

                        if ((deck.deck[1].Value > deck.deck[0].Value && guess) || (deck.deck[1].Value < deck.deck[0].Value && !guess)) //TODO: WHAT IF THE VALUE IS THE SAME
                        {
                            //User has won bet.
                            //Run ChangeBalance(true); in current player instance;
                            Program.WriteLineSlow("\nCard number 2: " + deck.deck[1].Name);
                            mainPlayer.ChangeBalance(true);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Program.WriteLineSlow("\nYOU WON !");
                            Program.WriteLineSlow("$" + betInput + " added to balance");
                            Console.ResetColor();
                            DrawLine();
                        }
                        else if (deck.deck[1].Value == deck.deck[0].Value)
                        {
                            deck.deck[0].Value = deck.deck[2].Value;  // Lowering chances of getting the same value.
                        }
                        else
                        {
                            //User has lost the bet.
                            //Run ChangeBalance(false); in current player instance;
                            Console.WriteLine("Card number 2: " + deck.deck[1].Name);
                            mainPlayer.ChangeBalance(false);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nYOU LOST $" + mainPlayer.PlayerBet + "");
                            Console.ResetColor();
                            DrawLine();
                        }

                        deck.deck.RemoveRange(0, 2); // Remove the first two cards now.
                        /* Console.WriteLine(deck.deck[0].Value);
                        Console.WriteLine(deck.deck[1].Value); */ //Debugging purpose

                        Program.WriteLineSlow("You now have $" + mainPlayer.Balance);
                    }
                    catch (FormatException)
                    {
                        PrintError("Invalid input.\n");
                        continue;
                    }
                }
                if (mainPlayer.Balance <= 0)
                {
                    Program.WriteLineSlow("The game is over, you lost all your money!");
                }

                
                Program.WriteLineSlow("Do you want to play again? If so: yes/y, if not: no/n");
                string playAgain = Console.ReadLine();
                if (playAgain == "yes" || playAgain == "y")
                {
                    userWantsToPlay = true;
                    deck.ResetDeck();
                    mainPlayer.Balance = 500;
                    Console.Clear();
                }
                else if (playAgain == "no" || playAgain == "n")
                {
                    userWantsToPlay = false;
                    Console.WriteLine("\nThank you for playing!");
                    Environment.Exit(0);
                }
                else
                {
                    PrintError("Invalid input.\n");
                }
            }

            Console.ReadLine();
        }
        public static void WriteLineSlow(string message)        // WriteLineSlow method to delay the text being displayed on the screen.
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
        }

        public static void WriteSlow(string message)        // WriteSlow method to delay the text and keep it all on the same line.
        {
            Console.Write(message);
            Thread.Sleep(1000);
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void DrawLine()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i <= 75; i++)
            {
                Console.Write("_");
            }

            Console.WriteLine("\n");
            Console.ResetColor();
        }
    }
}