using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Models;

public class Board : IBoard
{
    public class BoardException(string message) : Exception(message);

    private Square[,] _board;
    private readonly int _squareSize = BoardProperties.SquareSize;
    private readonly int _posx = BoardProperties.PosX;
    private readonly int _posy = BoardProperties.PosY;
    
    public Board(GraphicsDevice graphics)
    {
        int colorIndex = 1;
        int currentx;
        int currenty;
        
        _board = new Square[8,8];
        
        for (int i = 0; i < 8; i++)
        {
            colorIndex = FlipColorIndex(colorIndex);
            currenty = i * _squareSize + _posy;
            
            for (int j = 0; j < 8; j++)
            {
                currentx = j * _squareSize + _posx;
                
                switch (colorIndex)
                {
                    case 0:
                        _board[i, j] = new Square(graphics, _squareSize, currentx, currenty, BoardProperties.CheckerColor1, i, j);
                        break;
                    case 1:
                        _board[i, j] = new Square(graphics, _squareSize, currentx, currenty, BoardProperties.CheckerColor2, i,j);
                        break;
                    default:
                        throw new BoardException($"Failed to parse square color index - Expecting 0 or 1, but got {colorIndex}");
                }
                // Alternates values between 0 and 1
                colorIndex = FlipColorIndex(colorIndex);
            }
        }
    }

    public bool IsSquareOccupied(char file, int rank)
    {
        Square square = GetSquareFromRankAndFile(rank, file);
        return square.IsOccupied;
    }

    public void PlacePiece(Square square, IPiece piece)
    {
        piece.CurrentSquare.Vacate();
        square.Occupy(piece);
        piece.MoveTo(square);
    }

    public Square[,] GetArray()
    {
        return _board;
    }
    
    public Square GetSquareFromRankAndFile(int rank, char file)
    {
        return _board[ParseRankIndex(rank), ParseFileIndex(file)];
    }

    public void Update(GameTime gameTime)
    {
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (Square square in _board) square.Draw(spriteBatch);
    }

    private int FlipColorIndex(int currentindex)
    {
        return (currentindex + 1) % 2;
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