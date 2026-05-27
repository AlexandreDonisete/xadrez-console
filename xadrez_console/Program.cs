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
                ChessMatch chessMatch = new ChessMatch();
                while (!chessMatch.CheckMate)
                {
                    Console.Clear();
                    Screen.PrintBoard(chessMatch.Board);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position source = Screen.ReadChessPosition().ToPosition();

                    bool[,] possiblesPositions = chessMatch.Board.GetPiece(source).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(chessMatch.Board, possiblesPositions);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Position target = Screen.ReadChessPosition().ToPosition();

                    chessMatch.PerformChessMove(source, target);
                }
                Screen.PrintBoard(chessMatch.Board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
