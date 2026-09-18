using System.Collections.Generic;
using ChessGame.Screens.Game;
using ChessGame.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGame;

public class GameLoop : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private IScreen _currentScreen;
    
    public GameLoop()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 1200;
        _graphics.PreferredBackBufferHeight = 700;
        _graphics.ApplyChanges();
        
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _currentScreen = new Screen();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _currentScreen.LoadContent(GraphicsDevice, Content);
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _currentScreen.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        
        _currentScreen.Draw(gameTime, _spriteBatch);
        base.Draw(gameTime);
        
        _spriteBatch.End();
    }
}