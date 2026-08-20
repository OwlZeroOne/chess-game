using System;
using System.Collections.Generic;
using ChessGame.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Views;

public class GameView : IView
{
    private IBoard _board;
    private PlayerController _playerControllerWhite;
    private PlayerController _playerControllerBlack;

    public GameView()
    { }

    public void LoadContent(GraphicsDevice graphicsDevice,  ContentManager content)
    {
        Console.WriteLine("GameView.LoadContent()");
        _board = new Board(graphicsDevice);
        
        _playerControllerWhite = new PlayerController(_board, PlayerController.White);
        _playerControllerBlack = new PlayerController(_board, PlayerController.Black);
        
        _playerControllerBlack.Initialize();
        _playerControllerWhite.Initialize();
    }

    public void Update(GameTime gameTime)
    {
        return;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        
        _board.Draw(spriteBatch);

        foreach (IPiece piece in _playerControllerBlack.Pieces)
            piece.Draw(spriteBatch);
        
        foreach (IPiece piece in _playerControllerWhite.Pieces)
            piece.Draw(spriteBatch);
        
        spriteBatch.End();
    }
}