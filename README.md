# MonoGame Chess

## Current Game State

<img src="./resources/initial-checkerboard.png">

The base checkerboard has been implemented. The board is an object of the `Board` class, which is composed of 64 `Square` class objects represented by a 2-dimentional `Square` array.

## Design

### UML Class Diagram

```mermaid
classDiagram
    class IPiece <<interface>>
    IPiece : + CurrentSquare
    IPiece : + Update(GameTime gameTime)
    IPiece : + Draw(SpriteBatch spriteBatch)
    IPiece : + SetSquare(Square square)
    
    class Piece <<abstract>>
    Piece : # Texture2D _pieceTexture
    Piece : # Color _pieceColor
    Piece : # int _width
    Piece : # int _height
    Piece : # int _posx
    Piece : # int _posy
    Piece : # List[Square] GetPossibleSquares(Square square)
    
    class Board
    Board : - Square[,] _board
    Board : - int _width
    Board : - int _height
    Board : - int _posx
    Board : - int _posy
    Board : - int _squareSize
    Board : - int _boardHorizontalOffset
    Board : - int _boardVerticalOffset
    Board : + bool IsSquareOccupied(int rank, char file)
    Board : + void MoveTo(Square square, IPiece piece)
    Board : + void GetSquareFromRankAndFile(int rank, char file)
    Board : + void Draw(Spritebatch spriteBatch)
    
    class Square
    Square : - Texture2D _squareTexture
    Square : - Color _squareColor
    Square : - IPiece _occupier
    Square : - int _size
    Square : - int _posx
    Square : - int _posy
    Square : - int _rowIndex
    Square : - int _colIndex
    Square : + bool IsOccupied
    Square : + string GetName()
    Square : + Occupy(IPiece newOccupier)
    Square : + void Vactae()
    Square : + void Draw(SpriteBatch spriteBatch)

    class Pawn
    Pawn : - bool _firstMove
    Pawn : + override GetPossibleMoves()
    Pawn : bool CanPromote()
    Pawn : Queen Promote()
    
    class Rook
    Rook : + override GetPossibleMoves()
    Rook : bool CanTower(King king)
    Rook : bool Tower(King king)
    
    class Knight
    Knight : + override GetPossibleMoves()
    
    class Bishop
    Bishop : + override GetPossibleMoves()
    
    class King
    King : + override GetPossibleMoves()
    King : bool CanTower(King king)
    King : bool Tower(King king)
    
    class Queen
    Queen : + override GetPossibleMoves()


    IPiece <|.. Piece : Implements
    IPiece <.. Board : Uses
    Board *-- "64" Square : Composes
    Square o-- "0..1" IPiece : Sits On
    Piece <|-- Pawn
    Piece <|-- Rook
    Piece <|-- Bishop
    Piece <|-- Knight
    Piece <|-- King
    Piece <|-- Queen
```