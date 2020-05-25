using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.board.Enums;

namespace xadrez_console.board
{
    class Piece
    {
        public Color Color { get; protected set; }
        public Position Position { get; set; }
        public Board Board { get; protected set; }
        public int AmountMoves { get; set; }

        public Piece(Color color, Position position, Board board)
        {
            Color = color;
            Position = position;
            Board = board;
            AmountMoves = 0;
        }
    }
}
