using UnityEngine;
using GridPuzzle.Data;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        BoardState board = new BoardState(4, 4);

        GridCell cell = board.Grid.GetCell(0, 0);

        TileData tile = new TileData(2);

        cell.PlaceTile(tile);

        Debug.Log(cell.Tile.Value);

        cell.Tile.DoubleValue();

        Debug.Log(cell.Tile.Value);

        cell.RemoveTile();

        Debug.Log(cell.IsEmpty);
    }
}