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
                //Board board = new Board(8, 8);

                //board.PlacePiece(new King(Color.White, board), new Position(0, 0));
                //board.PlacePiece(new Rook(Color.White, board), new Position(1, 3));
                //board.PlacePiece(new King(Color.White, board), new Position(2, 4));

                //Screen.PrintBoard(board);
                ChessPosition position = new ChessPosition('a', 1);
                Console.WriteLine(position.ToPosition());
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
