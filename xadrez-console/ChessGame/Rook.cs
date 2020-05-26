using xadrez_console.board;
using xadrez_console.board.Enums;

namespace xadrez_console.ChessGame
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(color, board)
        {

        }
        public override string ToString()
        {
            return "R";
        }
    }
}
