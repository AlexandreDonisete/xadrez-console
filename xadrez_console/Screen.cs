using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.Tabuleiro;

namespace xadrez_console
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Linhas; i++)
            {
                for (int j = 0; j < board.Colunas; j++)
                {
                    if (board.GetPiece(i, j) == null)
                    {
                        Console.Write("- ");

                    }
                    else
                    {
                        Console.Write($"{board.GetPiece(i, j)} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
