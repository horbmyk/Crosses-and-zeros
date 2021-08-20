using UnityEngine;
using UnityEngine.UI;

namespace CrossesAndZeros
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Image SelectedImage;
        public delegate void PlayerChangeValueGameBoard(Cell cell);
        private PlayerChangeValueGameBoard PlayerChangeValueBoard;
        private int Value;
        public int SelectedValue
        {
            get { return Value; }
            set { Value = value; }
        }

        public void InitializationCell(PlayerChangeValueGameBoard playerchangeValueGameBoard)
        {
            PlayerChangeValueBoard = playerchangeValueGameBoard;
        }

        public void OnSelected()
        {
            PlayerChangeValueBoard?.Invoke(this);
        }

        public void ChangeImage(Sprite value)
        {
            SelectedImage.sprite = value;
        }
    }
}
