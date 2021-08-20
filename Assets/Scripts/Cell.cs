using UnityEngine;
using UnityEngine.UI;

namespace CrossesAndZeros
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Image SelectedImage;
        public delegate void PlayersMove(Cell cell);
        private PlayersMove CurentPlayersMove;
        private int Value;
        public int SelectedValue
        {
            get { return Value; }
            set { Value = value; }
        }

        public void InitializationCell(PlayersMove playersMove)
        {
            CurentPlayersMove = playersMove;
        }

        public void OnSelected()
        {
            CurentPlayersMove?.Invoke(this);
        }

        public void ChangeImage(Sprite value)
        {
            SelectedImage.sprite = value;
        }
    }
}
