using UnityEngine;
using System;

namespace CrossesAndZeros
{
    public class GameBoardController : MonoBehaviour
    {
        [SerializeField] private GameBoardData GameBoardData;
        [SerializeField] private RectTransform GameBoard;
        [SerializeField] private GameObject PrefabCell;
        [SerializeField] private Sprite Cross;
        [SerializeField] private Sprite Zero;
        private Cell[][] PoolCells;
        const int itemsize = 100;

        public void InitializationGameBoard(int value)
        {
            GameBoard.sizeDelta = new Vector2(value * itemsize, value * itemsize);
            PoolCells = GameBoardData.Cells;
            PoolCells = new Cell[value][];

            for (int i = 0; i < value; i++)
            {
                PoolCells[i] = new Cell[value];
                for (int j = 0; j < value; j++)
                {
                    GameObject cell = Instantiate(PrefabCell, GameBoard);
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

        private void DetermineRowAndColumn(Cell cell, out int indexColumn, out int indexRow)
        {
            indexColumn = 0;
            indexRow = 0;

            for (int i = 0; i < PoolCells.Length; i++)
            {
                if (Array.IndexOf(PoolCells[i], cell) == -1)
                    continue;

                indexColumn = Array.IndexOf(PoolCells[i], cell);
                indexRow = i;
            }
        }
    }
}
