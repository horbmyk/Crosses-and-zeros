using System;

namespace CrossesAndZeros
{
    [Serializable]
    public class GameBoardData
    {
        private Cell[][] CellsArray;
        public Cell[][] PoolCells
        {
            get { return CellsArray; }
            set { CellsArray = value; }
        }
    }
}
