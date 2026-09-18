using System;
using System.Collections.Generic;
using ChessGame.Screens.Game.Model.Pieces;

namespace ChessGame.Screens.Game.Model;

public class ScreenModel
{
    private PlayerController _player1;
    private PlayerController _player2;
    
    public PlayerController CurrentPlayer { get; private set; }
    public Square SelectedSquare {get; private set;}
    public List<Square> PossibleMoves {get; private set;}
    
    private Board _board;

    public ScreenModel()
    {
        InitBoard();
        InitPlayers();
        CurrentPlayer = _player1;
        PossibleMoves = [];
    }

    public Board GetBoard()
    {
        return _board;
    }

    public void SwitchPlayer()
    {
        CurrentPlayer = CurrentPlayer == _player1 ? _player2 : _player1;
        DeselectSquare();
    }

    public void OnClick(int x, int y)
    {
        Square square = _board.GetSquareFromPixelPosition(x, y);
        OnSquareClicked(square);
    }

    public void MoveSelectedPiece(Square dest)
    {
        // IPiece piece = SelectedSquare.Occupant;
        // piece.SetSquare(dest);
        // _board.PlacePiece(dest, piece);
        CurrentPlayer.MovePiece(SelectedSquare.Occupant, dest);
    }

    public List<IPiece> GetAllPieces()
    {
        List<IPiece> pieces = [];
        foreach (IPiece piece in _player1.Pieces)
            pieces.Add(piece);
        foreach (IPiece piece in _player2.Pieces)
            pieces.Add(piece);
        return pieces;
    }

    private void OnSquareClicked(Square square)
    {
        // If the item clicked is not a square...
        if (square == null)
        {
            DeselectSquare();
            return;
        }
        // Console.WriteLine($"Clicked on {square.GetName()}\nReference: {square.GetHashCode()}\nOccupied: {square.IsOccupied}\nIs Legal Move: {PossibleMoves.Contains(square)}");
        // If the item is a square (implied by previous clause) and is occupied... 
        if (square.IsOccupied)
        {
            IPiece occupant = square.Occupant;
            // If the occupant belongs to the current player...
            // TODO: Perhaps checking if the piece is in the list of the current player's pieces?
            if (occupant.PieceColor == CurrentPlayer.PieceColor)
            {
                DeselectSquare();
                SelectedSquare = square;
                CheckPossibleMoves();
            }
            else // Otherwise...
            {
                // If the set of possible moves contains the square...
                if (PossibleMoves.Contains(square))
                {
                    // Console.WriteLine("Move Piece on enemy-occupied square.");
                    MoveSelectedPiece(square);
                }
                DeselectSquare();
            }
        }
        else if (PossibleMoves.Contains(square))
        {
            // Console.WriteLine("Move Piece on empty square.");
            MoveSelectedPiece(square);
            DeselectSquare();
        }
        else DeselectSquare();
    }

    private void DeselectSquare()
    {
        SelectedSquare = null;
        ClearPossibleMovesList();
    }

    private void CheckPossibleMoves()
    {
        PossibleMoves = CurrentPlayer.GetPossibleMoves(SelectedSquare.Occupant);
        foreach (Square square in PossibleMoves)
            Console.WriteLine(square.GetHashCode());
    }

    private void ClearPossibleMovesList()
    {
        PossibleMoves.Clear();
    }

    private void InitBoard()
    {
        _board = new Board();
    }

    private void InitPlayers()
    {
        _player1 = new PlayerController(_board, PlayerPieceColor.White);
        _player2 = new PlayerController(_board, PlayerPieceColor.Black);

        foreach (PlayerController player in new[] { _player1, _player2 })
        {
            player.Initialize();
        }
    }
}