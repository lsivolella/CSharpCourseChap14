using Exercise05.Enums;
using System;
using System.Collections.Generic;

namespace Exercise05.Entities
{
    public class Card : IComparable<Card>
    {
        public string Name { get; set; }
        public Suit CardSuit { get; set; }
        public int Rank { get; set; }

        public Card(string name, Suit suit, int rank)
        {
            Name = name;
            CardSuit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            return Name + " " + CardSuit;
        }

        /*
         * On the method bellow, when equal suits are compared, the method will call for another function
         * whose purpose is to sort the elements by their ranks, thus providing a full sorting of ones playing hand
         */
        public int CompareTo(Card other)
        {
            if (this.CardSuit > other.CardSuit)
                return 1;
            else if (this.CardSuit < other.CardSuit)
                return -1;
            else
            {
                return CompareRanks(other);
            }
                
        }

        private int CompareRanks(Card other)
        {
            if (this.Rank > other.Rank)
                return 1;
            else if (this.Rank < other.Rank)
                return -1;
            else
                return 0;
        }

    }

    public class CompareBySuitAndRank : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            //int xSuit = Convert.ToInt32(x.CardSuit);
            //int ySuit = Convert.ToInt32(y.CardSuit);

            //if (xSuit > ySuit)
            //    return 1;
            //else if (xSuit < ySuit)
            //    return -1;
            //else
            //    return 0;

            return x.Name.CompareTo(y.Name);
        }
    }
}
