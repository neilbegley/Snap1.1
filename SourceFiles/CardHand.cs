using System;
using System.Collections.Generic;
using System.Text;

namespace Snap2
{
    public class CardHand : ICardHand
    {
        public int CardHandIndex { get; set; }
        public List<Card> cardHand { get; set; }

        public CardHand()
        {
            cardHand = new List<Card>();
        }

        public CardHand(int CardIndex)
        {
            this.CardHandIndex = CardIndex;
            cardHand = new List<Card>();
        }

        public void ShuffleCardHand()
        {
            var temp = new List<Card>();
            var rnd = new Random();
            while (cardHand.Count > 0)
            {
                var CardIdx = rnd.Next(cardHand.Count);
                temp.Add(cardHand[CardIdx]);
                cardHand.RemoveAt(CardIdx);
            }
            cardHand = temp;
        }

        public void DealCard()
        {
            cardHand.RemoveAt(0);
        }

        public void AddCard(Card card)
        {
            cardHand.Add(card);
        }

        public void AddRangeOfCards(List<Card> RangeOfCards)
        {
            cardHand.AddRange(RangeOfCards);
        }

        public void EmptyHand()
        {
            cardHand.Clear();
        }

        public void PopulateFreshDeck()
        {
            var Suits = Enum.GetValues(typeof(EnumCardSuit));
            var Values = Enum.GetValues(typeof(EnumCardValue));
            foreach (var suit in Suits)
            {
                {
                    foreach (var value in Values)
                    {
                        Card card = new Card { CardSuit = suit.ToString(), CardValue = value.ToString() };
                        AddCard(card);
                    }
                }
            }
        }
    }
}
