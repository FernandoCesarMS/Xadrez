using System;
using xadrez_console.board;
using xadrez_console.board.Enums;


namespace xadrez_console.ChessGame
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(color, board)
        {

        }

        private bool CaptureMovement(Position position)
        {
            bool returnCaptureMovement = false;
            if (Board.ExistPiece(position))
            {
                if (Color != Board.ReturnPiece(position).Color)
                {
                    returnCaptureMovement = true;
                }
            }
            
            return returnCaptureMovement;
        }
        private bool StraightMovement(Position position) 
        {
            bool returnStraightMovement = false;
            if (Math.Abs(Position.Row - position.Row) == 1 && Board.ReturnPiece(position) == null)
            {
                returnStraightMovement = true;
            }
            else if (Math.Abs(Position.Row - position.Row) == 2 && Board.ReturnPiece(position) == null)
            {
                int mediumPosition = (Position.Row + position.Row) / 2;
                if (Board.ReturnPiece(new Position(mediumPosition,position.Column)) == null && AmountMoves == 0)
                {
                    returnStraightMovement = true;
                }
            }
            return returnStraightMovement;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMoviment = new bool[8,8];
            if (Color == Color.Black)
            {
                //Diagonal para a esquerda
                Position position = new Position(Position.Row + 1, Position.Column - 1);
                if (Board.ValidatePosition(position) && CaptureMovement(position))
                {
                    possibleMoviment[position.Row, position.Column] = true;
                }
                //Reto para baixo
                position.ChangePosition(position.Row, position.Column + 1);
                if (Board.ValidatePosition(position) && StraightMovement(position))
                {
                    possibleMoviment[position.Row, position.Column] = true;
                }
                //Diagonal para a direita
                position.ChangePosition(position.Row, position.Column + 1);
                if (Board.ValidatePosition(position) && CaptureMovement(position))
                {
                    possibleMoviment[position.Row, position.Column] = true;
                }
                //Reto dois para baixo
                position.ChangePosition(position.Row + 1, position.Column - 1);
                if (Board.ValidatePosition(position) && StraightMovement(position))
                {
                    possibleMoviment[position.Row, position.Column] = true;
                }
            }
            if (Color == Color.White)
            {
                //Diagonal para a esquerda
                Position position = new Position(Position.Row - 1, Position.Column + 1);
                if (Board.ValidatePosition(position) && CaptureMovement(position))
                {
                    possibleMoviment[position.Row, position.Column] = true;
                }
                //Reto para cima
                position.ChangePosition(position.Row, position.Column - 1);
                if (Board.ValidatePosition(position) && StraightMovement(position))
                {
                    possibleMoviment[position.Row, position.Column] = true;
                }
                //Diagonal para a direita
                position.ChangePosition(position.Row, position.Column - 1);
                if (Board.ValidatePosition(position) && CaptureMovement(position))
                {
                    possibleMoviment[position.Row, position.Column] = true;
                }
                //Reto dois para cim
                position.ChangePosition(position.Row - 1, position.Column + 1);
                if (Board.ValidatePosition(position) && StraightMovement(position))
                {
                    possibleMoviment[position.Row, position.Column] = true;
                }
            }
            return possibleMoviment;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
