using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.board;
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
                        Console.Write(board.ReturnPiece(new Position(i,j)) + " ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
    }
}
