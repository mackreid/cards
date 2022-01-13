using System;
using System.Collections.Generic;
using System.Linq;

public class Player {
    public List<Card> Hand { get; set; }
    public Card GetLatestCard() => Hand[Hand.Count - 1];

    public int PlayerHandIntValue() {
        int total = 0;
        Hand.ForEach(c => total += CardIntValue.CardIntDict[c.Value]);
        return total;
    }

    public override string ToString() {
        return String.Join(" ", Hand.Select(c => c.Value));
    }

}