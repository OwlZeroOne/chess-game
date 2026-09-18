using ChessGame.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ChessGame.Screens.Game.Model;

namespace ChessGame.Screens.Game;

public class Screen : IScreen
{
    private Controller _controller;
    private View _view;
    private ScreenModel _model;
    
    public Screen()
    {
        Initialize();
    }

    public void Initialize()
    {
        _model = new ScreenModel();
        _controller = new Controller(_model);
        _view = new View(_model);
    }

    public void LoadContent(GraphicsDevice graphics, ContentManager content)
    {
        _view.LoadContent(graphics, content);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        _view.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
        _controller.Update(gameTime);
    }

    public void UnloadContent()
    {
    }
}