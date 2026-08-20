using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models.Pieces;

sealed class Bishop : Piece
{
    public class BishopException(string message) : Exception(message); 
    
    public Bishop(Texture2D texture, Square square, string pieceColor) :  base(texture, square, pieceColor)
    {
        Value = 3;
    }

    public override void Update(GameTime gameTime)
    {
        // TODO: Implement Bishop.Update()
        throw new System.NotImplementedException();
    }

    public override List<Square> GetPossibleMoves(IBoard board)
    {
        // TODO: Implement Bishop.GetPossibleMoves()
        throw new System.NotImplementedException();
    }
}