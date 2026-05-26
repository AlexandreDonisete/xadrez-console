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
                    if (board.GetPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.GetPiece(i, j));
                    }
                }
                Console.WriteLine();
            }
            ConsoleColor aux2 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  A B C D E F G H");
            Console.ForegroundColor = aux2;
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color.Equals(Color.White))
            {
                Console.Write(piece + " ");
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(piece + " ");
                Console.ForegroundColor = aux;
            }
        }

        public static Position ReadChessPosition()
        {
            string chessPosition = Console.ReadLine();
            char column = chessPosition[0];
            int row = int.Parse(chessPosition[1].ToString());

            return new ChessPosition(column, row).ToPosition();
        }

    }
}
