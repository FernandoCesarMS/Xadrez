using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.board;
using xadrez_console.board.Enums;

namespace xadrez_console.ChessGame
{
    class ChessMoves
    {
        public Board Board { get; private set; }
        private int Turn;
        public Color CurrentPlayer { get; private set; }
        public bool Ended;
        public ChessMoves()
        {
            Board = new Board(8, 8); // O tabuleiro de xadrez é sempre 8x8
            Turn = 1; // Turno atual do jogo
            CurrentPlayer = Color.White; // Xadrez começa sempre com as peças brancas
            Ended = false;
            IncludeInitialPieces();
        }

        public void MakeMoviment(Position initialPosition, Position finalPosition, bool[,] possibleMovements) //Executa o movimento das peças
        {
            if (possibleMovements[finalPosition.Row, finalPosition.Column])
            {
                Piece movingPiece = Board.RemovePiece(initialPosition); //Tira a peça que vai se mover do local de onde ela estava
                Board.RemovePiece(finalPosition); // Remove a peça que estava no destino
                Board.IncludePiece(movingPiece, finalPosition); // Coloca a peça inicial na posição desejada
                movingPiece.IncreaseAmountMoves(); // Aumenta o número de movimentos da peça que se movimentou
                Turn++;
                if (CurrentPlayer == Color.White)
                {
                    CurrentPlayer = Color.Black;
                }
                else
                {
                    CurrentPlayer = Color.White;
                }
            }
        }
        private void IncludeInitialPieces()
        {
            Board.IncludePiece(new Rook(Board, Color.Black), new Position(0, 0));
            Board.IncludePiece(new Horse(Board, Color.Black), new Position(0, 1));
            Board.IncludePiece(new Bishop(Board, Color.Black), new Position(0, 2));
            Board.IncludePiece(new Queen(Board, Color.Black), new Position(0, 3));
            Board.IncludePiece(new King(Board, Color.Black), new Position(0, 4));
            Board.IncludePiece(new Bishop(Board, Color.Black), new Position(0, 5));
            Board.IncludePiece(new Horse(Board, Color.Black), new Position(0, 6));
            Board.IncludePiece(new Rook(Board, Color.Black), new Position(0, 7));
            for (int i = 0; i < 8; i++)
            {
                Board.IncludePiece(new Pawn(Board, Color.Black), new Position(1, i));
            }
            Board.IncludePiece(new Rook(Board, Color.White), new Position(7, 0));
            Board.IncludePiece(new Horse(Board, Color.White), new Position(7, 1));
            Board.IncludePiece(new Bishop(Board, Color.White), new Position(7, 2));
            Board.IncludePiece(new Queen(Board, Color.White), new Position(7, 3));
            Board.IncludePiece(new King(Board, Color.White), new Position(7, 4));
            Board.IncludePiece(new Bishop(Board, Color.White), new Position(7, 5));
            Board.IncludePiece(new Horse(Board, Color.White), new Position(7, 6));
            Board.IncludePiece(new Rook(Board, Color.White), new Position(7, 7));
            for (int i = 0; i < 8; i++)
            {
                Board.IncludePiece(new Pawn(Board, Color.White), new Position(6, i));
            }
        }
    }
}
