using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models;

public interface IPiece
{
    public Square CurrentSquare { get; }
    
    public void Update(GameTime gameTime);
    
    public void Draw(SpriteBatch spriteBatch);
    
    public void SetSquare(Square square);
}