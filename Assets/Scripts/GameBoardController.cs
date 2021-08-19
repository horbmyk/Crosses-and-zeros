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
        private Cell[][] PoolCells;
        const int itemsize = 100;

        public void InitializationGameBoard(int value)
        {
            RectTransformGameBoard.sizeDelta = new Vector2(value * itemsize, value * itemsize);
            PoolCells = GameBoardData.Cells;
            PoolCells = new Cell[value][];

            for (int i = 0; i < value; i++)
            {
                PoolCells[i] = new Cell[value];
                for (int j = 0; j < value; j++)
                {
                    GameObject cell = Instantiate(PrefabCell, GameBoard.transform);
                    cell.GetComponent<Cell>().InitializationCell(ChangeValueGameBoard);
                    PoolCells[i][j] = cell.GetComponent<Cell>();
                }
            }
        }

        private void ChangeValueGameBoard(Cell cell)
        {
            DetermineRowAndColumn(cell, out int indexColumn, out int indexRow);
            PoolCells[indexRow][indexColumn].ChangeImage(Cross);
           
        }

        private void DetermineRowAndColumn(Cell cell, out int indexcolumn, out int indexRow)
        {
            indexcolumn = 0;
            indexRow = 0;

            for (int i = 0; i < PoolCells.Length; i++)
            {
                if (Array.IndexOf(PoolCells[i], cell) == -1)
                    continue;

                indexcolumn = Array.IndexOf(PoolCells[i], cell);
                indexRow = i;
            }
        }
    }
}
