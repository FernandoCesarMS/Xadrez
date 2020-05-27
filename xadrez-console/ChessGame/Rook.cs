using System.Globalization;
using xadrez_console.board;
using xadrez_console.board.Enums;

namespace xadrez_console.ChessGame
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(color, board)
        {

        }
        
        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMoviment = new bool[8, 8];
            //direita
            for (int i = Position.Column + 1; i < 8; i++)
            {
                possibleMoviment[Position.Row, i] = VerifyMovement(new Position(Position.Row, i));
                if (Board.ExistPiece(new Position(Position.Row, i)))
                {
                    break;
                }
            }
            //esquerda
            for (int i = Position.Column - 1; i >= 0; i--)
            {
                possibleMoviment[Position.Row, i] = VerifyMovement(new Position(Position.Row, i));
                if (Board.ExistPiece(new Position(Position.Row, i)))
                {
                    break;
                }
            }
            //baixo
            for (int i = Position.Row + 1; i < 8; i++)
            {
                possibleMoviment[i, Position.Column] = VerifyMovement(new Position(i, Position.Column));
                if (Board.ExistPiece(new Position(i, Position.Column)))
                {
                    break;
                }
            }
            //cima
            for (int i = Position.Row - 1; i >= 0; i--)
            {
                possibleMoviment[i, Position.Column] = VerifyMovement(new Position(i, Position.Column));
                if (Board.ExistPiece(new Position(i, Position.Column)))
                {
                    break;
                }
            }
            return possibleMoviment;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
