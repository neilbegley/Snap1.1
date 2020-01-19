using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snap2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap2.Tests
{
    [TestClass()]
    public class UserInterfaceTests
    {
        [TestMethod()]
        public void GetNumberOfPlayersTest()
        {
            int[] Exp = new int[] { 2, 4, 13, 26, 52 };
            var testUtils = new GameOfCardsUtilities();
            var Act = testUtils.GetPossibleNumberOfPlayers(52);
            CollectionAssert.AreEquivalent(Act,Exp);
        }
    }
}