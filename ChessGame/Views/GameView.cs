using ChessGame.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Views;

public class GameView : IView
{
    private Board _board;
    
    public void LoadContent(GraphicsDevice graphicsDevice)
    {
        _board = new Board(graphicsDevice);
    }

    public void Update(GameTime gameTime)
    {
        return;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        
        _board.Draw(spriteBatch);
        
        spriteBatch.End();
    }
}