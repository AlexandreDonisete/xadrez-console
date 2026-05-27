using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.BoardLayer;

namespace xadrez_console.ChessLayer
{
    internal class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
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

            // Acima
            p.SetPositionValues(Position.Row - 1, Position.Column);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            // Diagonal superior direita
            p.SetPositionValues(Position.Row - 1, Position.Column + 1);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            // Direita
            p.SetPositionValues(Position.Row, Position.Column + 1);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            // Diagonal inferior direita
            p.SetPositionValues(Position.Row + 1, Position.Column + 1);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            // Abaixo
            p.SetPositionValues(Position.Row + 1, Position.Column);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            // Diagonal inferior esquerda
            p.SetPositionValues(Position.Row + 1, Position.Column - 1);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            // Esquerda
            p.SetPositionValues(Position.Row, Position.Column - 1);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            // Diagonal superior esquerda
            p.SetPositionValues(Position.Row - 1, Position.Column - 1);
            if (Board.PositionExists(p) && CanMove(p))
                possiblePositions[p.Row, p.Column] = true;

            return possiblePositions;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
