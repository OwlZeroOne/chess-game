using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Views;

public interface IView
{
    void LoadContent(GraphicsDevice graphicsDevice);
    
    void Update(GameTime gameTime);
    
    void Draw(GameTime gameTime, SpriteBatch spriteBatch);
}