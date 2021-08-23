using UnityEngine;
using UnityEngine.UI;

namespace CrossesAndZeros
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private GameBoardController GameBoardController;
        [SerializeField] private GameObject GameBoard;
        [SerializeField] private GameObject MenuGroup;
        [SerializeField] private GameObject RezultGroup;
        [SerializeField] private Text Size;

        public void ChoosePlayCrosses()
        {
            MenuGroup.SetActive(false);
            GameBoard.SetActive(true);
            InitializationGameBoard();
            GameBoardController.ChoosePlayCrosses();

        }

        public void ChoosePlayZeroes()
        {
            MenuGroup.SetActive(false);
            GameBoard.SetActive(true);
            InitializationGameBoard();
            GameBoardController.ChoosePlayZeroes();
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