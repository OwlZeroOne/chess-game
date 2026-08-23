using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models.Pieces;

public class PieceFactory
{
    public class PieceFactoryException(string message) : Exception(message);

    public enum PieceTypes
    {
        Pawn,
        Rook,
        Knight,
        Bishop,
        Queen,
        King
    }
    
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
    private PlayerPieceColor _playerPieceColor;
    private int _direction;
    private int _squareSize;
    private int _sideIndex;
    private char _texturePrefix;

    public PieceFactory(PlayerPieceColor playerPieceColor)
    {
        _playerPieceColor = playerPieceColor;
        switch (_playerPieceColor)
        {
            case PlayerPieceColor.White:
                White();
                break;
            case PlayerPieceColor.Black:
                Black();
                break;
        }
    }

    public void Black()
    {
        _direction = 1;
        _sideIndex = 0;
        _texturePrefix = 'b';
    }

    public void White()
    {
        _direction = -1;
        _sideIndex = 7;
        _texturePrefix = 'w';
    }

    public IPiece CreatePiece(PieceTypes type, Square square)
    {
        string key = $"{_texturePrefix}_{type.ToString().ToLower()}";
        try
        {
            return type switch
            {
                PieceTypes.Pawn => Pawn(key, square),
                PieceTypes.Rook => Rook(key, square),
                PieceTypes.Knight => Knight(key, square),
                PieceTypes.Bishop => Bishop(key, square),
                PieceTypes.Queen => Queen(key, square),
                PieceTypes.King => King(key, square),
                _ => throw new PieceFactoryException($"Unknown piece type: {type}")
            };
        }
        catch (KeyNotFoundException e)
        {
            throw new PieceFactoryException($"Attempted to create a {type.ToString().ToLower()} but could not find the key {key}");
        }
    }

    private IPiece Pawn(string key, Square square)
    {
        return new Pawn(Textures[key], square, _playerPieceColor);
    }

    private IPiece Rook(string key, Square square)
    {
        return new Rook(Textures[key], square, _playerPieceColor);
    }

    private IPiece Bishop(string key, Square square)
    {
        return new Bishop(Textures[key], square, _playerPieceColor);
    }

    private IPiece Knight(string key, Square square)
    {
        return new Knight(Textures[key], square, _playerPieceColor);
    }

    private IPiece Queen(string key, Square square)
    {
        return new Queen(Textures[key], square, _playerPieceColor);
    }

    private IPiece King(string key, Square square)
    {
        return new King(Textures[key], square, _playerPieceColor);
    }
}

