using Microsoft.Xna.Framework.Input;

using ChessGame.Screens.Game.Model;
using Microsoft.Xna.Framework;

namespace ChessGame.Screens.Game;

public class Controller
{
    private KeyboardState _lastKeyboardState;
    private MouseState _lastMouseState;

    private ScreenModel _model;
    
    public Controller(ScreenModel model)
    {
        _model = model;
    }

    public void Update(GameTime gameTime)
    {
        if (EnterPressed()) OnEnterPressed();
        if (LeftMouseButtonPressed()) OnLeftMouseButtonPressed();
    }

    private void OnEnterPressed()
    {
        _model.SwitchPlayer();
    }

    private void OnLeftMouseButtonPressed()
    {
        int mousePosX = _lastMouseState.Position.X;
        int mousePosY = _lastMouseState.Position.Y;
        _model.OnClick(mousePosX, mousePosY);
    }

    private bool EnterPressed()
    {
        KeyboardState kbs = Keyboard.GetState();
        bool enterPressed = kbs.IsKeyDown(Keys.Enter) && kbs != _lastKeyboardState;
        _lastKeyboardState = kbs;
        return enterPressed;
    }

    private bool LeftMouseButtonPressed()
    {
        MouseState ms = Mouse.GetState();
        bool leftMouseButtonPressed = ms.LeftButton == ButtonState.Pressed && ms != _lastMouseState;
        _lastMouseState = ms;
        return leftMouseButtonPressed;
    }
}