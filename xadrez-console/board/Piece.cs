using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.board.Enums;

namespace xadrez_console.board
{
    abstract class Piece
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
        public bool ExistPossibleMovements()
        {
            bool[,] possibleMovements = PossibleMovements();
            bool returnExistPossibleMovements = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (possibleMovements[i, j])
                    {
                        returnExistPossibleMovements = true;
                    }
                }
            }
            return returnExistPossibleMovements;

        }
        protected bool VerifyMovement(Position position)
        {
            bool returnVerifyMovement = true;
            if (Board.ExistPiece(position) && Color == Board.ReturnPiece(position).Color)
            {
                returnVerifyMovement = false;
            }
            return returnVerifyMovement;
        }
        public abstract bool[,] PossibleMovements();
    }
}
