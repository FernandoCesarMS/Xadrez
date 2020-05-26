using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using xadrez_console.board;
using xadrez_console.board.Enums;
namespace xadrez_console
{
    class Screen
    {
        public static void PrintBoard(Board board) // Mostra na tela todo o tabuleiro
        {
            for (int i = 0; i < board.Rows; i++) // Percorre as linhas da matriz
            {
                Console.Write(8-i + " ");
                for (int j = 0; j < board.Columns; j++) // Percorre as colunas da matriz
                {
                    if (board.ReturnPiece(new Position(i,j)) != null)
                    {
                        PrintPiece(board.ReturnPiece(new Position(i,j)));
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.Black)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
            else if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
        }
    }
}
