using System;
using System.Collections.Generic;
using ChessGame.Models.Pieces;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models;

public class PlayerController
{
    public class ControllerException(string message) : Exception(message);
    
    private readonly IBoard _board;
    
    public int PawnCount { get; private set; }
    public int RookCount { get; private set; }
    public int KnightCount { get; private set; }
    public int BishopCount { get; private set; }
    public int QueenCount { get; private set; }
    public int KingCount { get; private set; }
    public int Score { get; private set; }
    public PlayerPieceColor PieceColor {get; private set; }
    public List<IPiece> Pieces { get; private set; }
    
    public int Points
    {
        get
        {
            int total = 0;
            foreach (IPiece piece in Pieces)
                total += piece.Value;
            
            return total;
        }
    }

    public PlayerController(IBoard board, PlayerPieceColor playerPieceColor)
    {
        if (playerPieceColor != PlayerPieceColor.White &&  playerPieceColor != PlayerPieceColor.Black)
            throw new ControllerException($"Invalid player color string. Expected PlayerColor.Black (1) or PlayerColor.White (2); got {playerPieceColor}.");
        
        PieceColor = playerPieceColor;
        _board = board;
        Pieces = new List<IPiece>();
    }

    public void Initialize()
    {
        PieceFactory factory = new PieceFactory(PieceColor);
        
        InitPawns(factory);
        // Console.WriteLine("Initializing player controller");
        InitRooks(factory);
        InitKnights(factory);
        InitBishops(factory);
        InitQueen(factory);
        InitKing(factory);
    }

    public void ClickSquare(Square square)
    {
        _board.OnSquareClicked(square, this);
    }

    private void InitPawns(PieceFactory pf)
    {
        Square[,] board = _board.GetArray();
        
        for (int i = 0; i < 8; i++)
        {
            Square thisSquare = board[PieceColor == PlayerPieceColor.White ? 6 : 1, i];
            IPiece pawn = pf.CreatePiece(PieceFactory.PieceTypes.Pawn, thisSquare);
            
            _board.PlacePiece(thisSquare, pawn);
            
            Pieces.Add(pawn);
            PawnCount += 1;
        }
    }

    private void InitRooks(PieceFactory pf)
    {
        int rowIndex = PieceColor == PlayerPieceColor.White ? 7 : 0;
        Square[,] board = _board.GetArray();
        
        Square square1 = board[rowIndex, 0];
        Square square2 = board[rowIndex, 7];
        
        IPiece rook1 = pf.CreatePiece(PieceFactory.PieceTypes.Rook, square1);
        IPiece rook2 = pf.CreatePiece(PieceFactory.PieceTypes.Rook, square2);
        
        _board.PlacePiece(square1, rook1);
        _board.PlacePiece(square2, rook2);
        
        Pieces.Add(rook1);
        Pieces.Add(rook2);
        
        RookCount += 2;
    }
    
    private void InitKnights(PieceFactory pf)
    {
        int rowIndex = PieceColor == PlayerPieceColor.White ? 7 : 0;
        Square[,] board = _board.GetArray();
        
        Square square1 = board[rowIndex, 1];
        Square square2 = board[rowIndex, 6];
        
        IPiece knight1 = pf.CreatePiece(PieceFactory.PieceTypes.Knight, square1);
        IPiece knight2 = pf.CreatePiece(PieceFactory.PieceTypes.Knight, square2);
        
        _board.PlacePiece(square1, knight1);
        _board.PlacePiece(square2, knight2);
        
        Pieces.Add(knight1);
        Pieces.Add(knight2);
        
        KnightCount += 2;
    }

    private void InitBishops(PieceFactory pf)
    {
        int rowIndex = PieceColor == PlayerPieceColor.White ? 7 : 0;
        Square[,] board = _board.GetArray();
        
        Square square1 = board[rowIndex, 2];
        Square square2 = board[rowIndex, 5];
        
        IPiece bishop1 = pf.CreatePiece(PieceFactory.PieceTypes.Bishop, square1);
        IPiece bishop2 = pf.CreatePiece(PieceFactory.PieceTypes.Bishop, square2);
        
        _board.PlacePiece(square1, bishop1);
        _board.PlacePiece(square2, bishop2);
        
        Pieces.Add(bishop1);
        Pieces.Add(bishop2);
        
        BishopCount += 2;
    }

    private void InitKing(PieceFactory pf)
    {
        int rowIndex = PieceColor == PlayerPieceColor.White ? 7 : 0;
        
        Square[,] board = _board.GetArray();
        Square square = board[rowIndex, 4];
        IPiece king = pf.CreatePiece(PieceFactory.PieceTypes.King, square);
        
        _board.PlacePiece(square, king);
        
        Pieces.Add(king);
        KingCount += 1;
    }

    private void InitQueen(PieceFactory pf)
    {
        int rowIndex = PieceColor == PlayerPieceColor.White ? 7 : 0;
        
        Square[,] board = _board.GetArray();
        Square square = board[rowIndex, 3];
        IPiece queen = pf.CreatePiece(PieceFactory.PieceTypes.Queen, square);
        
        _board.PlacePiece(square, queen);
        
        Pieces.Add(queen);
        QueenCount += 1;
    }
}
