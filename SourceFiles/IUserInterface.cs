namespace Snap2
{
    public interface IUserInterface
    {
        void Clear();
        int GetNumberOfPlayers(int[] PossibleNumberOfPlayers);
        string ReadLine(string message);
        void WriteLine(string message);
    }
}