using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.BoardLayer;

namespace xadrez_console.ChessLayer
{
    internal class King : Piece
    {
        private ChessMatch ChessMatch;
        public King(Color color, Board board, ChessMatch chessMatch) : base(color, board)
        {
            ChessMatch = chessMatch;
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != Color;
        }

        private bool CanRookCastling(Position position)
        {
            Piece piece = Board.GetPiece(position);

            return piece != null && piece is Rook && piece.Color.Equals(Color) && piece.QtyMoves == 0;
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

            // #Jogada Especial Roque 
            if (QtyMoves == 0 && !ChessMatch.Check)
            {
                // Roque Pequeno
                Position rookPosition1 = new Position(Position.Row, Position.Column + 3);
                if (CanRookCastling(rookPosition1))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);

                    if (Board.GetPiece(p1) == null && Board.GetPiece(p2) == null)
                    {
                        possiblePositions[Position.Row, Position.Column + 2] = true;
                    }
                }

                // Roque Grande
                Position rookPosition2 = new Position(Position.Row, Position.Column - 4);
                if (CanRookCastling(rookPosition2))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);

                    if (Board.GetPiece(p1) == null && Board.GetPiece(p2) == null && Board.GetPiece(p3) == null)
                    {
                        possiblePositions[Position.Row, Position.Column - 2] = true;
                    }
                }

            }




            return possiblePositions;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
