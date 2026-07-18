using TMPro;
using UnityEngine;

namespace GridPuzzle.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("HUD")]
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI moveText;

        [Header("Panels")]
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject gameOverPanel;

        private void Awake()
        {
            HidePanels();
        }

        public void UpdateHUD(int score, int moves)
        {
            scoreText.text = $"Score : {score}";
            moveText.text = $"Moves : {moves}";
        }

        public void ShowWin()
        {
            winPanel.SetActive(true);
        }

        public void ShowGameOver()
        {
            gameOverPanel.SetActive(true);
        }

        public void HidePanels()
        {
            winPanel.SetActive(false);
            gameOverPanel.SetActive(false);
        }
    }
}