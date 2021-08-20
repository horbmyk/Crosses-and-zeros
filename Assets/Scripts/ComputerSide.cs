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
            indexColumn = 0;//
            indexRow = 0;//
            List<FreeCell> poolFreeCell = new List<FreeCell>();

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
                Debug.Log("else");
            }

        }

        private class FreeCell
        {
            private int IndexRow;
            public int ValueIndexRow
            {
                get { return IndexRow; }
                set { IndexRow = value; }
            }
            private int IndexCol;
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