using System;
using System.Collections.Generic;
using System.Text;

namespace HogerLager
{
    class Deck
    {
        public List<Card> deck = new List<Card>();      // List of cards.

        public Deck()       // Generating deck of cards upon creation of deck object.
        {
            ResetDeck();
        }

        public void ResetDeck()
        {
            deck.Clear(); // Make sure deck is empty first, then regenerate and add all cards, then shuffle.

            for (int i = 0; i < 52; i++)
            {
                Card.suite suite = (Card.suite)(Math.Floor((decimal)i / 13));

                int val = i % 13 + 2;
                deck.Add(new Card(val, suite));
            }

            ShuffleDeck();
        }


        public void ShuffleDeck()
        {
            var rnd = new Random();    // Shuffling deck 1000 times.
            Card temp;

            for (int shuffleAmount = 0; shuffleAmount < 1000; shuffleAmount++)
            {
                for (int i = 0; i < 52; i++)
                {
                    int j = rnd.Next(13);
                    temp = deck[i];
                    deck[i] = deck[j];
                    deck[j] = temp;
                }
            }
        }

        public void PrintDeck()     // Method to display the deck.
        {
            foreach (Card card in this.deck)
            {
                Console.WriteLine(card.Name);
            }
        }

    }
}