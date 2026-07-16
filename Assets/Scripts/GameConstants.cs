using UnityEngine;

/// <summary>
/// Global constants used throughout the game.
/// Centralizing constants avoids magic numbers
/// and makes future balancing easier.
/// </summary>
public static class GameConstants
{
    /// <summary>
    /// Default grid width.
    /// </summary>
    public const int DefaultGridWidth = 4;

    /// <summary>
    /// Default grid height.
    /// </summary>
    public const int DefaultGridHeight = 4;

    /// <summary>
    /// Tile spacing in world units.
    /// </summary>
    public const float CellSpacing = 1.1f;

    /// <summary>
    /// Swipe threshold in pixels.
    /// </summary>
    public const float SwipeThreshold = 80f;
}