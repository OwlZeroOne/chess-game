using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models.Pieces;

sealed class Bishop : Piece
{
    public class BishopException(string message) : Exception(message); 
    
    public Bishop(Texture2D texture, Square square, PlayerPieceColor playerPieceColor) :  base(texture, square, playerPieceColor)
    {
        Value = 3;
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