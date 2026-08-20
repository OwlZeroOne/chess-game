using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Views;

public interface IView
{
    void LoadContent(GraphicsDevice graphicsDevice, ContentManager content);
    
    void Update(GameTime gameTime);
    
    void Draw(GameTime gameTime, SpriteBatch spriteBatch);
}