using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;


namespace Snap2.Tests
{
    [TestClass()]
    public class GameOfCardsUtilitiesTests
    {
        ICardHand shuffledDeck = Substitute.For<ICardHand>();

        bool areEquivalent(List<CardHand> exp, List<CardHand> act)
        {
            try
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    for (int j = 0; j < exp[i].cardHand.Count; j++)
                    {
                        if (exp[i].cardHand[j].CardSuit != act[i].cardHand[j].CardSuit
                            || (exp[i].cardHand[j].CardValue != act[i].cardHand[j].CardValue)) return false;
                    }
                }
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        [TestMethod()]
        public void GetSetOfNewlyDealtCardHandsTest()
        {
            shuffledDeck.When(x => x.DealCard())
               .Do(x => shuffledDeck.cardHand.RemoveAt(0));

            shuffledDeck.When(x => x.AddCard(new Card { CardSuit = "Clubs", CardValue = "Ace" }))
                .Do(x => shuffledDeck.cardHand.Add(new Card { CardSuit = "Clubs", CardValue = "Ace" }));

            shuffledDeck.When(x => x.AddCard(new Card { CardSuit = "Clubs", CardValue = "Two" }))
                .Do(x => shuffledDeck.cardHand.Add(new Card { CardSuit = "Clubs", CardValue = "Two" }));

            shuffledDeck.When(x => x.AddCard(new Card { CardSuit = "Clubs", CardValue = "Three" }))
                .Do(x => shuffledDeck.cardHand.Add(new Card { CardSuit = "Clubs", CardValue = "Three" }));

            shuffledDeck.When(x => x.AddCard(new Card { CardSuit = "Clubs", CardValue = "Four" }))
                .Do(x => shuffledDeck.cardHand.Add(new Card { CardSuit = "Clubs", CardValue = "Four" }));

            shuffledDeck.When(x => x.AddCard(new Card { CardSuit = "Clubs", CardValue = "Five" }))
                .Do(x => shuffledDeck.cardHand.Add(new Card { CardSuit = "Clubs", CardValue = "Five" }));

            shuffledDeck.When(x => x.AddCard(new Card { CardSuit = "Clubs", CardValue = "Four" }))
                .Do(x => shuffledDeck.cardHand.Add(new Card { CardSuit = "Clubs", CardValue = "Four" }));

            var ListOfCards = new List<Card>();
            ListOfCards.Add(new Card { CardSuit = "Clubs", CardValue = "Ace" });
            ListOfCards.Add(new Card { CardSuit = "Clubs", CardValue = "Two" });
            ListOfCards.Add(new Card { CardSuit = "Clubs", CardValue = "Three" });
            ListOfCards.Add(new Card { CardSuit = "Clubs", CardValue = "Four" });
            ListOfCards.Add(new Card { CardSuit = "Clubs", CardValue = "Five" });
            ListOfCards.Add(new Card { CardSuit = "Clubs", CardValue = "Six" });
            shuffledDeck.cardHand = ListOfCards;

            int NumberOfPlayers = 2;
            var Exp = new List<CardHand>();
            Exp.Add(new CardHand());
            Exp.Add(new CardHand());
            Exp[0].cardHand.Add(new Card { CardSuit = "Clubs", CardValue = "Ace" });
            Exp[0].cardHand.Add(new Card { CardSuit = "Clubs", CardValue = "Three" });
            Exp[0].cardHand.Add(new Card { CardSuit = "Clubs", CardValue = "Five" });
            Exp[1].cardHand.Add(new Card { CardSuit = "Clubs", CardValue = "Two" });
            Exp[1].cardHand.Add(new Card { CardSuit = "Clubs", CardValue = "Four" });
            Exp[1].cardHand.Add(new Card { CardSuit = "Clubs", CardValue = "Six" });

            var testUtilities = new GameOfCardsUtilities();
            var Act = testUtilities.GetSetOfNewlyDealtCardHands(shuffledDeck, NumberOfPlayers);

            //CollectionAssert.AreEquivalent(Exp,Act);            //doesnt work

            Assert.IsTrue(areEquivalent(Exp, Act));
        }
    }
}
