using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Screens.Game.Model.Pieces;

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
    
    // public static Dictionary<string, Texture2D> Textures = new()
    // {
    //     { "w_pawn", null },
    //     { "w_rook", null },
    //     { "w_knight", null },
    //     { "w_bishop", null },
    //     { "w_queen", null },
    //     { "w_king", null },
    //     { "b_pawn", null },
    //     { "b_rook", null },
    //     { "b_knight", null },
    //     { "b_bishop", null },
    //     { "b_queen", null },
    //     { "b_king", null },
    // };
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
                PieceTypes.Pawn => Pawn(square),
                PieceTypes.Rook => Rook(square),
                PieceTypes.Knight => Knight(square),
                PieceTypes.Bishop => Bishop(square),
                PieceTypes.Queen => Queen(square),
                PieceTypes.King => King(square),
                _ => throw new PieceFactoryException($"Unknown piece type: {type}")
            };
        }
        catch (KeyNotFoundException e)
        {
            throw new PieceFactoryException($"Attempted to create a {type.ToString().ToLower()} but could not find the key {key}");
        }
    }

    private IPiece Pawn(Square square)
    {
        return new Pawn(square, _playerPieceColor);
    }

    private IPiece Rook(Square square)
    {
        return new Rook(square, _playerPieceColor);
    }

    private IPiece Bishop(Square square)
    {
        return new Bishop(square, _playerPieceColor);
    }

    private IPiece Knight(Square square)
    {
        return new Knight(square, _playerPieceColor);
    }

    private IPiece Queen(Square square)
    {
        return new Queen(square, _playerPieceColor);
    }

    private IPiece King(Square square)
    {
        return new King(square, _playerPieceColor);
    }
}

