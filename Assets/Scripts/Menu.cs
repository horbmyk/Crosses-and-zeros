using UnityEngine;

namespace CrossesAndZeros
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameBoardController GameBoardController;
        [SerializeField] private GameObject MenuGroup;

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
        }
    }
}