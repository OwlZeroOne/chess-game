using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models;

public interface IPiece
{
    /// <summary>
    /// Returns the Square object on which the piece is currently sitting on.
    /// </summary>
    public Square CurrentSquare { get; }
    
    /// <summary>
    /// Returns the list of legal moves property consisting of Square objects. Varies between different Piece types.
    /// </summary>
    public List<Square> PossibleMoves { get; }
    
    /// <summary>
    /// Returns the worth value property that corresponds to the piece. Varies between different Piece types.
    /// </summary>
    public int Value { get; }
    
    /// <summary>
    /// Returns the piece color property.
    /// </summary>
    public string PieceColor { get; }
    
    /// <summary>
    /// Update Piece logic. To be called from the client's Update() method.
    /// </summary>
    /// <param name="gameTime"></param>
    public void Update(GameTime gameTime);
    
    /// <summary>
    /// Draw the Piece. To be called from the client's Draw() method.
    /// </summary>
    public void Draw(SpriteBatch spriteBatch);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="square"></param>
    public void MoveTo(Square square);
}