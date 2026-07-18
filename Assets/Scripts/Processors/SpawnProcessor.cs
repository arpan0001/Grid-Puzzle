using System;
using System.Collections.Generic;

using GridPuzzle.Data;

namespace GridPuzzle.Processors
{
    /// <summary>
    /// Responsible only for spawning new tiles.
    /// Reuses memory to avoid allocations.
    /// </summary>
    public class SpawnProcessor
    {
        private readonly Random _random;

        private readonly List<GridPosition> _emptyCells;


        public SpawnProcessor()
        {
            _random = new Random();

            _emptyCells = new List<GridPosition>(16);
        }


        public bool Spawn(GridData grid)
        {
            CollectEmptyCells(grid);


            if (_emptyCells.Count == 0)
                return false;


            GridPosition position =
                _emptyCells[_random.Next(_emptyCells.Count)];


            int value = GenerateTileValue();


            grid.SetValue(
                position.X,
                position.Y,
                value);


            return true;
        }


        private void CollectEmptyCells(GridData grid)
        {
            _emptyCells.Clear();


            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    if (grid.IsCellEmpty(x, y))
                    {
                        _emptyCells.Add(
                            new GridPosition(x, y));
                    }
                }
            }
        }


        private int GenerateTileValue()
        {
            return _random.NextDouble() < 0.9
                ? 2
                : 4;
        }
    }
}