using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace GridPuzzle.View
{
    public class TileView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI valueText;

        [SerializeField]
        private Image background;


        public void SetValue(int value)
        {
            if (value == 0)
            {
                gameObject.SetActive(false);
                return;
            }

            gameObject.SetActive(true);

            valueText.text = value.ToString();


            transform.localScale = Vector3.zero;

            transform.DOScale(
                Vector3.one,
                0.15f);
        }
    }
}