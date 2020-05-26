using System;
using xadrez_console.board;
using xadrez_console.ChessGame;
using xadrez_console.board.Enums;
using xadrez_console.board.Exceptions;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMoves chessMoves = new ChessMoves();
                Screen.PrintBoard(chessMoves.Board);
                chessMoves.MakeMoviment(new ChessPosition('a', 7).ReturnPosition(), new ChessPosition('a', 2).ReturnPosition());
                Console.WriteLine();
                Screen.PrintBoard(chessMoves.Board);
                Console.WriteLine();
                chessMoves.MakeMoviment(new ChessPosition('a', 2).ReturnPosition(), new ChessPosition('a', 7).ReturnPosition());
                Screen.PrintBoard(chessMoves.Board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            
            
            
        }
    }
}
