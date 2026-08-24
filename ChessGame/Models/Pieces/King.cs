using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models.Pieces;

sealed class King : Piece
{
    public class KingException(string message) : Exception(message);

    public King(Texture2D texture, Square square, PlayerPieceColor color) : base(texture, square, color)
    {
        Value = 0;
    }

    public override void Update(GameTime gameTime)
    {
        // TODO: Implement King.Update()
    }

    public override List<Square> GetPossibleMoves(IBoard board)
    {
        // TODO: Implement King.GetPossibleMove()
        return null;
    }
}