using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Screens.Game.Model.Pieces;

sealed class King : Piece
{
    public class KingException(string message) : Exception(message);

    public King(Square square, PlayerPieceColor color) : base(square, color)
    {
        Value = 0;
    }

    public override void Update(GameTime gameTime)
    {
        // TODO: Implement King.Update()
    }

    public override List<Square> GetPossibleMoves(Board board)
    {
        // TODO: Implement King.GetPossibleMove()
        List<Square> possibleMoves = new List<Square>();
        return possibleMoves;
    }
}