using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using xadrez_console.board;
using xadrez_console.board.Enums;
using xadrez_console.ChessGame;

namespace xadrez_console
{
    class Screen
    {
        public static void ShowBoard(ChessMoves chessMoves)
        {
            Console.Clear();
            PrintBoard(chessMoves.Board);
            Console.WriteLine();
            PrintOutGamePieces(chessMoves);
            Console.WriteLine("\nTurno: " + chessMoves.Turn);
            if (chessMoves.CurrentPlayer == Color.Black)
            {
                Console.Write("Aguardando jogada: ");
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(chessMoves.CurrentPlayer);
                Console.ForegroundColor = aux;
            }
            else
            {
                Console.WriteLine("Aguardando jogada: " + chessMoves.CurrentPlayer);
            }
        }
        public static void ShowBoard(ChessMoves chessMoves, bool[,] possibleMovements)
        {
            Console.Clear();
            PrintBoard(chessMoves.Board,possibleMovements);
            Console.WriteLine();
            PrintOutGamePieces(chessMoves);
            Console.WriteLine("\nTurno: " + chessMoves.Turn);
            if (chessMoves.CurrentPlayer == Color.Black)
            {
                Console.Write("Aguardando jogada: ");
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(chessMoves.CurrentPlayer);
                Console.ForegroundColor = aux;
            }
            else
            {
                Console.WriteLine("Aguardando jogada: " + chessMoves.CurrentPlayer);
            }
        }
        private static void PrintOutGamePieces(ChessMoves chessMoves)
        {
            Console.WriteLine("Peças Capturadas: ");
            Console.Write("Brancas: ");
            PrintHashSet(chessMoves.OutPiecesColor(Color.White));
            Console.Write("\nPretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintHashSet(chessMoves.OutPiecesColor(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        public static void PrintHashSet(HashSet<Piece> hashSet)
        {
            Console.Write("{ ");
            foreach (Piece obj in hashSet)
            {
                Console.Write(obj + " ");
            }
            Console.Write("}");
        }
        public static void PrintBoard(Board board) // Mostra na tela todo o tabuleiro
        {
            for (int i = 0; i < board.Rows; i++) // Percorre as linhas da matriz
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++) // Percorre as colunas da matriz
                {
                    PrintPiece(board.ReturnPiece(new Position(i, j)));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public static void PrintBoard(Board board,bool[,] possibleMovements) // Mostra na tela todo o tabuleiro
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor newBackgroundColor = ConsoleColor.Red;
            for (int i = 0; i < board.Rows; i++) // Percorre as linhas da matriz
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++) // Percorre as colunas da matriz
                {
                    if (possibleMovements[i, j])
                    {
                        Console.BackgroundColor = newBackgroundColor;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.ReturnPiece(new Position(i, j)));
                }
                Console.WriteLine();
                Console.BackgroundColor = originalBackground;
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public static void PrintPiece(Piece piece) // Printa na tela a peça com suas respectivas cores
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else if (piece.Color == Color.Black)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(piece + " ");
                Console.ForegroundColor = aux;
            }
            else if (piece.Color == Color.White)
            {
                Console.Write(piece + " ");
            }

        }
        public static ChessPosition readPosition()
        {
            string entrada = Console.ReadLine();
            char column = entrada[0];
            int row = int.Parse(entrada[1] + "");
            return new ChessPosition(column, row);
        }
    }
}
