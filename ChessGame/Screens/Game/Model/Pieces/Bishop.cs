using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Screens.Game.Model.Pieces;

sealed class Bishop : Piece
{
    public class BishopException(string message) : Exception(message); 
    
    public Bishop(Square square, PlayerPieceColor playerPieceColor) :  base(square, playerPieceColor)
    {
        Value = 3;
        MakeTextureId();
    }

    public override void Update(GameTime gameTime)
    {
        // TODO: Implement Bishop.Update()
        return;
    }

    public override List<Square> GetPossibleMoves(IBoard board)
    {
        // TODO: Implement Bishop.GetPossibleMoves()
        return null;
    }
}