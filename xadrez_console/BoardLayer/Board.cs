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

        public void PlacePiece(Piece piece, Position position)
        {
            _pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }
    }
}
