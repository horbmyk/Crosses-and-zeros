using UnityEngine;

namespace CrossesAndZeros
{
    public class Interface : MonoBehaviour
    {
        [SerializeField] private GameBoardController GameBoardController;

        public void ChoosePlayCrosses()
        {
            GameBoardController.ChoosePlayCrosses();
            InitializationGameBoard();
        }

        public void ChoosePlayZeroes()
        {
            GameBoardController.ChoosePlayZeroes();
            InitializationGameBoard();
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