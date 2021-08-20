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
        const int itemsize = 100;
        const int DefaultSizeGameBoard = 3;
        const int ValueCrossInCell = 2;
        const int ValueZeroInCell = 1;
        private int SizeGameBoard = DefaultSizeGameBoard;
        private Cell[][] PoolCells;
        private bool SelectedCrosses;

        public void InitializationGameBoard()
        {
            GameBoard.sizeDelta = new Vector2(SizeGameBoard * itemsize, SizeGameBoard * itemsize);
            PoolCells = GameBoardData.Cells;
            PoolCells = new Cell[SizeGameBoard][];

            for (int i = 0; i < SizeGameBoard; i++)
            {
                PoolCells[i] = new Cell[SizeGameBoard];

                for (int j = 0; j < SizeGameBoard; j++)
                {
                    GameObject cell = Instantiate(PrefabCell, GameBoard);
                    cell.GetComponent<Cell>().InitializationCell(PlayerChangeValueGameBoard);
                    PoolCells[i][j] = cell.GetComponent<Cell>();
                }
            }
        }

        private void PlayerChangeValueGameBoard(Cell cell)
        {
            DetermineRowAndColumn(cell, out int indexColumn, out int indexRow);

            if (SelectedCrosses)
            {
                PoolCells[indexRow][indexColumn].SelectedValue = ValueCrossInCell;
                PoolCells[indexRow][indexColumn].ChangeImage(Cross);
            }
            else
            {
                PoolCells[indexRow][indexColumn].SelectedValue = ValueZeroInCell;
                PoolCells[indexRow][indexColumn].ChangeImage(Zero);
            }
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

        public void SetSizeGameBoard(float value)
        {
            SizeGameBoard = (int)value;
        }

        public void ChoosePlayCrosses()
        {
            SelectedCrosses = true;
        }

        public void ChoosePlayZeroes()
        {
            SelectedCrosses = false;
        }
    }
}
