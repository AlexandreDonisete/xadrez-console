using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.BoardLayer;

namespace xadrez_console.ChessLayer
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; set; }
        public Color CurrentPlayer { get; set; }
        public bool CheckMate { get; set; }
        public Piece EnPassantVunerable { get; set; }
        public Piece Promoted { get; set; }


        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            CheckMate = false;
            BuildBoardWithPieces();
        }

        public void PerformChessMove(Position source, Position target)
        {
            Piece movedPiece = Board.RemovePiece(source);

            movedPiece.IncreaseMoveCount();

            Piece capturedPiece = Board.RemovePiece(target);


            Board.PlacePiece(movedPiece, target);
        }

        private void BuildBoardWithPieces()
        {
            // Torres Brancas
            Board.PlacePiece(new Rook(Color.White, Board), new ChessPosition('a', 1).ToPosition());
            Board.PlacePiece(new Rook(Color.White, Board), new ChessPosition('h', 1).ToPosition());

            // Cavalos Brancos
            Board.PlacePiece(new Knight(Color.White, Board), new ChessPosition('b', 1).ToPosition());
            Board.PlacePiece(new Knight(Color.White, Board), new ChessPosition('g', 1).ToPosition());

            // Bispos Branco
            Board.PlacePiece(new Bishop(Color.White, Board), new ChessPosition('c', 1).ToPosition());
            Board.PlacePiece(new Bishop(Color.White, Board), new ChessPosition('f', 1).ToPosition());

            // Dama e Rei Brancos
            Board.PlacePiece(new Queen(Color.White, Board), new ChessPosition('d', 1).ToPosition());
            Board.PlacePiece(new King(Color.White, Board), new ChessPosition('e', 1).ToPosition());

            // Peões Brancos
            for (char i = 'a'; i <= 'h'; i++)
            {
                Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition(i, 2).ToPosition());
            }


            // Torres Pretas
            Board.PlacePiece(new Rook(Color.Red, Board), new ChessPosition('a', 8).ToPosition());
            Board.PlacePiece(new Rook(Color.Red, Board), new ChessPosition('h', 8).ToPosition());

            // Cavalos Pretos
            Board.PlacePiece(new Knight(Color.Red, Board), new ChessPosition('b', 8).ToPosition());
            Board.PlacePiece(new Knight(Color.Red, Board), new ChessPosition('g', 8).ToPosition());

            // Bispos Pretos
            Board.PlacePiece(new Bishop(Color.Red, Board), new ChessPosition('c', 8).ToPosition());
            Board.PlacePiece(new Bishop(Color.Red, Board), new ChessPosition('f', 8).ToPosition());

            // Dama e Rei Pretos
            Board.PlacePiece(new Queen(Color.Red, Board), new ChessPosition('d', 8).ToPosition());
            Board.PlacePiece(new King(Color.Red, Board), new ChessPosition('e', 8).ToPosition());

            // Peões Pretos
            for (char i = 'a'; i <= 'h'; i++)
            {
                Board.PlacePiece(new Pawn(Color.Red, Board), new ChessPosition(i, 7).ToPosition());
            }

        }
    }
}
