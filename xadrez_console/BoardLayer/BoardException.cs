using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez_console.BoardLayer
{
    internal class BoardException : ApplicationException
    {
        public BoardException()
        {
        }

        public BoardException(string? message) : base(message)
        {
        }
    }
}
