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
            Board board = new Board(8,8);
            try
            {
                board.IncludePieces(new Rook(board, Color.Black), new Position(0, 0));
                board.IncludePieces(new Horse(board, Color.Black), new Position(0, 1));
                board.IncludePieces(new Bishop(board, Color.Black), new Position(0, 2));
                board.IncludePieces(new Queen(board, Color.Black), new Position(0, 3));
                board.IncludePieces(new King(board, Color.Black), new Position(0, 4));
                board.IncludePieces(new Bishop(board, Color.Black), new Position(0, 5));
                board.IncludePieces(new Horse(board, Color.Black), new Position(0, 6));
                board.IncludePieces(new Rook(board, Color.Black), new Position(0, 7));
                board.IncludePieces(new Rook(board, Color.White), new Position(7, 7));
                for (int i = 0; i < 8; i++)
                {
                    board.IncludePieces(new Pawn(board, Color.Black), new Position(1, i));
                }
                Screen.PrintBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            
            
            
        }
    }
}
