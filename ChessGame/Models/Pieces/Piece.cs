using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace ChessGame.Models;

abstract class Piece : IPiece
{
    protected Texture2D _pieceTexture;
    protected Color _pieceColor;
    protected int _width, _height;
    protected int _posx, _posy;

    protected Piece(Texture2D pieceTexture, int posx, int posy, int width, int height, Color pieceColor)
    {
        _pieceTexture = pieceTexture;
        _pieceColor = pieceColor;
        _width = width;
        _height = height;
        _posx = posx;
        _posy = posy;
    }
    
    public abstract void Update(GameTime gameTime);
    
    public virtual Square CurrentSquare { get; private set; }

    protected abstract List<Square> GetPossibleMoves(Square square);
    
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_pieceTexture, new Rectangle(_posx, _posy, _width, _height), _pieceColor);
    }

    public virtual void SetSquare(Square square)
    {
        CurrentSquare = square;
    }
    
}