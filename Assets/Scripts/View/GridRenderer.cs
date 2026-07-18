using UnityEngine;

using GridPuzzle.Data;

namespace GridPuzzle.View
{
    public class GridRenderer : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TileView tilePrefab;
        [SerializeField] private Transform gridRoot;

        [Header("Layout")]
        [SerializeField] private float cellSize = 120f;
        [SerializeField] private float spacing = 10f;

        private TileView[,] tileViews;

        public void Initialize(GridData grid)
        {
            CreateTiles(grid);
            Render(grid);
        }

        private void CreateTiles(GridData grid)
        {
            tileViews = new TileView[grid.Width, grid.Height];

            float startX =
                -((grid.Width - 1) * (cellSize + spacing)) * 0.5f;

            float startY =
                ((grid.Height - 1) * (cellSize + spacing)) * 0.5f;

            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    TileView tile =
                        Instantiate(tilePrefab, gridRoot);

                    RectTransform rect =
                        tile.GetComponent<RectTransform>();

                    rect.anchoredPosition =
                        new Vector2(
                            startX + x * (cellSize + spacing),
                            startY - y * (cellSize + spacing));

                    rect.sizeDelta =
                        new Vector2(cellSize, cellSize);

                    tileViews[x, y] = tile;
                }
            }
        }

        public void Render(GridData grid)
        {
            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    tileViews[x, y]
                        .SetValue(grid.GetValue(x, y));
                }
            }
        }
    }
}