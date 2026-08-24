using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models;

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