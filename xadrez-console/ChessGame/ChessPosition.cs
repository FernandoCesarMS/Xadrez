using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.board;
using xadrez_console.board.Exceptions;

namespace xadrez_console.ChessGame
{
    class ChessPosition
    {
        public int Row { get; set; }
        public char Column { get; set; }

        public ChessPosition(char column, char row)
        {
            Row = row;
            Column = column;
        }
        public Position ReturnPosition() // Transforma codigo de posição de xadrez uma posição de matriz que o compilador entenda 
        {
            if (Row <= 8 && Row >= 1)
            {
                switch (Column)
                {
                    case 'A':
                        return new Position(8 - Row, 0);
                    case 'a':
                        return new Position(8 - Row, 0);
                    case 'B':
                        return new Position(8 - Row, 1);
                    case 'b':
                        return new Position(8 - Row, 1);
                    case 'C':
                        return new Position(8 - Row, 2);
                    case 'c':
                        return new Position(8 - Row, 2);
                    case 'D':
                        return new Position(8 - Row, 3);
                    case 'd':
                        return new Position(8 - Row, 3);
                    case 'E':
                        return new Position(8 - Row, 4);
                    case 'e':
                        return new Position(8 - Row, 4);
                    case 'F':
                        return new Position(8 - Row, 5);
                    case 'f':
                        return new Position(8 - Row, 5);
                    case 'G':
                        return new Position(8 - Row, 6);
                    case 'g':
                        return new Position(8 - Row, 6);
                    case 'H':
                        return new Position(8 - Row, 7);
                    case 'h':
                        return new Position(8 - Row, 7);
                    default:
                        throw new BoardException("This position doesn't exist");
                } 
            }
            else
            {
                throw new BoardException("This position doesn't exist");
            }
        }
    }
}
