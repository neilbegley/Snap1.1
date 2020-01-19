namespace Snap2
{
    public interface IGameOfSnap
    {
        int[] GetPossibleNumberOfPlayers(int TotalNumberOfCards);
        void PlayGame();
        void DealPlayersTheirCards(ICardHand FreshDeck, int NumberOfPlayers);
    }
}