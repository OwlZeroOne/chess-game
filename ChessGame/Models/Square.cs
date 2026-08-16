using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models;

public class Square
{
    public class SquareException(string message) : Exception(message);

    private Texture2D _squareTexture;
    private Color _squareColor;
    private IPiece _occupier;
    private int _size, _posx, _posy;
    private int _rowIndex, _colIndex;
    
    /// <summary>
    /// Check the square's occupation state.
    /// </summary>
    public bool IsOccupied { get; private set; }

    public Square(GraphicsDevice graphics, int size, int posx, int posy, Color squareColor, int rowIndex, int colIndex)
    {
        _squareColor = squareColor;
        _size = size;
        _posx = posx;
        _posy = posy;
        _rowIndex = rowIndex;
        _colIndex = colIndex;
        _occupier = null;
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
            _occupier = newOccupier;
            _occupier.SetSquare(this);
            IsOccupied = true;
        }
    }

    /// <summary>
    /// Vacate this square after moving out of it.
    /// </summary>
    /// <exception cref="SquareException">Thrown if the square is not marked as occupied.</exception>
    public void Vacate()
    {
        if (!IsOccupied) throw new SquareException("Failed to vacate square - Square is already marked as unoccupied.");
        IsOccupied = false;
        _occupier = null;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Rectangle rect = new Rectangle(_posx, _posy, _size, _size);
        spriteBatch.Draw(_squareTexture, rect, _squareColor);
        if (IsOccupied)
        {
            if (_occupier == null) throw new SquareException("Failed to draw square occupier - Occupier is null, but square is marked as occupied.");
            _occupier.Draw(spriteBatch);
        }
    }

    private Texture2D MakeSquareTexture(GraphicsDevice graphics, Color color)
    {
        Texture2D texture =  new Texture2D(graphics, _size, _size);
        Color[] colorArray = new Color[_size * _size];
        
        for (int i = 0; i < colorArray.Length; i++)
            colorArray[i] = color;
        
        texture.SetData(colorArray);
        return texture;
    }
}