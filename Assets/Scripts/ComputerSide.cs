using System;
using UnityEngine;

namespace CrossesAndZeros
{
    [Serializable]
    public class ComputerSide
    {
        public void Move(Cell[][] poolCells, out int indexColumn, out int indexRow)
        {
            indexColumn = 0;
            indexRow = 0;

            for (int i = 0; i < poolCells.Length; i++)
            {
                for (int j = 0; j < poolCells[i].Length; j++)
                {
                    Debug.Log("row " + i + " col " + j + " = " + poolCells[i][j].SelectedValue);

                }
            }
        }
    }
}