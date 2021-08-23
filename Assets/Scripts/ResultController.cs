using UnityEngine;

namespace CrossesAndZeros
{
    public class ResultController : MonoBehaviour
    {
        [SerializeField] private GameObject ResultGroup;
        [SerializeField] private GameObject MenuGroup;
        [SerializeField] private GameObject GameBoard;
        [SerializeField] private GameObject PlayerWin;
        [SerializeField] private GameObject ComputerWin;
        [SerializeField] private GameObject Draw;
        [SerializeField] private GameObject RestartObj;

        public void EndGame(string value)
        {
            switch (value)
            {
                case "Player":
                    ResultGroup.SetActive(true);
                    GameBoard.SetActive(false);
                    PlayerWin.SetActive(true);
                    ComputerWin.SetActive(false);
                    Draw.SetActive(false);
                    RestartObj.SetActive(true);
                    break;

                case "Computer":
                    ResultGroup.SetActive(true);
                    GameBoard.SetActive(false);
                    RestartObj.SetActive(true);
                    ComputerWin.SetActive(true);
                    PlayerWin.SetActive(false);
                    Draw.SetActive(false);
                    break;

                case "Draw":
                    ResultGroup.SetActive(true);
                    GameBoard.SetActive(false);
                    RestartObj.SetActive(true);
                    Draw.SetActive(true);
                    PlayerWin.SetActive(false);
                    ComputerWin.SetActive(false);
                    break;
            }
        }

        public void Restart()
        {
            ResultGroup.SetActive(false);
            MenuGroup.SetActive(true);
        }
    }
}
