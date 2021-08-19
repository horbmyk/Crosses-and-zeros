using UnityEngine;

namespace CrossesAndZeros
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private GameBoardController GameBoardController;

        private void Start()
        {
            InitializationGameBoard(GameBoardController);
        }

        private void InitializationGameBoard(GameBoardController gameBoardController)
        {
            gameBoardController.InitializationGameBoard(3);
        }
    }
}