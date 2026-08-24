using System;
using System.Collections.Generic;
using ChessGame.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGame.Views;

public class GameView : IView
{
    public class GameViewException(string message) : Exception(message);
    
    private IBoard _board;
    private readonly PlayerController[] _controllers = new PlayerController[2];
    private SpriteFont _font;

    private int _turn;
    private MouseState _lastMouseState;
    private KeyboardState _lastKeyboardState;

    public GameView()
    {
        _turn = 0;
        Console.WriteLine("Initializing GameView...");
    }

    public void LoadContent(GraphicsDevice graphicsDevice,  ContentManager content)
    {
        _font = content.Load<SpriteFont>("DefaultFont");
        
        Console.WriteLine("Loading Content...");
        _board = new Board(graphicsDevice);
        
        _controllers[0] = new PlayerController(_board, PlayerPieceColor.White);
        _controllers[1] = new PlayerController(_board, PlayerPieceColor.Black);

        Console.WriteLine($"Initializing Controllers ({_controllers.Length}):");
        foreach (PlayerController ctrl in _controllers)
        {
            ctrl.Initialize();
            Console.Write($" - PlayerController.{ctrl.PieceColor}: {ctrl.Pieces.Count} Pieces: ");
            Console.Write($"{ctrl.PawnCount} pawns; {ctrl.RookCount} rooks; {ctrl.KnightCount} knights; {ctrl.BishopCount} bishops; {ctrl.QueenCount} queens;  {ctrl.KingCount} kings\n");
        }
        
        Console.WriteLine($"Initialization complete. Current turn: {_turn} ({_controllers[_turn].PieceColor})");
    }

    public void Update(GameTime gameTime, MouseState mouseState, KeyboardState keyboardState)
    {
        if (mouseState.LeftButton == ButtonState.Pressed && mouseState != _lastMouseState)
        {
            Square square = _board.GetSquareFromPixelPosition(mouseState.X, mouseState.Y);
            _controllers[_turn].ClickSquare(square);
        }

        // (TEMPORARY) Force next turn.
        if (keyboardState.IsKeyDown(Keys.Enter) && keyboardState != _lastKeyboardState)
        {
            _board.DeselectSquare();
            Console.WriteLine("ENTER key pressed. Forcing next turn...");
            _turn = (_turn + 1) % 2;
            Console.WriteLine($"Current turn: {_turn} ({_controllers[_turn].PieceColor})...");
        }
        
        _lastMouseState = mouseState;
        _lastKeyboardState = keyboardState;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        
        _board.Draw(spriteBatch);

        foreach (PlayerController ctrl in _controllers)
            foreach (IPiece piece in ctrl.Pieces)
                piece.Draw(spriteBatch);
        
        spriteBatch.DrawString(_font, $"Current Turn-Taker: {_controllers[_turn].PieceColor}", new Vector2(670, 50), Color.White);
        
        spriteBatch.End();
    }
}