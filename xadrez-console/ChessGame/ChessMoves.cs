using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.board;
using xadrez_console.board.Enums;
using xadrez_console.board.Exceptions;

namespace xadrez_console.ChessGame
{
    class ChessMoves
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Ended;
        private HashSet<Piece> InGamePieces;
        private HashSet<Piece> OutGamePieces;
        public ChessMoves()
        {
            Board = new Board(8, 8); // O tabuleiro de xadrez é sempre 8x8
            Turn = 1; // Turno atual do jogo
            CurrentPlayer = Color.White; // Xadrez começa sempre com as peças brancas
            Ended = false;
            InGamePieces = new HashSet<Piece>();
            OutGamePieces = new HashSet<Piece>();
            IncludeInitialPieces();
        }
        public void VerifyInitialPosition(Position initialPosition)
        {
            if (Board.ReturnPiece(initialPosition) == null)
            {
                throw new BoardException("Don't exist a piece in this position");
            }
            if (CurrentPlayer != Board.ReturnPiece(initialPosition).Color)
            {
                throw new BoardException("Wrong color");
            }
            if (!Board.ReturnPiece(initialPosition).ExistPossibleMovements())
            {
                throw new BoardException("This piece cannot make a movement");
            }
        }
        public void VerifyFinalPosition(Position initialPosition, Position finalPosition)
        {
            if (!Board.ReturnPiece(initialPosition).PossibleMovements()[finalPosition.Row, finalPosition.Column])
            {
                throw new BoardException("Invalid final position! ");
            }
        }
        public void MakeMoviment(Position initialPosition, Position finalPosition, bool[,] possibleMovements) //Executa o movimento das peças
        {
            if (possibleMovements[finalPosition.Row, finalPosition.Column])
            {
                Piece movingPiece = Board.RemovePiece(initialPosition); //Tira a peça que vai se mover do local de onde ela estava
                Piece outPiece = Board.RemovePiece(finalPosition); // Remove a peça que estava no destino
                Board.IncludePiece(movingPiece, finalPosition); // Coloca a peça inicial na posição desejada
                if (outPiece != null)
                {
                    OutGamePieces.Add(outPiece);
                }
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
        public void IncludeOnePiece(char column, int row, Piece piece)
        {
            Board.IncludePiece(piece, new ChessPosition(column, row).ReturnPosition());
            InGamePieces.Add(piece);
        }
        private void IncludeInitialPieces()
        {
            //Incluindo peças pretas
            IncludeOnePiece('a', 8, new Rook(Board, Color.Black));
            IncludeOnePiece('b', 8, new Horse(Board, Color.Black));
            IncludeOnePiece('c', 8, new Bishop(Board, Color.Black));
            IncludeOnePiece('d', 8, new Queen(Board, Color.Black));
            IncludeOnePiece('e', 8, new King(Board, Color.Black));
            IncludeOnePiece('f', 8, new Bishop(Board, Color.Black));
            IncludeOnePiece('g', 8, new Horse(Board, Color.Black));
            IncludeOnePiece('h', 8, new Rook(Board, Color.Black));
            IncludeOnePiece('a', 7, new Pawn(Board, Color.Black));
            IncludeOnePiece('b', 7, new Pawn(Board, Color.Black));
            IncludeOnePiece('c', 7, new Pawn(Board, Color.Black));
            IncludeOnePiece('d', 7, new Pawn(Board, Color.Black));
            IncludeOnePiece('e', 7, new Pawn(Board, Color.Black));
            IncludeOnePiece('f', 7, new Pawn(Board, Color.Black));
            IncludeOnePiece('g', 7, new Pawn(Board, Color.Black));
            IncludeOnePiece('h', 7, new Pawn(Board, Color.Black));
            //Incluindo peçar brancas
            IncludeOnePiece('a', 1, new Rook(Board, Color.White));
            IncludeOnePiece('b', 1, new Horse(Board, Color.White));
            IncludeOnePiece('c', 1, new Bishop(Board, Color.White));
            IncludeOnePiece('d', 1, new Queen(Board, Color.White));
            IncludeOnePiece('e', 1, new King(Board, Color.White));
            IncludeOnePiece('f', 1, new Bishop(Board, Color.White));
            IncludeOnePiece('g', 1, new Horse(Board, Color.White));
            IncludeOnePiece('h', 1, new Rook(Board, Color.White));
            IncludeOnePiece('a', 2, new Pawn(Board, Color.White));
            IncludeOnePiece('b', 2, new Pawn(Board, Color.White));
            IncludeOnePiece('c', 2, new Pawn(Board, Color.White));
            IncludeOnePiece('d', 2, new Pawn(Board, Color.White));
            IncludeOnePiece('e', 2, new Pawn(Board, Color.White));
            IncludeOnePiece('f', 2, new Pawn(Board, Color.White));
            IncludeOnePiece('g', 2, new Pawn(Board, Color.White));
            IncludeOnePiece('h', 2, new Pawn(Board, Color.White));
        }
        public HashSet<Piece> OutPiecesColor(Color color)
        {
            HashSet<Piece> returnOutPiecesColor = new HashSet<Piece>();
            foreach (Piece obj in OutGamePieces)
            {
                if (obj.Color == color)
                {
                    returnOutPiecesColor.Add(obj);
                }
            }
            return returnOutPiecesColor;
        }
        public HashSet<Piece> InPiecesColor(Color color)
        {
            HashSet<Piece> returnInPiecesColor = new HashSet<Piece>();
            foreach (Piece obj in InGamePieces)
            {
                if (obj.Color == color)
                {
                    returnInPiecesColor.Add(obj);
                }
            }
            return returnInPiecesColor;
        }
        
    }
}
