using System;
using System.Collections.Generic;
using ChessGame.Models.Pieces;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models;

public class PlayerController
{
    public class ControllerException(string message) : Exception(message);

    public static readonly string Black = "black";
    public static readonly string White = "white";
    
    private IBoard _board;
    private string _playerColor;
    
    public int Points { get; private set; }
    public List<IPiece> Pieces { get; private set; }

    public PlayerController(IBoard board, string playerColor)
    {
        if (playerColor != Black &&  playerColor != White)
            throw new ControllerException($"Invalid player color string. Expected 'black' or 'white'; got {playerColor}. Correct color can be passed by passing 'PlayerController.Black' or 'PlayerController.White'.");
        
        _playerColor = playerColor;
        _board = board;
        Pieces = new List<IPiece>();
    }

    public void Initialize()
    {
        PieceFactory factory = new PieceFactory();
        switch (_playerColor)
        {
            case "black":
                factory.Black();
                break;
            case "white":
                factory.White();
                break;
            default:
                throw new ControllerException($"Unexpected invalid player color string. Expected 'black' or 'white'; got {_playerColor}.");
        }
        
        InitPawns(factory);
        InitRooks(factory);
        InitKnights(factory);
        InitBishops(factory);
        InitQueen(factory);
        InitKing(factory);
    }

    private void InitPawns(PieceFactory pf)
    {
        Square[,] board = _board.GetArray();
        
        for (int i = 0; i < 8; i++)
        {
            Square thisSquare = board[_playerColor == "white" ? 6 : 1, i];
            IPiece pawn = pf.Pawn(thisSquare);
            
            _board.PlacePiece(thisSquare, pawn);
            Pieces.Add(pawn);
        }
    }

    private void InitRooks(PieceFactory pf)
    {
        int rowIndex = _playerColor == "white" ? 7 : 0;
        Square[,] board = _board.GetArray();
        
        Square square1 = board[rowIndex, 0];
        Square square2 = board[rowIndex, 7];
        
        IPiece rook1 = pf.Rook(square1);
        IPiece rook2 = pf.Rook(square2);
        
        _board.PlacePiece(square1, rook1);
        _board.PlacePiece(square2, rook2);
        
        Pieces.Add(rook1);
        Pieces.Add(rook2);
    }
    
    private void InitKnights(PieceFactory pf)
    {
        int rowIndex = _playerColor == "white" ? 7 : 0;
        Square[,] board = _board.GetArray();
        
        Square square1 = board[rowIndex, 1];
        Square square2 = board[rowIndex, 6];
        
        IPiece knight1 = pf.Knight(square1);
        IPiece knight2 = pf.Knight(square2);
        
        _board.PlacePiece(square1, knight1);
        _board.PlacePiece(square2, knight2);
        
        Pieces.Add(knight1);
        Pieces.Add(knight2);
    }

    private void InitBishops(PieceFactory pf)
    {
        int rowIndex = _playerColor == "white" ? 7 : 0;
        Square[,] board = _board.GetArray();
        
        Square square1 = board[rowIndex, 2];
        Square square2 = board[rowIndex, 5];
        
        IPiece bishop1 = pf.Bishop(square1);
        IPiece bishop2 = pf.Bishop(square2);
        
        _board.PlacePiece(square1, bishop1);
        _board.PlacePiece(square2, bishop2);
        
        Pieces.Add(bishop1);
        Pieces.Add(bishop2);
    }

    private void InitKing(PieceFactory pf)
    {
        int rowIndex = _playerColor == "white" ? 7 : 0;
        Square[,] board = _board.GetArray();
        Square square = board[rowIndex, 4];
        IPiece king = pf.King(square);
        _board.PlacePiece(square, king);
        Pieces.Add(king);
    }

    private void InitQueen(PieceFactory pf)
    {
        int rowIndex = _playerColor == "white" ? 7 : 0;
        Square[,] board = _board.GetArray();
        Square square = board[rowIndex, 3];
        IPiece queen = pf.Queen(square);
        _board.PlacePiece(square, queen);
        Pieces.Add(queen);
    }
}
