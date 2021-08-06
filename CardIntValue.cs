using System;
using System.Collections.Generic;

public static class CardIntValue {

    public static Dictionary<CardValue, int> CardIntDict = new Dictionary<CardValue, int>() {
        [CardValue.Two] = 2,
        [CardValue.Three] = 3,
        [CardValue.Four] = 4,
        [CardValue.Five] = 5,
        [CardValue.Six] = 6,
        [CardValue.Seven] = 7,
        [CardValue.Eight] = 8,
        [CardValue.Nine] = 9,
        [CardValue.Ten] = 10,
        [CardValue.Jack] = 10,
        [CardValue.Queen] = 10,
        [CardValue.King] = 10,
        [CardValue.Ace] = 11
    };
}