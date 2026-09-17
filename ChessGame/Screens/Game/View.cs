using System;
using System.Collections.Generic;
using ChessGame.Screens.Game.Model;
using ChessGame.Screens.Game.Model.Pieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Screens.Game;

public class View
{
    public class ViewException(string message) : Exception(message);

    private Dictionary<string, Texture2D> _textures;
    
    private GraphicsDevice _graphics;
    private ScreenModel _model;
    private SpriteFont _font;

    private Texture2D[] _squareTextures;
    private Texture2D _highlightedSquareTexture;
    private Texture2D _highlightedSquareBorderTexture;
    
    private int _squareSize;
    private int _highlightBorderWidth;

    private Color[] _squareColors;
    private Color _squareHighlightColor;
    private Color _squareBorderColor;
    
    public View(ScreenModel model)
    {
        _model = model;
        
        _squareSize = BoardProperties.SquareSize;
        _squareColors =
        [
            BoardProperties.SquareColor1,
            BoardProperties.SquareColor2
        ];
        _highlightBorderWidth = BoardProperties.SquareHighlightBorderWidth;
        _squareHighlightColor = BoardProperties.SquareHighlightColor;
        _squareBorderColor = BoardProperties.SquareBorderColor;
    }

    public void LoadContent(GraphicsDevice graphics, ContentManager content)
    {
        LoadFonts(content);
        LoadPieceTextures(content);
        LoadSquareTextures(graphics);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        DrawBoard(spriteBatch);
        DrawPieces(spriteBatch);
    }

    private void DrawPieces(SpriteBatch spriteBatch)
    {
        foreach (var piece in _model.GetAllPieces())
        {
            Console.WriteLine(piece.TextureId == null ? "NONE" : piece.TextureId);
            piece.Draw(spriteBatch, _textures[piece.TextureId]);
        }
    }

    private void DrawBoard(SpriteBatch spriteBatch)
    {
        if (_model.PossibleMoves == null)
            throw new ViewException("Null reference encountered for the model's list of possible moves...");
        
        int colorIndex = 0;
        int columnIndex = 0;
        
        foreach (Square square in _model.GetBoard().Array())
        {
            if (square == null)
                throw new ViewException("Encountered a null square while attempting to draw the board...");
            
            if (square == _model.SelectedSquare || _model.PossibleMoves.Contains(square))
            {
                Rectangle borderRect = new Rectangle(square.PosX, square.PosY, square.Size, square.Size);
                Rectangle highlightRect = new Rectangle(
                    square.PosX + _highlightBorderWidth,
                    square.PosY + _highlightBorderWidth,
                    square.Size - 2 * _highlightBorderWidth,
                    square.Size - 2 * _highlightBorderWidth);
                
                spriteBatch.Draw(_highlightedSquareBorderTexture, borderRect, _squareBorderColor);
                spriteBatch.Draw(_highlightedSquareTexture, highlightRect, _squareHighlightColor);
            }
            else
            {
                Rectangle rect = new Rectangle(square.PosX, square.PosY, square.Size, square.Size);
                spriteBatch.Draw(_squareTextures[colorIndex], rect, _squareColors[colorIndex]);
            }
            colorIndex = FlipZeroOne(colorIndex);
            
            columnIndex++;
            if (columnIndex >= 8)
            {
                columnIndex = 0;
                colorIndex = FlipZeroOne(colorIndex);
            }
        }
    }

    private int FlipZeroOne(int value)
    {
        return (value + 1) % 2;
    }

    private void LoadSquareTextures(GraphicsDevice graphics)
    {
        _squareTextures =
        [
            RectangularTexture(graphics, _squareColors[0], _squareSize, _squareSize),
            RectangularTexture(graphics, _squareColors[1], _squareSize, _squareSize)
        ];
        _highlightedSquareBorderTexture = RectangularTexture(graphics, _squareBorderColor, _squareSize, _squareSize);
        _highlightedSquareTexture = RectangularTexture(
            graphics, 
            _squareHighlightColor, 
            _squareSize - 2 * _highlightBorderWidth, 
            _squareSize - 2 * _highlightBorderWidth
            );
    }

    private Texture2D RectangularTexture(GraphicsDevice graphics, Color color, int width, int height)
    {
        Texture2D texture = new Texture2D(graphics, width, height);
        Color[] colorArray = new Color[width * height];
        
        for (int i = 0; i < colorArray.Length; i++)
            colorArray[i] = color;
        
        texture.SetData(colorArray);
        return texture;
    }

    private void LoadFonts(ContentManager content)
    {
        _font = content.Load<SpriteFont>("DefaultFont");
    }

    private void LoadPieceTextures(ContentManager content)
    {
        _textures = new()
        {
            { "w_pawn", content.Load<Texture2D>("Pieces/w_Pawn") },
            { "w_rook", content.Load<Texture2D>("Pieces/w_Rook") },
            { "w_knight", content.Load<Texture2D>("Pieces/w_Knight") },
            { "w_bishop", content.Load<Texture2D>("Pieces/w_Bishop") },
            { "w_king", content.Load<Texture2D>("Pieces/w_King") },
            { "w_queen", content.Load<Texture2D>("Pieces/w_Queen") },
            { "b_pawn", content.Load<Texture2D>("Pieces/b_Pawn") },
            { "b_rook", content.Load<Texture2D>("Pieces/b_Rook") },
            { "b_knight", content.Load<Texture2D>("Pieces/b_Knight") },
            { "b_bishop", content.Load<Texture2D>("Pieces/b_Bishop") },
            { "b_king", content.Load<Texture2D>("Pieces/b_King") },
            { "b_queen", content.Load<Texture2D>("Pieces/b_Queen") }
        };
    }
}