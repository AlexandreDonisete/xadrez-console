using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez_console.BoardLayer
{
    internal abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtyMoves { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            QtyMoves = 0;
        }

        public void IncreaseMoveCount()
        {
            QtyMoves++;
        }

        public bool IsThereAnyPossibleMove()
        {
            bool[,] possibleMoves = PossibleMoves();

            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (possibleMoves[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Row, position.Column];
        }

        public abstract bool[,] PossibleMoves();
    }
}
