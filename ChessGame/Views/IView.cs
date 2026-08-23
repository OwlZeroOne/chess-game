using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGame.Views;

public interface IView
{
    void LoadContent(GraphicsDevice graphicsDevice, ContentManager content);
    
    void Update(GameTime gameTime, MouseState mouseState, KeyboardState keyboardState);
    
    void Draw(GameTime gameTime, SpriteBatch spriteBatch);
}