using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    class Program
    {
        static void Main(string[] args) {

            bool inGame = true;

            while(inGame) {

                Console.WriteLine("\nWelcome to Console Blackjack!");
                Console.WriteLine("Please enter how many players are going to play -");

                string input = Console.ReadLine();
                int numberInput;
                while(!Int32.TryParse(input, out numberInput)) {
                    Console.WriteLine("Please enter a number for the amount of players playing - ");
                    input = Console.ReadLine();
                }

                Console.WriteLine($"\nStarting a game with {numberInput} players\n");

                Blackjack game = new Blackjack(numberInput);
                game.GameLoop();     

                Console.WriteLine("Do you want to play again. Select Yes (Y) or No (N)");
                input = Console.ReadLine().ToLower();

                while(input != "y" && input != "n") {
                    Console.WriteLine("Invalid input. Do you want to play again. Select Yes (Y) or No (N)");
                    input = Console.ReadLine().ToLower();
                }

                if(input.Equals("n")) {
                    inGame = false;
                }

            }

            Console.WriteLine("Thanks for playing!");
            Environment.Exit(0);
        }

        static void PrintCardValues(List<Card> cards) {
            cards.ForEach(c => Console.WriteLine(c.GetCardStringValue()));
        }
    }
}
