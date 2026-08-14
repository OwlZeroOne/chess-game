using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models;

public class Square
{
    private class SquareException(string message) : Exception(message);
    
    enum SquareColor
    {
        White,
        Black,
    }

    private Texture2D _squareTexture;
    private Vector2 _position;
    private Color _color;
    private Piece _occupier;
    private int _size;
    
    public bool IsOccupied { get; private set; }

    public Square(GraphicsDevice graphics, int size, Color color, Vector2 position)
    {
        _squareTexture = MakeSquareTexture(graphics, color);
        _color = color;
        _size = size;
        _position = position;
        _occupier = null;
        IsOccupied = false;
    }

    public void Occupy(Piece newOccupier)
    {
        if (IsOccupied)
        {
            //TODO: Implement attacking logic
            throw new NotImplementedException("TODO: Implement attacking logic");
        }
        else
        {
            _occupier = newOccupier;
            _occupier.SetCurrentSquare(this);
            IsOccupied = true;
        }
    }

    public void Vacate()
    {
        if (!IsOccupied) throw new SquareException("Failed to vacate square - Square is already marked as unoccupied.");
        IsOccupied = false;
        _occupier = null;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_squareTexture, _position, _color);
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