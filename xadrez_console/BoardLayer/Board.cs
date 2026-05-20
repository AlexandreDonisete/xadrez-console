using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez_console.Tabuleiro
{
    internal class Board
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Piece[,] _pecas;

        public Board(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            _pecas = new Piece[linhas, colunas];
        }

        public Piece GetPiece(int linha, int coluna)
        {
            return _pecas[linha, coluna];
        }
    }
}
