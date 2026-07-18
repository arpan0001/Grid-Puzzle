namespace GridPuzzle.Managers
{
    public class ComboManager
    {
        public int CurrentCombo { get; private set; } = 1;

        public int HighestCombo { get; private set; } = 1;


        public int CalculateScore(int mergeScore)
        {
            return mergeScore * CurrentCombo;
        }


        public void IncreaseCombo()
        {
            CurrentCombo++;

            if (CurrentCombo > HighestCombo)
            {
                HighestCombo = CurrentCombo;
            }
        }


        public void ResetCombo()
        {
            CurrentCombo = 1;
        }


        public void Reset()
        {
            CurrentCombo = 1;
            HighestCombo = 1;
        }
    }
}