using System.Collections.Generic;

namespace Snap2
{
    public interface IGameOfCardsUtilities
    {
        bool GameFinished(List<CardHand> PlayersHands, ICardHand stack);
        int[] GetPossibleNumberOfPlayers(int TotalNumberOfCards);
        List<CardHand> GetSetOfNewlyDealtCardHands(ICardHand FreshDeck, int NumberOfPlayers);
    }
}