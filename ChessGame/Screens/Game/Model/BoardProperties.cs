using Microsoft.Xna.Framework;

namespace ChessGame.Screens.Game.Model;

public static class BoardProperties
{
    /// <summary>
    /// The size of each square on the board.
    /// </summary>
    public static readonly int SquareSize = 75;
    
    /// <summary>
    /// The horizontal position of the board's anchorpoint.
    /// </summary>
    public static readonly int PosX = 50;
    
    /// <summary>
    /// The vertical position of the board's anchorpoint.
    /// </summary>
    public static readonly int PosY = 50;
    
    public static readonly int SquareHighlightBorderWidth = 2;
    
    /// <summary>
    /// Primary color for the checkerboard.
    /// </summary>
    public static readonly Color SquareColor1 = new Color(45, 139, 153);
    
    /// <summary>
    /// Secondary color for the checkerboard.
    /// </summary>
    public static readonly Color SquareColor2 = new Color(237, 215, 197);
    
    public static readonly Color SquareHighlightColor = Color.Goldenrod;
    
    
    public static readonly Color SquareBorderColor = Color.Black;
}