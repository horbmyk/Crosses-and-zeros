using UnityEngine;
using UnityEngine.UI;

namespace CrossesAndZeros
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Image SelectedImage;
        public delegate void ChangeValueGameBoard(Cell cell);
        private ChangeValueGameBoard ChangeValueBoard;
        private int Value;
        public int SelectedValue
        {
            get { return Value; }
            set { Value = value; }
        }

        public void InitializationCell(ChangeValueGameBoard changeValueGameBoard)
        {
            ChangeValueBoard = changeValueGameBoard;
        }

        public void OnSelected()
        {
            ChangeValueBoard?.Invoke(this);
        }

        public void ChangeImage(Sprite value)
        {
            SelectedImage.sprite = value;
        }
    }
}
