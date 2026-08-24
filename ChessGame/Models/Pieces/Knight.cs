using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models.Pieces;

sealed class Knight : Piece
{
    public class KnightException(string message) : Exception(message);

    public Knight(Texture2D texture, Square square, PlayerPieceColor playerPieceColor) : base(texture, square, playerPieceColor)
    {
        Value = 3;
    }

    public override void Update(GameTime gameTime)
    {
        // TODO: Implement Knight.Update()
        throw new NotImplementedException();
    }

    public override List<Square> GetPossibleMoves(IBoard board)
    {
        List<Square> possibleMoves = new List<Square>();
        int i = _currentSquare.RowIndex;
        int j = _currentSquare.ColumnIndex;
        Square[,] boardArray = board.GetArray();
        possibleMoves.AddRange(CheckMovesVertical(i, j, boardArray));
        
        // TODO: Implement Knight.GetPossibleMoves()
        return possibleMoves;
    }

    private List<Square> CheckMovesVertical(int i, int j, Square[,] board)
    {
        List<Square> possibleMoves = new List<Square>();

        int[] leftRight = [-1, 1];
        int[] upDown = [-2, 2];

        for (int k = 0; k < leftRight.Length; k++)
        {
            for (int l = 0; l < upDown.Length; l++)
            {
                try
                {
                    Square square = board[i + upDown[l], j + leftRight[k]];
                    possibleMoves.Add(square);
                }
                catch (IndexOutOfRangeException e)
                { }   
            }
        }
        return possibleMoves;
    }
}