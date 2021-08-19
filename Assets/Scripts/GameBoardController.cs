using UnityEngine;
using System;

namespace CrossesAndZeros
{
    public class GameBoardController : MonoBehaviour
    {
        [SerializeField] private GameBoardData GameBoardData;
        [SerializeField] private RectTransform RectTransformGameBoard;
        [SerializeField] private GameObject PrefabCell;
        [SerializeField] private GameObject GameBoard;
        [SerializeField] private Sprite Cross;
        [SerializeField] private Sprite Zero;
        const int itemsize = 100;

        public void InitializationGameBoard(int value)
        {
            RectTransformGameBoard.sizeDelta = new Vector2(value * itemsize, value * itemsize);
            GameBoardData.Cells = new Cell[value, value];

            for (int i = 0; i < value; i++)
            {
                for (int j = 0; j < value; j++)
                {
                    GameObject cell = Instantiate(PrefabCell, GameBoard.transform);
                    cell.GetComponent<Cell>().InitializationCell(ChangeValueGameBoard);
                    GameBoardData.Cells[i, j] = cell.GetComponent<Cell>();
                }
            }
        }

        private void ChangeValueGameBoard(Cell cell)
        {


           

            Debug.Log("Click");
        }








    }
}
