using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Screens.Game.Model.Pieces;

sealed class Queen : Piece
{
    public class QueenException(string message) : Exception(message);

    public Queen(Square square, PlayerPieceColor color) : base(square, color)
    {
        Value = 8;
    }

    public override void Update(GameTime gameTime)
    {
        // TODO: Implement Queen.Update()
    }

    public override List<Square> GetPossibleMoves(Board board)
    {
        // TODO: Implement Queen.GetPossibleMoves()
        List<Square> possibleMoves = new List<Square>();
        return possibleMoves;
    }
}