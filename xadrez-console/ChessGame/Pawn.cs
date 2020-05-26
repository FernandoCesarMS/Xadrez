using xadrez_console.board;
using xadrez_console.board.Enums;

namespace xadrez_console.ChessGame
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(color, board)
        {

        }
        public override string ToString()
        {
            return "P";
        }
    }
}
