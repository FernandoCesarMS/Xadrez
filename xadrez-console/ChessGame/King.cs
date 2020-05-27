using System;
using xadrez_console.board;
using xadrez_console.board.Enums;

namespace xadrez_console.ChessGame
{
    class King : Piece
    {
        public King(Board board, Color color) : base(color, board)
        {

        }
        
        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMoviment = new bool[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Math.Abs(i - Position.Row) <= 1 && Math.Abs(j - Position.Column) <= 1 && (i != Position.Row || j != Position.Column))
                    {
                        possibleMoviment[i,j] = VerifyMovement(new Position(i, j));
                    }
                }
            }
            return possibleMoviment;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
