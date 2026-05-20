using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez_console.Tabuleiro
{
    internal class Piece
    {
        public Position Posicao { get; set; }
        public Color Cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Board Tab { get; protected set; }

        public Piece(Position posicao, Color cor, Board tab)
        {
            Posicao = posicao;
            Cor = cor;
            Tab = tab;
            qteMovimentos = 0;
        }

    }
}
