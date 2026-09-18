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
    }

    public override List<Square> GetPossibleMoves(Board board)
    {
        // TODO: Implement Bishop.GetPossibleMoves()
        List<Square> possibleMoves = new List<Square>();
        return possibleMoves;
    }
}