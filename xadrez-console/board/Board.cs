using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez_console.board
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Piece[,] Pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[Rows, Columns];
        }
    }
}
