using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ChessGame.Models.Pieces;

abstract class Piece : IPiece
{
    public class PieceException(string message) : Exception(message);
    
    protected PlayerPieceColor _playerPieceColor;
    protected Texture2D _texture;
    protected Square _currentSquare;
    protected List<Square> _possibleMoves;
    protected int _size;
    protected int _direction;
    // protected int _value;
    // protected string _pieceColor;
    
    protected Piece(Texture2D texture, Square square, PlayerPieceColor playerPieceColor)
    {
        // Console.WriteLine("Creating Piece");
        _texture = texture;
        _currentSquare = square;
        _playerPieceColor = playerPieceColor; 
        _size = _currentSquare.Size;
        _direction = playerPieceColor == PlayerPieceColor.White ? -1 : 1;
    }
    
    public virtual PlayerPieceColor PieceColor => _playerPieceColor;

    public virtual Square CurrentSquare => _currentSquare;

    public virtual List<Square> PossibleMoves => _possibleMoves;
    
    public virtual int Value { get; protected set; }
    
    public abstract void Update(GameTime gameTime);

    /// <summary>
    /// Scan for all possible moves from the Piece's current state and position.
    /// </summary>
    /// <param name="board">The board object.</param>
    /// <returns>List of all possible move squares.</returns>
    public abstract List<Square> GetPossibleMoves(IBoard board);
    
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, new Rectangle(_currentSquare.PosX, _currentSquare.PosY, _size, _size),  Color.White);
    }

    public virtual void MoveTo(Square square)
    {
        _currentSquare = square;
    }
}