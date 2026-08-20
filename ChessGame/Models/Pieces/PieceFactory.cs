using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models.Pieces;

public class PieceFactory
{
    public class PieceFactoryException(string message) : Exception(message);
    
    public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>()
    {
        { "w_pawn", null },
        { "w_rook", null },
        { "w_knight", null },
        { "w_bishop", null },
        { "w_queen", null },
        { "w_king", null },
        { "b_pawn", null },
        { "b_rook", null },
        { "b_knight", null },
        { "b_bishop", null },
        { "b_queen", null },
        { "b_king", null },
    };
    private int _direction;
    private int _squareSize;
    private int _sideIndex;
    private string _pieceColor;
    private char _texturePrefix;

    public PieceFactory()
    { }

    public void Black()
    {
        _direction = 1;
        _sideIndex = 0;
        _pieceColor = "black";
        _texturePrefix = 'b';
    }

    public void White()
    {
        _direction = -1;
        _sideIndex = 7;
        _pieceColor = "white";
        _texturePrefix = 'w';
    }

    public IPiece Pawn(Square square)
    {
        return new Pawn(Textures[$"{_texturePrefix}_pawn"], square, _pieceColor);
    }

    public IPiece Rook(Square square)
    {
        return new Rook(Textures[$"{_texturePrefix}_rook"], square, _pieceColor);
    }

    public IPiece Bishop(Square square)
    {
        return new Bishop(Textures[$"{_texturePrefix}_bishop"], square, _pieceColor);
    }

    public IPiece Knight(Square square)
    {
        return new Knight(Textures[$"{_texturePrefix}_knight"], square, _pieceColor);
    }

    public IPiece Queen(Square square)
    {
        return new Queen(Textures[$"{_texturePrefix}_queen"], square, _pieceColor);
    }

    public IPiece King(Square square)
    {
        return new King(Textures[$"{_texturePrefix}_king"], square, _pieceColor);
    }
}

