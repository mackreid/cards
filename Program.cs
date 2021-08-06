using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    class Program
    {
        static void Main(string[] args) {
            Deck d = new Deck();
            d.Shuffle();
            
            Player player = new Player();
            player.Hand = d.DealCards(2);
            PrintCardValues(player.Hand);
            Console.WriteLine(player.PlayerHandIntValue());


        }

        static void PrintCardValues(List<Card> cards) {
            cards.ForEach(c => Console.WriteLine(c.GetCardStringValue()));
        }
    }
}
