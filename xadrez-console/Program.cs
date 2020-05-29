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
            ChessMoves chessMoves = new ChessMoves();
            try
            {
                while (!chessMoves.Ended) 
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintBoard(chessMoves.Board);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + chessMoves.Turn);
                        Console.WriteLine("Aguardando jogada: " + chessMoves.CurrentPlayer);
                        Console.Write("Origem: ");
                        Position origin = Screen.readPosition().ReturnPosition();
                        chessMoves.VerifyInitialPosition(origin);
                        Console.Clear();
                        bool[,] possibleMovements = chessMoves.Board.ReturnPiece(origin).PossibleMovements();
                        Screen.PrintBoard(chessMoves.Board, possibleMovements);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + chessMoves.Turn);
                        Console.WriteLine("Aguardando jogada: " + chessMoves.CurrentPlayer);
                        Console.Write("Destino: ");
                        Position destiny = Screen.readPosition().ReturnPosition();
                        chessMoves.VerifyFinalPosition(origin, destiny);
                        chessMoves.MakeMoviment(origin, destiny, possibleMovements);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            
            
            
        }
    }
}
