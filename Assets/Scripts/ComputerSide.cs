using System;
using System.Collections.Generic;
using UnityEngine;

namespace CrossesAndZeros
{
    [Serializable]
    public class ComputerSide
    {
        public void Move(Cell[][] poolCells, out int indexColumn, out int indexRow)
        {
            List<FreeCell> poolFreeCell = new List<FreeCell>();
            indexColumn = 0;
            indexRow = 0;

            for (int i = 0; i < poolCells.Length; i++)
            {
                for (int j = 0; j < poolCells[i].Length; j++)
                {

                    if (poolCells[i][j].SelectedValue != 0)
                        continue;

                    poolFreeCell.Add(new FreeCell(i, j));
                }
            }

            if (poolFreeCell.Count > 0)
            {
                int randNum = UnityEngine.Random.Range(0, poolFreeCell.Count - 1);
                indexColumn = poolFreeCell[randNum].ValueIndexCol;
                indexRow = poolFreeCell[randNum].ValueIndexRow;
            }
            else
            {
               // ResultController.EndGame("Draw");
            }
        }

        private class FreeCell
        {
            private int IndexRow;
            private int IndexCol;

            public int ValueIndexRow
            {
                get { return IndexRow; }
                set { IndexRow = value; }
            }

            public int ValueIndexCol
            {
                get { return IndexCol; }
                set { IndexCol = value; }
            }

            public FreeCell(int indexRow, int indexCol)
            {
                IndexRow = indexRow;
                IndexCol = indexCol;
            }
        }
    }
}