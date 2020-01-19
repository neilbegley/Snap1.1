using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snap2
{
    public class GameOfSnap : IGameOfSnap
    {
        private IGameOfCardsUtilities _Utilities;
        private IUserInterface _UserInterface;
        private List<CardHand> Players;
        private CardHand Stack;
        private int TotalNumberOfCards;

        public GameOfSnap(IGameOfCardsUtilities gameOfCardsUtilities, IUserInterface userInterface, int TotalNumberOfCards)
        {
            _Utilities = gameOfCardsUtilities;
            _UserInterface = userInterface;
            this.TotalNumberOfCards = TotalNumberOfCards;
        }

        public void DealPlayersTheirCards(ICardHand ShuffledDeck, int NumberOfPlayers)
        {
            Players = _Utilities.GetSetOfNewlyDealtCardHands(ShuffledDeck, NumberOfPlayers);
            this.Stack = new CardHand();
        }

        public int[] GetPossibleNumberOfPlayers(int TotalNumberOfCards) { return _Utilities.GetPossibleNumberOfPlayers(TotalNumberOfCards); }

        public void PlayGame()
        {
            Stack = new CardHand();
            bool GameFinished = false;

            while (!GameFinished)
            {
                foreach (var player in Players)
                {
                    if (player.cardHand.Count > 0)
                    {
                        var Playedcard = player.cardHand[0];
                        Thread.Sleep(100);
                        _UserInterface.WriteLine($" Player {player.CardHandIndex + 1} played {Playedcard.CardValue} of {Playedcard.CardSuit}");
                        var StackCardShowing = Stack.cardHand.Count > 0 ? Stack.cardHand[Stack.cardHand.Count - 1] : null;
                        player.DealCard();
                        Stack.AddCard(Playedcard);
                        if (StackCardShowing != null && Playedcard.CardValue == StackCardShowing.CardValue) ProcessSnapping();
                        GameFinished = TestIfGameFinished();
                    }
                }
            }
        }

        private void ProcessSnapping()
        {
            {
                var r = new Random();
                var Snapper = r.Next(0, Players.Count());
                Players[Snapper].cardHand.AddRange(Stack.cardHand);
                Stack.EmptyHand();
                _UserInterface.WriteLine($"    SNAPPED! by Player {Snapper + 1} who now has {Players[Snapper].cardHand.Count()} cards.");
            }
        }

        private bool TestIfGameFinished()
        {
            if (Stack.cardHand.Count == TotalNumberOfCards)
            {
                _UserInterface.WriteLine("    GAME IS DEADLOCKED :-(");
                return true;
            }
            else
            {
                foreach (var Player in Players)
                {
                    if (Player.cardHand.Count == TotalNumberOfCards)
                    {
                        _UserInterface.WriteLine($"    PLAYER {Player.CardHandIndex + 1} HAS WON :-)");
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
