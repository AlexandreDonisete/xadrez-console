using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.BoardLayer;

namespace xadrez_console.ChessLayer
{
    internal class Knight : Piece
    {
        public Knight(Color color, Board board) : base(color, board)
        {
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != Color;
        }



        public override bool[,] PossibleMoves()
        {
            bool[,] possiblePositions = new bool[Board.Rows, Board.Columns];

            Position p = new Position(0, 0);

            p.SetPositionValues(Position.Row - 1, Position.Column - 2);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            p.SetPositionValues(Position.Row + 1, Position.Column + 2);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            p.SetPositionValues(Position.Row - 1, Position.Column + 2);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            p.SetPositionValues(Position.Row + 1, Position.Column - 2);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            p.SetPositionValues(Position.Row - 1, Position.Column + 2);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            p.SetPositionValues(Position.Row - 2, Position.Column - 1);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            p.SetPositionValues(Position.Row + 2, Position.Column - 1);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            p.SetPositionValues(Position.Row - 2, Position.Column + 1);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            p.SetPositionValues(Position.Row + 2, Position.Column + 1);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            return possiblePositions;
        }

        public override string ToString()
        {
            return "N";
        }
    }
}
