using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GridPuzzle.View
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private Image background;

        public void SetValue(int value)
        {
            if (value == 0)
            {
                gameObject.SetActive(false);
                return;
            }

            gameObject.SetActive(true);

            valueText.text = value.ToString();

            // Colors will be improved later.
        }
    }
}