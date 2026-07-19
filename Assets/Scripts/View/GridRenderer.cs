using UnityEngine;
using GridPuzzle.Data;

namespace GridPuzzle.View
{
    /// Responsible for drawing the logical game board.
    /// It reads data from GridData and updates the tile visuals.
    /// This class does not contain any gameplay logic.
    public class GridRenderer : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TileView tilePrefab;
        [SerializeField] private Transform gridRoot;

        [Header("Layout")]
        [SerializeField] private float cellSize = 120f;
        [SerializeField] private float spacing = 10f;

        private TileView[,] tileViews;

        /// Creates the visual grid and the initial board state.
       public void Initialize(GridData grid)
        {
            CreateTiles(grid);
            Render(grid);
        }

    
        // Creates the visual tile objects and positions them in a grid layout.
        
        private void CreateTiles(GridData grid)
        {
            tileViews = new TileView[grid.Width, grid.Height];

            float startX = -((grid.Width - 1) * (cellSize + spacing)) * 0.5f;

            float startY = ((grid.Height - 1) * (cellSize + spacing)) * 0.5f;

            // Create one tile for every cell.
            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    // Create a new tile.
                    TileView tile = Instantiate(tilePrefab, gridRoot);

                    RectTransform rect = tile.GetComponent<RectTransform>();

                    // Position the tile inside the grid.
                    rect.anchoredPosition =
                        new Vector2(startX + x * (cellSize + spacing), startY - y * (cellSize + spacing));

                    // Set the tile size.
                    rect.sizeDelta = new Vector2(cellSize, cellSize);

                    // Save the reference for later updates.
                    tileViews[x, y] = tile;
                }
            }
        }


        
        /// Updates every tile to match
        public void Render(GridData grid)
        {
            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    tileViews[x, y].SetValue(grid.GetValue(x, y));
                }
            }
        }
    }
}