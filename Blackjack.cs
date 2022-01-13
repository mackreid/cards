using System;
using System.Collections.Generic;
using System.Linq;

public class Blackjack {

    private Player[] players;
    private Player dealer;
    private Deck deck;

    public Blackjack(int noPlayers) {
        players = Enumerable.Range(0, noPlayers).Select(p => new Player()).ToArray();
        dealer = new Player();
        deck = new Deck();
        deck.Shuffle();
    }

    public void Deal() {
        foreach(Player p in players) {
            p.Hand = deck.DealCards(2);
        }
        dealer.Hand = deck.DealCards(2);
    }

    public void GameLoop() {

        Deal();
        Console.WriteLine($"Dealer has X {dealer.Hand[1].Value}\n");

        for(int i = 0; i < players.Length; i++) {

            bool inTurn = true;
            while(inTurn) {

                Console.WriteLine($"Player {i+1} has {players[i].ToString()}");
                Console.WriteLine($"Player {i+1} total: {players[i].PlayerHandIntValue()}\n");

                if(players[i].PlayerHandIntValue() == 21) {
                    if(players[i].Hand.Count == 2) {
                        Console.WriteLine($"Player {i+1} has Blackjack!\n");
                    } else {
                        Console.WriteLine($"Player {i+1} has a score of 21!\n");
                    }
                    inTurn = false;
                }

                Console.WriteLine("Do you want to hit (H/s) or stick (S/s)");
                string x = Console.ReadLine().ToLower();

                Console.WriteLine(x);

                while(x != "h" && x != "s") {
                    Console.WriteLine("Incorrect input. Do you want to hit (H/s) or stick (S/s)");
                    x = Console.ReadLine().ToLower();
                }
                
                if(x.Equals("s")) {
                    Console.WriteLine($"\nPlayer {i+1} stuck on {players[i].PlayerHandIntValue()}\n");
                    inTurn = false;
                } else if(x.Equals("h")) {
                    
                    players[i].Hand.AddRange(deck.DealCards(1));

                    Console.WriteLine($"Player {i+1} was dealt a {players[i].GetLatestCard().Value}\n");

                    if(players[i].PlayerHandIntValue() > 21) {
                        Console.WriteLine($"Player {i+1} bust with a score of {players[i].PlayerHandIntValue()}\n");
                        inTurn = false;
                    }

                }

            }   

        }

        Console.WriteLine("The dealer reveals his second card");
        Console.WriteLine($"The dealer has {dealer.ToString()}");
        Console.WriteLine($"The dealers total is {dealer.PlayerHandIntValue()}\n");

        while(dealer.PlayerHandIntValue() < 17) {
            dealer.Hand.AddRange(deck.DealCards(1));
            Console.WriteLine($"The dealer was dealt a {dealer.GetLatestCard().Value}");
            Console.WriteLine($"The dealer has {dealer.ToString()}");
            Console.WriteLine($"The dealers total is {dealer.PlayerHandIntValue()}\n");
        }

        if(dealer.PlayerHandIntValue() > 21) {
            Console.WriteLine("All Players win! Congrats!\n");
        } else {
            for(int i = 0; i < players.Length; i++) {
                if(players[i].PlayerHandIntValue() > 21) {
                    Console.WriteLine($"Player {i+1} bust. Dealer wins!\n");
                } else if(players[i].PlayerHandIntValue() > dealer.PlayerHandIntValue()) {
                    Console.WriteLine($"Player {i+1} has a better score than the dealer. Player wins!\n");
                } else {
                    Console.WriteLine($"Player {i+1} has a worse score than the dealer. Dealer wins!\n");
                }
            }
        }


    }

}