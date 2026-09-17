using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Screens.Game.Model.Pieces;

sealed class Rook : Piece
{
    public class RookException(string message) : Exception(message);

    private bool _canTower;

    public Rook(Square square, PlayerPieceColor playerPieceColor) : base(square, playerPieceColor)
    {
        Value = 5;
    }

    public override void Update(GameTime gameTime)
    {
        throw new NotImplementedException();
    }

    public override List<Square> GetPossibleMoves(Board board)
    {
        List<Square> possibleMoves = new List<Square>();
        int i = _currentSquare.RowIndex;
        int j = _currentSquare.ColumnIndex;
        Square[,] boardArray = board.Array();
        possibleMoves.AddRange(GetForwardMoves(i, j, boardArray));
        possibleMoves.AddRange(GetBackwardMoves(i, j, boardArray));
        return possibleMoves;
    }

    private List<Square> GetForwardMoves(int i, int j, Square[,] board)
    {
        List<Square> possibleMoves = new List<Square>();
        try
        {
            while (true)
            {
                i += 1*_direction;
                Square square = board[i, j];
                if (square.IsOccupied)
                {
                    if (square.Occupant.PieceColor != _playerPieceColor)
                        possibleMoves.Add(square);
                    
                    break;
                }
                possibleMoves.Add(square);
            }
        }
        catch (IndexOutOfRangeException e) { }
        return possibleMoves;
    }
    
    private List<Square> GetBackwardMoves(int i, int j, Square[,] board)
    {
        List<Square> possibleMoves = new List<Square>();
        try
        {
            while (true)
            {
                i -= 1*_direction;
                Square square = board[i, j];
                if (square.IsOccupied)
                {
                    if (square.Occupant.PieceColor != _playerPieceColor)
                        possibleMoves.Add(square);
                    
                    break;
                }
                possibleMoves.Add(square);
            }
        }
        catch (IndexOutOfRangeException e) { }
        return possibleMoves;
    }
}