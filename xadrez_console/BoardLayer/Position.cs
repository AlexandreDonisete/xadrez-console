using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez_console.Tabuleiro
{
    internal class Position
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Position(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString()
        {
            return $"{Linha}, {Coluna}";
        }
    }
}
