using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.BoardLayer;

namespace xadrez_console.ChessLayer
{
    internal class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {
        }

        private bool HasOpponent(Position position)
        {
            Piece opponentPiece = Board.GetPiece(position);

            return opponentPiece != null && opponentPiece.Color != Color;
        }

        private bool FreePosition(Position position)
        {
            return Board.GetPiece(position) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possiblePositions = new bool[Board.Rows, Board.Columns];

            Position p = new Position(0, 0);

            if (Color == Color.White)
            {
                p.SetPositionValues(Position.Row - 1, Position.Column);
                if (Board.PositionExists(p) && FreePosition(p))
                    possiblePositions[p.Row, p.Column] = true;

                p.SetPositionValues(Position.Row - 2, Position.Column);
                if (Board.PositionExists(p) && FreePosition(p) && QtyMoves == 0)
                    possiblePositions[p.Row, p.Column] = true;

                p.SetPositionValues(Position.Row - 1, Position.Column - 1);
                if (Board.PositionExists(p) && HasOpponent(p))
                    possiblePositions[p.Row, p.Column] = true;

                p.SetPositionValues(Position.Row - 1, Position.Column + 1);
                if (Board.PositionExists(p) && HasOpponent(p))
                    possiblePositions[p.Row, p.Column] = true;
            }
            else
            {
                p.SetPositionValues(Position.Row + 1, Position.Column);
                if (Board.PositionExists(p) && FreePosition(p))
                    possiblePositions[p.Row, p.Column] = true;

                p.SetPositionValues(Position.Row + 2, Position.Column);
                if (Board.PositionExists(p) && FreePosition(p) && QtyMoves == 0)
                    possiblePositions[p.Row, p.Column] = true;

                p.SetPositionValues(Position.Row + 1, Position.Column - 1);
                if (Board.PositionExists(p) && HasOpponent(p))
                    possiblePositions[p.Row, p.Column] = true;

                p.SetPositionValues(Position.Row + 1, Position.Column + 1);
                if (Board.PositionExists(p) && HasOpponent(p))
                    possiblePositions[p.Row, p.Column] = true;
            }

            return possiblePositions;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
