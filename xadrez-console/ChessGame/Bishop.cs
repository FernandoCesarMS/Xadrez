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
            bool[,] possibleMoviment = new bool[8, 8];
            //Diagonal direita superior
            int i, j;
            j = Position.Column + 1;
            for (i = Position.Row - 1; i >= 0 && j < 8; i--)
            {
                possibleMoviment[i, j] = this.VerifyMovement(new Position(i, j));
                if (Board.ExistPiece(new Position(i, j)))
                {
                    break;
                }
                j++;
            }
            //Diagonal esquerda superior
            j = Position.Column - 1;
            for (i = Position.Row - 1; i >= 0 && j >= 0; i--)
            {
                possibleMoviment[i, j] = VerifyMovement(new Position(i, j));
                if (Board.ExistPiece(new Position(i, j)))
                {
                    break;
                }
                j--;
            }
            //Diagonal direita inferior
            j = Position.Column + 1;
            for (i = Position.Row + 1; i < 8 && j < 8; i++)
            {
                possibleMoviment[i, j] = VerifyMovement(new Position(i, j));
                if (Board.ExistPiece(new Position(i, j)))
                {
                    break;
                }
                j++;
            }
            //Diagonal esquerda inferior
            j = Position.Column - 1;
            for (i = Position.Row + 1; i < 8 && j >= 0; i++)
            {
                possibleMoviment[i, j] = VerifyMovement(new Position(i, j));
                if (Board.ExistPiece(new Position(i, j)))
                {
                    break;
                }
                j--;
            }
            return possibleMoviment;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
