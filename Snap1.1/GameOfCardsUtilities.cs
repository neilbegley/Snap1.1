using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Snap2
{
    public class GameOfCardsUtilities : IGameOfCardsUtilities            //I know almost by definition "...utilities" is violating SRP
    {
        public bool GameFinished(List<CardHand> PlayersHands, ICardHand stack)
        {
            int TotalNumberOfCards = EnumCardSuit.GetValues(typeof(EnumCardSuit)).Length * EnumCardSuit.GetValues(typeof(EnumCardValue)).Length; ;
            if (stack.cardHand.Count == TotalNumberOfCards)
            {
                return true;
            }
            else
            {
                foreach (var Player in PlayersHands)
                {
                    if (Player.cardHand.Count == TotalNumberOfCards)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int[] GetPossibleNumberOfPlayers(int TotalNumberOfCards)
        {
            IEnumerable<int> PossiblePlayers =
                   from a in Enumerable.Range(1, TotalNumberOfCards)
                   where TotalNumberOfCards % a == 0 && a != 1
                   select a;

            return PossiblePlayers.ToArray();
        }

        public List<CardHand> GetSetOfNewlyDealtCardHands(ICardHand ShuffledDeck, int NumberOfPlayers)
        {
            var NewPlayers = new List<CardHand>();
            for (int i = 0; i < NumberOfPlayers; i++) NewPlayers.Add(new CardHand(i));

            while (ShuffledDeck.cardHand.Count > 0)
            {
                for (int i = 0; i < NumberOfPlayers; i++)
                {
                    Card card = ShuffledDeck.cardHand[0];
                    ShuffledDeck.DealCard();
                    NewPlayers[i].AddCard(card);
                }
            }
            return NewPlayers;
        }
    }
}
