using UnityEngine;
using GridPuzzle.Data;

namespace GridPuzzle.View
{
    public class GridRenderer : MonoBehaviour
    {
        [SerializeField]
        private TileView tilePrefab;

        [SerializeField]
        private Transform gridRoot;

        [SerializeField]
        private float cellSize = 120f;

        private TileView[,] tiles;

        public void Initialize(GridData grid)
        {
            tiles = new TileView[grid.Width, grid.Height];

            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    TileView tile =
                        Instantiate(tilePrefab, gridRoot);

                    tile.transform.localPosition =
                        new Vector3(
                            x * cellSize,
                            -y * cellSize,
                            0);

                    tiles[x, y] = tile;
                }
            }

            Render(grid);
        }

        public void Render(GridData grid)
        {
            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    tiles[x, y].SetValue(
                        grid.GetValue(x, y));
                }
            }
        }
    }
}