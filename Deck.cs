using System;
using System.Collections.Generic;
using System.Linq;

public class Deck {

    public List<Card> Cards { get; set; }
    public List<Card> DeltCards { get; set; }

    public Deck() {
        Create();
    }

    public void Create() {
        CardValue[] valueArray = Enum.GetValues(typeof(CardValue)) as CardValue[];
        Cards = Enumerable.Range(0, 4)
                    .SelectMany(s => Enumerable.Range(0, 13)
                    .Select(c => new Card((Suit)s, (CardValue)c)))
                    .ToList();
        DeltCards = new List<Card>();
    }

    public void Shuffle() {
        Cards = Cards.OrderBy(c => Guid.NewGuid())
                    .ToList();
    }

    public void ShuffleFisherYates() {
        Random r = new Random();
        int n = Cards.Count;
        for(int i = n - 1; i > 0; i--) {
            int j = r.Next(0, i+1);
            Card temp = Cards[i];
            Cards[i] = Cards[j];
            Cards[j] = temp;
        }
    }

    public void Sort() {
        Cards = Cards.OrderBy(s => s.Suit)
                    .ThenBy(c => c.Value)
                    .ToList();
    }

    public List<Card> DealCards(int numberOfCards) {
        var cards = Cards.Take(numberOfCards);
        var deltCards = cards as List<Card> ?? cards.ToList();
        Cards.RemoveAll(deltCards.Contains);
        DeltCards.AddRange(deltCards);
        return deltCards;
    }

}