using UnityEngine;
using System;
using System.Collections;

namespace CrossesAndZeros
{
    public class GameBoardController : MonoBehaviour
    {
        [SerializeField] private GameBoardData GameBoardData;
        [SerializeField] private ComputerSide ComputerSide;
        [SerializeField] private RectTransform GameBoard;
        [SerializeField] private GameObject PrefabCell;
        [SerializeField] private Sprite Cross;
        [SerializeField] private Sprite Zero;
        const int itemsize = 100;
        const int DefaultSizeGameBoard = 3;
        const int ValueCrossInCell = 2;
        const int ValueZeroInCell = 1;
        private Cell[][] PoolCells;
        private int SizeGameBoard = DefaultSizeGameBoard;
        private bool SelectedCrosses;
        private bool PlayerAllowedMove = true;

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
                    cell.GetComponent<Cell>().InitializationCell(PlayersMove);
                    PoolCells[i][j] = cell.GetComponent<Cell>();
                }
            }
        }

        private void PlayersMove(Cell cell)
        {
            DetermineRowAndColumn(cell, out int indexColumn, out int indexRow);

            if (PoolCells[indexRow][indexColumn].SelectedValue != 0 || !PlayerAllowedMove)
                return;

            PlayerAllowedMove = false;

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

            if (CheckingCompletedLine(PoolCells))
            {
                Debug.Log("win");
                return;
            }

            StartCoroutine(ComputersMove());
        }

        public IEnumerator ComputersMove()
        {
            yield return new WaitForSeconds(1f);

            ComputerSide.Move(PoolCells, out int indexColumn, out int indexRow);

            if (SelectedCrosses)
            {
                PoolCells[indexRow][indexColumn].SelectedValue = ValueZeroInCell;
                PoolCells[indexRow][indexColumn].ChangeImage(Zero);
            }
            else
            {
                PoolCells[indexRow][indexColumn].SelectedValue = ValueCrossInCell;
                PoolCells[indexRow][indexColumn].ChangeImage(Cross);
            }

            PlayerAllowedMove = true;

            //
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
        private bool CheckingCompletedLine(Cell[][] poolCells)
        {
            bool rezult = false;

            int[,] dataPoolCells = DataTransfer(poolCells);

            rezult = CheckingRows(poolCells);

            if (rezult)
                goto RezultTrue;

            rezult = CheckingColumns(dataPoolCells);

            if (rezult)
                goto RezultTrue;

            RezultTrue:
            return rezult;
        }

        private bool CheckingColumns(int[,] dataPoolCells)
        {
            Debug.Log("CheckingColumns");
            bool rezult = false;
            int LengthRows = dataPoolCells.GetLength(0);
            int LengthColumns = dataPoolCells.GetLength(1);

            for (int i = 0; i < LengthColumns; i++)
            {
                for (int j = 0; j < LengthRows - 1; j++)
                {
                    int CurentValueCell = dataPoolCells[j, j];
                    int NextValueCell = dataPoolCells[j + 1, i];

                    if (CurentValueCell == 0 || CurentValueCell != NextValueCell)
                    {
                        rezult = false;
                        break;
                    }
                    else
                        rezult = true;
                }

                if (rezult)
                    goto RezultTrue;
            }
        RezultTrue:
            return rezult;
        }

        private bool CheckingRows(Cell[][] poolCells)
        {
            Debug.Log("CheckingRows");
            bool rezult = false;

            for (int i = 0; i < poolCells.Length; i++)
            {
                for (int j = 0; j < poolCells[i].Length - 1; j++)
                {
                    int CurentValueCell = poolCells[i][j].SelectedValue;
                    int NextValueCell = poolCells[i][j + 1].SelectedValue;

                    if (CurentValueCell == 0 || CurentValueCell != NextValueCell)
                    {
                        rezult = false;
                        break;
                    }
                    else
                        rezult = true;
                }

                if (rezult)
                    goto RezultTrue;
            }

        RezultTrue:
            return rezult;
        }

        private int[,] DataTransfer(Cell[][] poolCells)
        {
            int[,] dataPoolCells = new int[poolCells.Length, poolCells.Length];

            for (int i = 0; i < poolCells.Length; i++)
                for (int j = 0; j < poolCells[i].Length; j++)
                    dataPoolCells[i, j] = poolCells[i][j].SelectedValue;

            return dataPoolCells;
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
