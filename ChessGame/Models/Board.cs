using System;
using System.Collections.Generic;

namespace ChessGame.Models;

public class Board
{
    private class BoardException(string message) : Exception(message);

    private Square[,] _board;

    public Board()
    {
        _board = new Square[8,8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                _board[i, j] = new Square();
            }
        }
    }
    
    public Square GetSquare(int rank, char file)
    {
        return _board[ParseRankIndex(rank), ParseFileIndex(file)];
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