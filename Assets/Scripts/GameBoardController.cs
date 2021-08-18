using UnityEngine;

namespace CrossesAndZeros
{
    public class GameBoardController : MonoBehaviour
    {
        [SerializeField] private RectTransform RectTransformGameBoard;

        const int itemsize = 100;

        public void SetSizeGameBoard(int value)
        {
            RectTransformGameBoard.sizeDelta = new Vector2(value * itemsize, value * itemsize);
        }

    }
}
