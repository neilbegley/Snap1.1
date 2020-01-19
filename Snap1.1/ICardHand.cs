using System.Collections.Generic;

namespace Snap2
{
    public interface ICardHand
    {
        List<Card> cardHand { get; set; }
        int CardHandIndex { get; set; }

        void AddCard(Card card);
        void AddRangeOfCards(List<Card> RangeOfCards);
        void DealCard();
        void EmptyHand();
        void PopulateFreshDeck();
        void ShuffleCardHand();
    }
}