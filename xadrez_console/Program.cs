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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(chessMatch);
                        
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position source = Screen.ReadChessPosition().ToPosition();
                        chessMatch.ValidateSourcePosition(source);

                        bool[,] possiblesPositions = chessMatch.Board.GetPiece(source).PossibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(chessMatch.Board, possiblesPositions);

                        Console.WriteLine();

                        Console.Write("Destino: ");
                        Position target = Screen.ReadChessPosition().ToPosition();
                        chessMatch.ValidadeTargetPosition(source, target);

                        chessMatch.MakePlay(source, target);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintMatch(chessMatch);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
