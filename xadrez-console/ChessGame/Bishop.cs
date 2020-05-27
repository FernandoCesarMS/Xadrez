using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.board;
using xadrez_console.board.Enums;
namespace xadrez_console.ChessGame
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(color, board)
        {

        }

        public override bool[,] PossibleMovements()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
