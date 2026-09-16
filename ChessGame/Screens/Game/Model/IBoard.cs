using System.Collections.Generic;
using ChessGame.Screens.Game.Model.Pieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Screens.Game.Model;

public interface IBoard
{
    bool IsSquareOccupied(char file, int rank);
    
    void PlacePiece(Square square, IPiece piece);
    
    Square[,] GetArray();
    
    void Update(GameTime gameTime);
    
    void Draw(SpriteBatch spriteBatch);
    
    void OnSquareClicked(Square newSquare, PlayerController controller);
    
    void DeselectSquare();

    Square GetSquareFromPixelPosition(int x, int y);
}