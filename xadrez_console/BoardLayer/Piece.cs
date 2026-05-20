using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez_console.BoardLayer
{
    internal class Piece
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


    }
}
