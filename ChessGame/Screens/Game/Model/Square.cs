using System;
using ChessGame.Screens.Game.Model.Pieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Screens.Game.Model;

public class Square
{
    public class SquareException(string message) : Exception(message);

    private int _rowIndex, _colIndex;
    
    /// <summary>
    /// Returns `true` if the square is currently selected.
    /// </summary>
    public bool IsSelected { get; private set; }
    
    /// <summary>
    /// Returns `true` if the square is a member of a piece's set of possible moves.
    /// </summary>
    public bool IsLegalMove { get; private set; }
    
    /// <summary>
    /// Square's occupation state.
    /// </summary>
    public bool IsOccupied { get; private set; }

    /// <summary>
    /// Square's current occupant.
    /// </summary>
    public IPiece Occupant { get; private set; }

    /// <summary>
    /// Row index, relative to the board.
    /// </summary>
    public int RowIndex => _rowIndex;
    
    /// <summary>
    /// Column index, relative to the board.
    /// </summary>
    public int ColumnIndex => _colIndex;
    
    /// <summary>
    /// Square size in pixels.
    /// </summary>
    public int Size { get; private set; }
    
    /// <summary>
    /// Squares position's x-axis pixel.
    /// </summary>
    public int PosX { get; private set; }
    
    /// <summary>
    /// Square position's y-axis
    /// </summary>
    public int PosY { get; private set; }

    public Square(int i, int j, int size, int posX, int posY)
    {
        Size = size;
        PosX = posX;
        PosY = posY;
        _rowIndex = i;
        _colIndex = j;
        Occupant = null;
        IsOccupied = false;
    }

    /// <summary>
    /// Produce the square name by combining the square's file and rank.
    /// </summary>
    /// <returns>Square name as a 2-character string (e.g. "A1")</returns>
    public string GetName()
    {
        int rank = 8 -  _rowIndex;
        char file = (char)(_colIndex + 65);
        return $"{file}{rank}";
    }

    public void SetOccupant(IPiece newOccupant)
    {
        Occupant = newOccupant;
        IsOccupied = newOccupant != null;
    }

    // public void Draw(SpriteBatch spriteBatch)
    // {
    //     if (_isHighlighted)
    //     {
    //         int borderWidth = BoardProperties.SquareHighlightBorderWidth;
    //         Rectangle borderRect = new Rectangle(PosX, PosY, Size, Size);
    //         Rectangle highlightRect = new Rectangle(PosX + borderWidth, PosY + borderWidth, Size - (2*borderWidth), Size - (2*borderWidth));
    //         
    //         spriteBatch.Draw(_highlightBorderTexture, borderRect, BoardProperties.SquareBorderColor);
    //         spriteBatch.Draw(_highlightTexture, highlightRect, BoardProperties.SquareHighlightColor);
    //     }
    //     else
    //     {
    //         Rectangle rect = new Rectangle(PosX, PosY, Size, Size);
    //         spriteBatch.Draw(_squareTexture, rect, _squareColor);
    //     }
    // }
}