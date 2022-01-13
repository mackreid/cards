public class Card {
    public Suit Suit { get; private set; }
    public CardValue Value { get; private set; }

    public int IntValue {
        get {
            return CardIntValue.CardIntDict[Value];
        }
    }

    public Card(Suit suit, CardValue value) {
        Suit = suit;
        Value = value;
    }

    public override string ToString() {
        return $"{Value}({IntValue}) {Suit}";
    }
}