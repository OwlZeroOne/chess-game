using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models.Pieces;

sealed class Queen : Piece
{
    public class QueenException(string message) : Exception(message);

    public Queen(Texture2D texture, Square square, PlayerPieceColor color) : base(texture, square, color)
    {
        Value = 8;
    }

    public override void Update(GameTime gameTime)
    {
        // TODO: Implement Queen.Update()
    }

    public override List<Square> GetPossibleMoves(IBoard board)
    {
        // TODO: Implement Queen.GetPossibleMoves()
        return null;
    }
}