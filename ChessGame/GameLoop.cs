using System.Collections.Generic;
using ChessGame.Models.Pieces;
using ChessGame.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGame;

public class GameLoop : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private IView _currentView;
    
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
        // TODO: Add your initialization logic here
        _currentView = new GameView();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        PieceFactory.Textures["w_pawn"] =  Content.Load<Texture2D>("Pieces/w_Pawn");
        PieceFactory.Textures["w_rook"] =  Content.Load<Texture2D>("Pieces/w_Rook");
        PieceFactory.Textures["w_knight"] =  Content.Load<Texture2D>("Pieces/w_Knight");
        PieceFactory.Textures["w_bishop"] =  Content.Load<Texture2D>("Pieces/w_Bishop");
        PieceFactory.Textures["w_king"] =  Content.Load<Texture2D>("Pieces/w_King");
        PieceFactory.Textures["w_queen"] =  Content.Load<Texture2D>("Pieces/w_Queen");
        PieceFactory.Textures["b_pawn"] =  Content.Load<Texture2D>("Pieces/b_Pawn");
        PieceFactory.Textures["b_rook"] =  Content.Load<Texture2D>("Pieces/b_Rook");
        PieceFactory.Textures["b_knight"] =  Content.Load<Texture2D>("Pieces/b_Knight");
        PieceFactory.Textures["b_bishop"] =  Content.Load<Texture2D>("Pieces/b_Bishop");
        PieceFactory.Textures["b_king"] =  Content.Load<Texture2D>("Pieces/b_King");
        PieceFactory.Textures["b_queen"] =  Content.Load<Texture2D>("Pieces/b_Queen");

        // TODO: use this.Content to load your game content here
        _currentView.LoadContent(GraphicsDevice, Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        _currentView.Update(gameTime, Mouse.GetState(), Keyboard.GetState());
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _currentView.Draw(gameTime, _spriteBatch);
        
        base.Draw(gameTime);
    }
}