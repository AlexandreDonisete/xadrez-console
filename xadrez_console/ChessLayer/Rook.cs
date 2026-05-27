using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.BoardLayer;

namespace xadrez_console.ChessLayer
{
    internal class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board)
        {
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position p = new Position(0, 0);

            // Acima
            p.SetPositionValues(Position.Row - 1, Position.Column);
            while (Board.PositionExists(p) && CanMove(p))
            {
                mat[p.Row, p.Column] = true;

                if (Board.GetPiece(p) != null && Board.GetPiece(p).Color != Color)
                    break;

                p.Row--;
            }

            // Direita
            p.SetPositionValues(Position.Row, Position.Column + 1);
            while (Board.PositionExists(p) && CanMove(p))
            {
                mat[p.Row, p.Column] = true;

                if (Board.GetPiece(p) != null && Board.GetPiece(p).Color != Color)
                    break;

                p.Column++;
            }

            // Baixo
            p.SetPositionValues(Position.Row + 1, Position.Column);
            while (Board.PositionExists(p) && CanMove(p))
            {
                mat[p.Row, p.Column] = true;

                if (Board.GetPiece(p) != null && Board.GetPiece(p).Color != Color)
                    break;

                p.Row++;
            }

            // Esquerda
            p.SetPositionValues(Position.Row, Position.Column - 1);
            while (Board.PositionExists(p) && CanMove(p))
            {
                mat[p.Row, p.Column] = true;

                if (Board.GetPiece(p) != null && Board.GetPiece(p).Color != Color)
                    break;

                p.Column--;
            }

            return mat;
        }


        public override string ToString()
        {
            return "R";
        }
    }
}
