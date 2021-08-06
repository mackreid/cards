using System;
using System.Collections.Generic;

public class Player {
    public List<Card> Hand { get; set; }

    public int PlayerHandIntValue() {
        int total = 0;
        Hand.ForEach(c => total += CardIntValue.CardIntDict[c.Value]);
        return total;
    }

}