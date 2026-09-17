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
        SelectSquare(square);
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

    private void SelectSquare(Square square)
    {
        DeselectSquare();

        // If the item clicked is not a square...
        if (square == null)
        {
            DeselectSquare();
        }
        // If the item is a square (implied by previous clause) and is occupied... 
        else if (square.IsOccupied)
        {
            IPiece occupant = square.Occupant;
            // If the occupant belongs to the current player...
            if (occupant.PieceColor == CurrentPlayer.PieceColor)
            {
                DeselectSquare();
                SelectedSquare = square;
                // TODO: Highlight possible moves
            }
            else // Otherwise...
            {
                // If the set of possible moves contains the square...
                if (PossibleMoves.Contains(square))
                {
                    // TODO: Move to square
                }
                DeselectSquare();
            }
        }
    }

    private void DeselectSquare()
    {
        SelectedSquare = null;
        ClearPossibleMoveSquares();
    }

    private void ClearPossibleMoveSquares()
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