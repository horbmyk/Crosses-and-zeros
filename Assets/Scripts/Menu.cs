using UnityEngine;
using UnityEngine.UI;

namespace CrossesAndZeros
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameBoardController GameBoardController;
        [SerializeField] private GameObject MenuGroup;
        [SerializeField] private Text Size;

        public void ChoosePlayCrosses()
        {
            GameBoardController.ChoosePlayCrosses();
            InitializationGameBoard();
            MenuGroup.SetActive(false);
        }

        public void ChoosePlayZeroes()
        {
            GameBoardController.ChoosePlayZeroes();
            InitializationGameBoard();
            MenuGroup.SetActive(false);
        }

        private void InitializationGameBoard()
        {
            GameBoardController.InitializationGameBoard();
        }

        public void SetSizeGameBoard(float value)
        {
            GameBoardController.SetSizeGameBoard(value);
            Size.text = value.ToString() + " X " + value.ToString();
        }
    }
}