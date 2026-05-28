using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.BoardLayer;

namespace xadrez_console.ChessLayer
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool CheckMate { get; set; }
        public bool Check { get; private set; }
        public Piece EnPassantVunerable { get; set; }
        public Piece Promoted { get; set; }
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _capturedPieces;


        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            CheckMate = false;
            Check = false;
            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();
            BuildBoardWithPieces();
        }

        public Piece PerformChessMove(Position source, Position target)
        {
            Piece movedPiece = Board.RemovePiece(source);

            movedPiece.IncreaseMoveCount();

            Piece capturedPiece = Board.RemovePiece(target);

            Board.PlacePiece(movedPiece, target);

            if (capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void UndoMove(Position source, Position target, Piece capturedPiece)
        {
            Piece movedPiece = Board.RemovePiece(target);
            movedPiece.DecreaseMoveCount();

            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, target);
                _capturedPieces.Remove(capturedPiece);
            }
            Board.PlacePiece(movedPiece, source);
        }

        public void MakePlay(Position source, Position target)
        {
            Piece capturedPiece = PerformChessMove(source, target);

            if (IsChecked(CurrentPlayer))
            {
                UndoMove(source, target, capturedPiece);
                throw new BoardException("Você não pode se colocar em xeque!");
            }

            if (IsChecked(OpponentColor(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (IsCheckMate(OpponentColor(CurrentPlayer)))
            {
                CheckMate = true;
                return;
            }


            Turn++;
            ChangePlayer();
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer.Equals(Color.White))
            {
                CurrentPlayer = Color.Red;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public void ValidateSourcePosition(Position source)
        {
            if (Board.GetPiece(source) == null)
            {
                throw new BoardException("Não existe peça na posição de origeme escolhida.");
            }
            if (!CurrentPlayer.Equals(Board.GetPiece(source).Color))
            {
                throw new BoardException("A peça de origem escolhida não é sua!");
            }
            if (!Board.GetPiece(source).IsThereAnyPossibleMove())
            {
                throw new BoardException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidadeTargetPosition(Position source, Position target)
        {
            if (!Board.GetPiece(source).CanMoveTo(target))
            {
                throw new BoardException("Posição de destino inválida!");
            }
        }

        public HashSet<Piece> CapturedPiecesByColor(Color color)
        {
            HashSet<Piece> capturedPiecesByColor = new HashSet<Piece>();

            foreach (Piece piece in _capturedPieces)
            {
                if (piece.Color.Equals(color))
                {
                    capturedPiecesByColor.Add(piece);
                }
            }

            return capturedPiecesByColor;
        }

        public HashSet<Piece> PiecesInGameByColor(Color color)
        {
            HashSet<Piece> piecesInGameByColor = new HashSet<Piece>();

            foreach (Piece piece in _pieces)
            {
                if (piece.Color.Equals(color))
                {
                    piecesInGameByColor.Add(piece);
                }
            }
            piecesInGameByColor.ExceptWith(CapturedPiecesByColor(color));
            return piecesInGameByColor;
        }

        private Color OpponentColor(Color color)
        {
            if (color.Equals(Color.White))
            {
                return Color.Red;
            }

            return Color.White;
        }

        private Piece KingByColor(Color color)
        {
            foreach (Piece piece in PiecesInGameByColor(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsChecked(Color color)
        {
            Piece king = KingByColor(color);

            if (king == null)
            {
                throw new BoardException($"Não tem rei da cor: {color} no tabuleiro");
            }

            foreach (Piece piece in PiecesInGameByColor(OpponentColor(color)))
            {
                bool[,] possibleMoves = piece.PossibleMoves();

                if (possibleMoves[king.Position.Row, king.Position.Column])
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsCheckMate(Color color)
        {
            if (!IsChecked(color))
            {
                return false;
            }

            foreach (Piece piece in PiecesInGameByColor(color))
            {
                bool[,] possibleMoves = piece.PossibleMoves();

                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (possibleMoves[i, j])
                        {
                            Position target = new Position(i, j);
                            Position source = piece.Position;
                            Piece capturedPiece = PerformChessMove(source, target);
                            bool isCheck = IsChecked(color);
                            UndoMove(source, target, capturedPiece);
                            if (!isCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, row).ToPosition());
            _pieces.Add(piece);
        }

        private void BuildBoardWithPieces()
        {

            ////// Torres Brancas
            //PlaceNewPiece('a', 1, new Rook(Color.White, Board));
            //PlaceNewPiece('h', 1, new Rook(Color.White, Board));

            ////// Cavalos Brancos
            //PlaceNewPiece('b', 1, new Knight(Color.White, Board));
            //PlaceNewPiece('g', 1, new Knight(Color.White, Board));

            ////// Bispos Brancos
            //PlaceNewPiece('c', 1, new Bishop(Color.White, Board));
            //PlaceNewPiece('f', 1, new Bishop(Color.White, Board));

            ////// Dama e Rei Brancos
            //PlaceNewPiece('d', 1, new Queen(Color.White, Board));
            //PlaceNewPiece('e', 1, new King(Color.White, Board));

            ////// Peões Brancos
            //for (char i = 'a'; i <= 'h'; i++)
            //{
            //    PlaceNewPiece(i, 2, new Pawn(Color.White, Board));
            //}

            ////// Torres Pretas
            //PlaceNewPiece('a', 8, new Rook(Color.Red, Board));
            //PlaceNewPiece('h', 8, new Rook(Color.Red, Board));

            ////// Cavalos Pretos
            //PlaceNewPiece('b', 8, new Knight(Color.Red, Board));
            //PlaceNewPiece('g', 8, new Knight(Color.Red, Board));

            ////// Bispos Pretos
            //PlaceNewPiece('c', 8, new Bishop(Color.Red, Board));
            //PlaceNewPiece('f', 8, new Bishop(Color.Red, Board));

            ////// Dama e Rei Pretos
            //PlaceNewPiece('d', 8, new Queen(Color.Red, Board));
            //PlaceNewPiece('e', 8, new King(Color.Red, Board));

            ////// Peões Pretos
            //for (char i = 'a'; i <= 'h'; i++)
            //{
            //    PlaceNewPiece(i, 7, new Pawn(Color.Red, Board));
            //}

            PlaceNewPiece('c', 1, new Rook(Color.White, Board));
            PlaceNewPiece('c', 2, new Rook(Color.White, Board));
            PlaceNewPiece('d', 2, new Rook(Color.White, Board));
            PlaceNewPiece('e', 2, new Rook(Color.White, Board));
            PlaceNewPiece('e', 1, new Rook(Color.White, Board));
            PlaceNewPiece('d', 1, new King(Color.White, Board));

            PlaceNewPiece('c', 8, new Rook(Color.Red, Board));
            PlaceNewPiece('c', 7, new Rook(Color.Red, Board));
            PlaceNewPiece('d', 7, new Rook(Color.Red, Board));
            PlaceNewPiece('e', 7, new Rook(Color.Red, Board));
            PlaceNewPiece('e', 8, new Rook(Color.Red, Board));
            PlaceNewPiece('d', 8, new King(Color.Red, Board));


        }
    }
}
