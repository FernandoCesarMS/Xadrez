using xadrez_console.board;
using xadrez_console.board.Enums;

namespace xadrez_console.ChessGame
{
    class Horse : Piece
    {
        public Horse(Board board, Color color) : base(color, board)
        {

        }
        
        public override bool[,] PossibleMovements()
        {
            bool[,] possibleMoviment = new bool[8, 8];
            //Cima esquerda
            Position position = new Position(Position.Row - 2, Position.Column - 1);
            if (Board.ValidatePosition(position) && VerifyMovement((position)))
            {
                possibleMoviment[position.Row, position.Column] = true;
            }
            //Cima direita
            position.ChangePosition(Position.Row - 2, Position.Column + 1);
            if (Board.ValidatePosition(position) && VerifyMovement((position)))
            {
                possibleMoviment[position.Row, position.Column] = true;
            }
            //Direita cima
            position.ChangePosition(Position.Row - 1, Position.Column + 2);
            if (Board.ValidatePosition(position) && VerifyMovement((position)))
            {
                possibleMoviment[position.Row, position.Column] = true;
            }
            //Direita baixo
            position.ChangePosition(Position.Row + 1, Position.Column + 2);
            if (Board.ValidatePosition(position) && VerifyMovement((position)))
            {
                possibleMoviment[position.Row, position.Column] = true;
            }
            //Baixo esquerda
            position.ChangePosition(Position.Row + 2, Position.Column - 1);
            if (Board.ValidatePosition(position) && VerifyMovement((position)))
            {
                possibleMoviment[position.Row, position.Column] = true;
            }
            //Baixo direita
            position.ChangePosition(Position.Row + 2, Position.Column + 1);
            if (Board.ValidatePosition(position) && VerifyMovement((position)))
            {
                possibleMoviment[position.Row, position.Column] = true;
            }
            //Esquerda cima
            position.ChangePosition(Position.Row - 1, Position.Column - 2);
            if (Board.ValidatePosition(position) && VerifyMovement((position)))
            {
                possibleMoviment[position.Row, position.Column] = true;
            }
            //Esquerda baixo
            position.ChangePosition(Position.Row + 1, Position.Column - 2);
            if (Board.ValidatePosition(position) && VerifyMovement((position)))
            {
                possibleMoviment[position.Row, position.Column] = true;
            }
            //Cima direita
            position.ChangePosition(Position.Row - 2, Position.Column + 1);
            if (Board.ValidatePosition(position) && VerifyMovement((position)))
            {
                possibleMoviment[position.Row, position.Column] = true;
            }
            return possibleMoviment;
        }

        public override string ToString()
        {
            return "H";
        }
    }
}
