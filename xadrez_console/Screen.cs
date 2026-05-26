using System;
using System.Collections.Generic;
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
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.GetPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.GetPiece(i, j));
                        //Console.Write($"{board.GetPiece(i, j)} ");
                    }
                }
                Console.WriteLine();
            }
            Console.Write("  A B C D E F G H");
        }

        static void PrintPiece(Piece piece)
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

        public static void BuildBoard()
        {
            Board board = new Board(8, 8);

            // PEÇAS PRETAS (RED) EM CIMA

            // Torres
            board.PlacePiece(new Rook(Color.Red, board), new Position(0, 0));
            board.PlacePiece(new Rook(Color.Red, board), new Position(0, 7));

            // Cavalos
            board.PlacePiece(new Knight(Color.Red, board), new Position(0, 1));
            board.PlacePiece(new Knight(Color.Red, board), new Position(0, 6));

            // Bispos
            board.PlacePiece(new Bishop(Color.Red, board), new Position(0, 2));
            board.PlacePiece(new Bishop(Color.Red, board), new Position(0, 5));

            // Rainha
            board.PlacePiece(new Queen(Color.Red, board), new Position(0, 3));

            // Rei
            board.PlacePiece(new King(Color.Red, board), new Position(0, 4));

            // Peões
            for (int i = 0; i < 8; i++)
            {
                board.PlacePiece(new Pawn(Color.Red, board), new Position(1, i));
            }


            // PEÇAS BRANCAS EMBAIXO

            // Torres
            board.PlacePiece(new Rook(Color.White, board), new Position(7, 0));
            board.PlacePiece(new Rook(Color.White, board), new Position(7, 7));

            // Cavalos
            board.PlacePiece(new Knight(Color.White, board), new Position(7, 1));
            board.PlacePiece(new Knight(Color.White, board), new Position(7, 6));

            // Bispos
            board.PlacePiece(new Bishop(Color.White, board), new Position(7, 2));
            board.PlacePiece(new Bishop(Color.White, board), new Position(7, 5));

            // Rainha
            board.PlacePiece(new Queen(Color.White, board), new Position(7, 3));

            // Rei
            board.PlacePiece(new King(Color.White, board), new Position(7, 4));

            // Peões
            for (int i = 0; i < 8; i++)
            {
                board.PlacePiece(new Pawn(Color.White, board), new Position(6, i));
            }

            PrintBoard(board);
        }
    }
}
