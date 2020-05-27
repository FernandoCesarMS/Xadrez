using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez_console.board
{
    class Position
    {
        public int Column { get; set; } // Posição em relação as colunas
        public int Row { get; set; } // Posição em relação as linhas
        public Position(int row, int column) // Construtor
        {
            Column = column;
            Row = row;
        }
        public void ChangePosition(int row, int column)
        {
            Column = column;
            Row = row;
        }
        public override string ToString() // Printa a posição
        {
            return Row + "," + Column;
        }
    }
}
