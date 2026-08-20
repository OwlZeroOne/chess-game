using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models.Pieces;

sealed class Knight : Piece
{
    public class KnightException(string message) : Exception(message);

    public Knight(Texture2D texture, Square square, string pieceColor) : base(texture, square, pieceColor)
    {
        Value = 3;
    }

    public override void Update(GameTime gameTime)
    {
        // TODO: Implement Knight.Update()
        throw new NotImplementedException();
    }

    public override List<Square> GetPossibleMoves(IBoard board)
    {
        // TODO: Implement Knight.GetPossibleMoves()
        throw new NotImplementedException();
    }
}