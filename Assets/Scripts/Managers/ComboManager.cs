namespace GridPuzzle.Managers
{
    public class ComboManager
    {
        public int CurrentCombo { get; private set; } = 1;

        public int HighestCombo { get; private set; } = 1;

        public void RegisterMerge()
        {
            CurrentCombo++;

            if (CurrentCombo > HighestCombo)
                HighestCombo = CurrentCombo;
        }

        public void ResetCombo()
        {
            CurrentCombo = 1;
        }

        public void SetCombo(int value)
        {
            CurrentCombo = value;
        }

        public int ApplyMultiplier(int score)
        {
            return score * CurrentCombo;
        }
    }
}