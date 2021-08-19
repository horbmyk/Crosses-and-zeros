using UnityEngine;
using UnityEngine.UI;

namespace CrossesAndZeros
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Image Image;
        public delegate void ChangeValueGameBoard(Cell cell);//1 2
        private ChangeValueGameBoard ChangeValueBoard;

        private int Value;

        public int ValueCell
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
            Image.sprite = value;
        }
    }
}
