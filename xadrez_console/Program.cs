using xadrez_console.BoardLayer;
using xadrez_console.ChessLayer;
namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Screen.BuildBoard();
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
