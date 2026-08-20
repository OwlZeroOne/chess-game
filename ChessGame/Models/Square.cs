using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models;

public class Square
{
    public class SquareException(string message) : Exception(message);

    private Texture2D _squareTexture;
    private Color _squareColor;
    private int _rowIndex, _colIndex;
    
    /// <summary>
    /// Check the square's occupation state.
    /// </summary>
    public bool IsOccupied { get; private set; }

    public IPiece Occupant { get; private set; }

    public int RowIndex => _rowIndex;
    
    public int ColumnIndex => _colIndex;

    public int Size { get; private set; }
    
    public int PosX { get; private set; }
    
    public int PosY { get; private set; }

    public Square(GraphicsDevice graphics, int size, int posX, int posY, Color squareColor, int rowIndex, int colIndex)
    {
        _squareColor = squareColor;
        Size = size;
        PosX = posX;
        PosY = posY;
        _rowIndex = rowIndex;
        _colIndex = colIndex;
        Occupant = null;
        IsOccupied = false;
        
        _squareTexture = MakeSquareTexture(graphics, squareColor);
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

    /// <summary>
    /// Occupy this square with a given piece. If the square is occupied, attacking logic will be executed.
    /// </summary>
    /// <param name="newOccupier">The occupying piece.</param>
    /// <exception cref="NotImplementedException">Attacking logic is still to be implemented.</exception>
    public void Occupy(IPiece newOccupier)
    {
        if (IsOccupied)
        {
            //TODO: Implement attacking logic
            throw new NotImplementedException("TODO: Implement attacking logic");
        }
        else
        {
            Occupant = newOccupier;
            Occupant.MoveTo(this);
            IsOccupied = true;
        }
    }

    /// <summary>
    /// Free this square after a piece vacates it. If the square is already
    /// vacated, the process is omitted.
    /// </summary>
    public void Vacate()
    {
        if (IsOccupied)
        {
            IsOccupied = false;
            Occupant = null;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Console.WriteLine($"Square {GetName()} is{(Occupant != null ? "" : " not")} occupied");
        Rectangle rect = new Rectangle(PosX, PosY, Size, Size);
        spriteBatch.Draw(_squareTexture, rect, _squareColor);
    }

    private Texture2D MakeSquareTexture(GraphicsDevice graphics, Color color)
    {
        Texture2D texture =  new Texture2D(graphics, Size, Size);
        Color[] colorArray = new Color[Size * Size];
        
        for (int i = 0; i < colorArray.Length; i++)
            colorArray[i] = color;
        
        texture.SetData(colorArray);
        return texture;
    }
}