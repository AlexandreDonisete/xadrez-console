using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.BoardLayer;

namespace xadrez_console.BoardLayer
{
    internal class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] _pieces;

        public Board(int row, int column)
        {
            Rows = row;
            Columns = column;
            _pieces = new Piece[row, column];
        }

        public Piece GetPiece(int row, int column)
        {
            return _pieces[row, column];
        }

        public Piece GetPiece(Position pos)
        {
            return _pieces[pos.Row, pos.Column];
        }

        public bool ThereIsAPiece(Position pos)
        {
            ValidatePosition(pos);
            return GetPiece(pos) != null;
        }

        public void PlacePiece(Piece piece, Position position)
        {
            if (ThereIsAPiece(position))
            {
                throw new BoardException("There is a Piece in this position!");
            }

            if (PositionExists(position))
            {
                _pieces[position.Row, position.Column] = piece;
                piece.Position = position;

            }
        }

        public Piece RemovePiece(Position position)
        {
            if (GetPiece(position) == null)
            {
                return null;
            }

            Piece pieceRemoved = GetPiece(position);
            pieceRemoved.Position = null;
            _pieces[position.Row, position.Column] = null;

            return pieceRemoved;

        }

        public bool PositionExists(Position pos)
        {
            bool rowIsValid = pos.Row >= 0 && pos.Row < Rows;
            bool columnIsValid = pos.Column >= 0 && pos.Column < Columns;

            return rowIsValid && columnIsValid;
        }

        public void ValidatePosition(Position pos)
        {
            if (!PositionExists(pos))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
