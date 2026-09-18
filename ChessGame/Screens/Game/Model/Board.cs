using System;
using System.Collections.Generic;
using ChessGame.Screens.Game.Model.Pieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Screens.Game.Model;

public class Board
{
    public class BoardException(string message) : Exception(message);

    private Square[,] _board;
    private readonly int _squareSize = BoardProperties.SquareSize;
    private readonly int _posx = BoardProperties.PosX;
    private readonly int _posy = BoardProperties.PosY;

    public Board()
    {
        _board = new Square[8,8];
        
        for (int i = 0; i < 8; i++)
        {
            int currentY = i * _squareSize + _posy;
            
            for (int j = 0; j < 8; j++)
            {
                int currentX = j * _squareSize + _posx;
                _board[i, j] = new Square(i, j, _squareSize, currentX, currentY);
            }
        }
    }

    public bool IsSquareOccupied(char file, int rank)
    {
        Square square = GetSquareFromRankAndFile(rank, file);
        return square.IsOccupied;
    }

    public void PlacePieceOnSquare(Square square, IPiece piece)
    {
        square.SetOccupant(piece);
    }

    public void RemovePieceFromSquare(Square square)
    {
        Console.WriteLine("Removing piece from square {0}", square.GetName());
        square.SetOccupant(null);
    }

    public Square[,] Array()
    {
        return _board;
    }
    
    public Square GetSquareFromRankAndFile(int rank, char file)
    {
        return _board[ParseRankIndex(rank), ParseFileIndex(file)];
    }

    public Square GetSquareFromPixelPosition(int x, int y)
    {
        foreach (Square sqr in _board)
        {
            if (x >= sqr.PosX && x <= sqr.PosX + sqr.Size && y >= sqr.PosY && y <= sqr.PosY + sqr.Size)
                return sqr;
        }
        return null;
    }

    private int FlipColorIndex(int currentIndex)
    {
        return (currentIndex + 1) % 2;
    }

    /// <summary>
    /// Converts square rank to a respective index in the Square array, beginning from the top of the board.
    /// </summary>
    /// <param name="rankRaw">The raw rank from the board in range [1..8].</param>s
    /// <returns>The converted rank index as an integer.</returns>
    /// <exception cref="BoardException">Thrown when the parsed index falls outside the inclusive integer range [0..7].</exception>
    private int ParseRankIndex(int rankRaw)
    {
        int rankIndex = 8 - rankRaw;
        if(rankIndex is >= 0 and <= 7) return rankIndex;
        
        throw new BoardException($"Failed to parse rank {rankRaw} -> {rankIndex} - Out of range");
    }

    /// <summary>
    /// Converts square file to a respective index in the Square array, beginning from the left side of the board.
    /// </summary>
    /// <param name="fileRaw">The raw file from the board in range ['A'..'H'].</param>
    /// <returns>The converted file index as an integer.</returns>
    /// <exception cref="BoardException">Thrown when the parsed index falls outside the inclusive integer range [0..7].</exception>
    private int ParseFileIndex(char fileRaw)
    {
        int fileIndex = fileRaw - 65;
        if(fileIndex is >= 0 and <= 7) return fileIndex;
        
        throw new BoardException($"Failed to parse file {fileRaw} -> {fileIndex} - Out of range");
    }
}