using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.board.Enums;

namespace xadrez_console.board
{
    class Piece
    {
        public Color Color { get; protected set; } // Cor da peça
        public Position Position { get; set; } // Posição da peça
        public Board Board { get; protected set; } // Tabuleiro
        public int AmountMoves { get; protected set; } // Quantidade de movimentos

        public Piece(Color color, Board board) /// Construtor
        {
            Color = color;
            Position = null;
            Board = board;
            AmountMoves = 0;
        }
        public void IncreaseAmountMoves() //Aumenta a quantidade de movimentos
        {
            AmountMoves++;
        }
    }
}
