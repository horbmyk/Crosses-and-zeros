using System;

namespace CrossesAndZeros
{
    [Serializable]
    public class ComputerSide
    {
        public void Move(out int indexColumn, out int indexRow)
        {
            indexColumn = 0;
            indexRow = 0;
        }
    }
}