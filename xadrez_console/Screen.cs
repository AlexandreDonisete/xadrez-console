using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;
using xadrez_console.BoardLayer;
using xadrez_console.ChessLayer;

namespace xadrez_console
{
    internal class Screen
    {

        public static void PrintMatch(ChessMatch chessMatch)
        {
            Screen.PrintBoard(chessMatch.Board);
            Console.WriteLine();
            PrintCapturedPices(chessMatch);
            Console.WriteLine();
            Console.WriteLine("Turno: " + chessMatch.Turn);
            Console.WriteLine("Aguardando jogada: " + chessMatch.CurrentPlayer);

            if(chessMatch.Check)
            {
                Console.WriteLine("XEQUE!");
            }
        }

        public static void PrintCapturedPices(ChessMatch chessMatch)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.WriteLine("Brancas: ");
            PrintCapturedPicesByColor(chessMatch.CapturedPiecesByColor(Color.White));

            Console.WriteLine("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            PrintCapturedPicesByColor(chessMatch.CapturedPiecesByColor(Color.Red));
            Console.ForegroundColor = aux;
        }

        public static void PrintCapturedPicesByColor(HashSet<Piece> capturedPiecesByColor)
        {
            Console.Write("[");
            foreach (Piece piece in capturedPiecesByColor)
            {
                Console.Write(piece + " ");
            }
            Console.WriteLine("]");
        }

        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = aux;
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.GetPiece(i, j));
                }
                Console.WriteLine();
            }
            ConsoleColor aux2 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  A B C D E F G H");
            Console.ForegroundColor = aux2;
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = aux;
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = alteredBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.GetPiece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            ConsoleColor aux2 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  A B C D E F G H");
            Console.ForegroundColor = aux2;
            Console.BackgroundColor = originalBackground;
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color.Equals(Color.White))
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static ChessPosition ReadChessPosition()
        {
            string chessPosition = Console.ReadLine();
            char column = chessPosition[0];
            int row = int.Parse(chessPosition[1].ToString());

            return new ChessPosition(column, row);
        }

    }
}
