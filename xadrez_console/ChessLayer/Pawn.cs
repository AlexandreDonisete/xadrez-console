using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.BoardLayer;

namespace xadrez_console.ChessLayer
{
    internal class Pawn : Piece
    {
        private ChessMatch ChessMatch;
        public Pawn(Color color, Board board, ChessMatch chessMatch) : base(color, board)
        {
            ChessMatch = chessMatch;
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

                // #Jogada Especial EnPassant
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.PositionExists(left) && HasOpponent(left) && Board.GetPiece(left) == ChessMatch.EnPassantVunerable)
                    {
                        possiblePositions[left.Row -1, left.Column] = true;
                    }
                }

                if (Position.Row == 3)
                {
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.PositionExists(right) && HasOpponent(right) && Board.GetPiece(right) == ChessMatch.EnPassantVunerable)
                    {
                        possiblePositions[right.Row - 1, right.Column] = true;
                    }
                }

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

            // #Jogada Especial EnPassant
            if (Position.Row == 4)
            {
                Position left = new Position(Position.Row, Position.Column - 1);
                if (Board.PositionExists(left) && HasOpponent(left) && Board.GetPiece(left) == ChessMatch.EnPassantVunerable)
                {
                    possiblePositions[left.Row + 1, left.Column] = true;
                }

            }

            if (Position.Row == 4)
            {
                Position right = new Position(Position.Row, Position.Column + 1);
                if (Board.PositionExists(right) && HasOpponent(right) && Board.GetPiece(right) == ChessMatch.EnPassantVunerable)
                {
                    possiblePositions[right.Row + 1, right.Column] = true;
                }
            }

            return possiblePositions;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
