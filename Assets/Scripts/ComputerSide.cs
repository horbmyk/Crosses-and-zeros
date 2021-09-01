using System;
using System.Collections.Generic;

namespace CrossesAndZeros
{
    [Serializable]
    public class ComputerSide
    {
        public bool Move(Cell[][] poolCells, out int indexColumn, out int indexRow)
        {
            bool canMove = false;
            indexColumn = 0;
            indexRow = 0;
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

            if (poolFreeCell.Count > 1)
            {
                int randNum = UnityEngine.Random.Range(0, poolFreeCell.Count - 1);
                indexColumn = poolFreeCell[randNum].ValueIndexCol;
                indexRow = poolFreeCell[randNum].ValueIndexRow;
                canMove = true;
            }
            else
            {
                canMove = false;
            }
            return canMove;
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