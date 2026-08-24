using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models.Pieces;

sealed class Pawn : Piece
{
    public class PawnException(string message) : Exception(message);
    
    private bool _firstMove;
    private readonly int _promotionRowIndex;
    
    public Pawn(Texture2D texture, Square square, PlayerPieceColor playerPieceColor) : base(texture, square, playerPieceColor)
    {
        switch (playerPieceColor)
        {
            case PlayerPieceColor.White:
                _promotionRowIndex = 0;
                _firstMove = _currentSquare.RowIndex == 6;
                break;
            case PlayerPieceColor.Black:
                _promotionRowIndex = 7;
                _firstMove = _currentSquare.RowIndex == 1;
                break;
            default:
                throw new PawnException($"Invalid piece pieceColor. Expecting 'white' or 'black'; got {playerPieceColor}.");
        }

        Value = 1;
    }

    public override void Update(GameTime gameTime)
    {
        throw new NotImplementedException();
    }
    
    public override List<Square> GetPossibleMoves(IBoard board)
    {
        List<Square> possibleMoves = new List<Square>();
        int i = _currentSquare.RowIndex;
        int j = _currentSquare.ColumnIndex;
        Square[,] boardArray = board.GetArray();
        possibleMoves.AddRange(CheckForwardMoves(i, j, boardArray));
        possibleMoves.AddRange(CheckAttackMoves(i, j, boardArray));
        return possibleMoves;
    }

    /// <summary>
    /// Check if the Pawn piece can be promoted to a Queen. The Pawn can be
    /// promoted when it has reached the other side of the board; in other words,
    /// it has moved forward by 6 squares.
    /// </summary>
    /// <returns></returns>
    public bool CanPromote()
    {
        return _currentSquare.RowIndex - _promotionRowIndex == 6;
    }

    /// <summary>
    /// Promote the Pawn piece to a Queen piece.
    /// </summary>
    /// <returns>IPiece interface for a Queen instance.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public IPiece Promote()
    {
        throw new NotImplementedException("This method is not implemented");
    }

    /// <summary>
    /// Checks whether the Pawn can move forward. If the Pawn has not made its
    /// first move, it may move up twice - otherwise it may only move forwards
    /// once.
    /// </summary>
    /// <param name="i">Current square's row index</param>
    /// <param name="j">Current square's column index.</param>
    /// <param name="board">The 2-dimensional array of Square objects.</param>
    /// <returns>List of possible squares going forwards.</returns>
    private List<Square> CheckForwardMoves(int i, int j, Square[,] board)
    {
        List<Square> squares = new List<Square>();
        int once = i + 1*_direction;
        int twice = i + 2*_direction;
        try
        {
            if (!board[once, j].IsOccupied) squares.Add(board[once, j]);
            if (_firstMove && !board[twice, j].IsOccupied) squares.Add(board[twice, j]);
        }
        catch (IndexOutOfRangeException e)
        { }
        
        return squares;
    }

    /// <summary>
    /// Checks for Pawn's attacking moves in squares [i+1,j+-1].
    /// </summary>
    /// <param name="i">Current square's row index</param>
    /// <param name="j">Current square's column index.</param>
    /// <param name="board">The 2-dimensional array of Square objects.</param>
    /// <returns>List of possible attacking move squares.</returns>
    private List<Square> CheckAttackMoves(int i, int j, Square[,] board)
    {
        List<Square> squares = new List<Square>();
        try
        {
            Square left = board[i + 1 * _direction, j - 1 * _direction];
            Square right = board[i + 1 * _direction, j + 1 *  _direction];
            if (left.IsOccupied) squares.Add(left);
            if (right.IsOccupied) squares.Add(right);
        }
        catch (IndexOutOfRangeException e)
        { }
        return squares;
    }
}