using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez_console.board.Exceptions
{
    class BoardException : Exception
    {
        public BoardException(string mensage) : base(mensage) { }
    }
}
