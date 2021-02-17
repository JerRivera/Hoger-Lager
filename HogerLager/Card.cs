using System;
using System.Collections.Generic;
using System.Text;

namespace HogerLager
{
    class Card
    {
        public enum suite       // Creating group of constants.
        {
            Hearts = 0,
            Spades,
            Clubs,
            Diamonds
        }

        public int Value { get; set; }      // Value property.
        public suite Suite { get; set; }      // Suite property.

        public Card(int value, suite suite)
        {
            this.Value = value;
            this.Suite = suite;
        }

        public string ValueWithName         // Switch statement to determine the value of the card.
        {
            get
            {
                string name = string.Empty;
                switch (Value)
                {
                    case (14):
                        name = "Ace";
                        break;
                    case (13):
                        name = "King";
                        break;
                    case (12):
                        name = "Queen";
                        break;
                    case (11):
                        name = "Jack";
                        break;
                    default:
                        name = Value.ToString();
                        break;

                }

                return name;
            }
        }
        public string Name { get { return ValueWithName + " of " + Suite.ToString() + "\n"; } }   // Name property.

    }
}
