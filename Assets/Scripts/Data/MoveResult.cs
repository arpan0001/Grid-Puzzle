namespace GridPuzzle.Data
{
    public struct MoveResult
    {
        public bool BoardChanged;
        public bool TileMerged;
        public int ScoreGained;
        public bool HasWon;
    }
}