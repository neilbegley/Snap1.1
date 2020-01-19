using Unity;


namespace Snap2
{
    class Program
    {
        public static readonly int TotalNumberOfCards = EnumCardSuit.GetValues(typeof(EnumCardSuit)).Length * EnumCardSuit.GetValues(typeof(EnumCardValue)).Length;

        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<IUserInterface, UserInterface>();
            IUserInterface _UserInterface = container.Resolve<IUserInterface>();
            container.RegisterType<ICardHand, CardHand>();
            ICardHand Deck = container.Resolve<ICardHand>();
            container.RegisterType<IGameOfCardsUtilities, GameOfCardsUtilities>();
            IGameOfCardsUtilities _GameOfCardsUtilities = container.Resolve<IGameOfCardsUtilities>();
            //container.RegisterType<IGameOfSnap, GameOfSnap>();
            //IGameOfSnap GameOfSnap = container.Resolve<IGameOfSnap>();

            string stop = "";
            while (stop.ToLower() != "x")
            {
                _UserInterface.Clear();
                Deck.PopulateFreshDeck();
                Deck.ShuffleCardHand();

                var GameOfSnap = new GameOfSnap(_GameOfCardsUtilities, _UserInterface, TotalNumberOfCards);
                int[] PossibleNumberOfPlayers = GameOfSnap.GetPossibleNumberOfPlayers(TotalNumberOfCards);
                int NumberOfPlayers = _UserInterface.GetNumberOfPlayers(PossibleNumberOfPlayers);
                GameOfSnap.DealPlayersTheirCards(Deck, NumberOfPlayers);
                GameOfSnap.PlayGame();
                stop = _UserInterface.ReadLine("enter 'x' to exit, or press enter key to play again.");
            }
        }
    }
}

