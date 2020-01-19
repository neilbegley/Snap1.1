using System;
using System.Linq;
using System.Text;

namespace Snap2
{
    /// <summary>
    /// decouples UI from rest of code
    /// </summary>
    public class UserInterface : IUserInterface
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public int GetNumberOfPlayers(int[] PossibleNumberOfPlayers)
        {
            var strPossiblePlayerNumber = new StringBuilder("Please enter number of players must be one of ");
            for (int i = 0; i < PossibleNumberOfPlayers.Length - 1; i++)
            {
                strPossiblePlayerNumber.Append(PossibleNumberOfPlayers[i]);
                strPossiblePlayerNumber.Append(", ");
            }
            strPossiblePlayerNumber.Append("or ");
            strPossiblePlayerNumber.Append(PossibleNumberOfPlayers[PossibleNumberOfPlayers.Length - 1]);
            strPossiblePlayerNumber.Append(", or Enter 'x' to exit.");

            int NumberOfPlayers = 0;
            while (!PossibleNumberOfPlayers.Contains(NumberOfPlayers))
            {
                string Entry = ReadLine(strPossiblePlayerNumber.ToString());
                if (Entry.ToLower() == "x")
                {
                    System.Environment.Exit(1);
                }
                else
                {
                    NumberOfPlayers = Convert.ToInt16(Entry ?? "0");
                }
            }
            return NumberOfPlayers;
        }
    }
}
