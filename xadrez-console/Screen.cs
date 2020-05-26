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
            for (int i = 0; i < board.Rows; i++)
            {
                for(int j = 0; j < board.Columns; j++)
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
        }
    }
}
