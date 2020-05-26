using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.board.Exceptions;

namespace xadrez_console.board
{
    class Board
    {
        public int Rows { get; set; } // Numero de linhas do tabuleiro
        public int Columns { get; set; } // Numero de colunas do tabuleiro
        private Piece[,] Pieces; // Matriz com as peças do tabuleiro

        public Board(int rows, int columns) // Construtor
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[Rows, Columns];
        }
        public Piece ReturnPiece(Position position) // Retorna a peça em determinada posição
        {
            ExceptionValidatePosition(position);
            return Pieces[position.Row,position.Column];
        }
        public void IncludePiece(Piece piece, Position position) // Inclui determinada peça em determinada posição
        {
            if (ExistPiece(position))
            {
                throw new BoardException("There is already a piece in this position");
            }
            else
            {
                piece.Position = position;
                Pieces[position.Row, position.Column] = piece;
            }
            
        }
        public Piece RemovePiece(Position position)
        {
            if (ExistPiece(position))
            {
                Piece aux = ReturnPiece(position);
                Pieces[position.Row, position.Column] = null;
                return aux;
            }
            else
            {
                return null;
            }

        }
        public bool ValidatePosition(Position position) // Valida se existe determinada posição no tabuleiro
        {
            if (position.Row<0 || position.Row>=Rows || position.Column<0 || position.Column>=Columns)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ExceptionValidatePosition(Position position) // Lança uma exceção caso a posição não exista no tabuleiro
        {
            if (!ValidatePosition(position))
            {
                throw new BoardException("Invalid Position!");
            }
        }
        public bool ExistPiece(Position position) // Verifica se existe alguma peça na posição, utilizando exceção para o caso da posição não existir no tabuleirp
        {
            ExceptionValidatePosition(position);
            return ReturnPiece(position) != null;
        }
    }
}
