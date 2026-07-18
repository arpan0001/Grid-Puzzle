using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GridPuzzle.View
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private Image background;
        [SerializeField] private TMP_Text valueText;

        public void SetValue(int value)
        {
            if (value == 0)
            {
                background.enabled = false;
                valueText.text = "";
                return;
            }

            background.enabled = true;
            valueText.text = value.ToString();

            background.color = GetColor(value);
        }

        private Color GetColor(int value)
        {
            switch (value)
            {
                case 2: return new Color(0.93f, 0.89f, 0.85f);
                case 4: return new Color(0.93f, 0.87f, 0.78f);
                case 8: return new Color(0.95f, 0.69f, 0.47f);
                case 16: return new Color(0.96f, 0.58f, 0.39f);
                case 32: return new Color(0.96f, 0.49f, 0.37f);
                case 64: return new Color(0.96f, 0.37f, 0.23f);
                default: return new Color(0.80f, 0.75f, 0.68f);
            }
        }
    }
}