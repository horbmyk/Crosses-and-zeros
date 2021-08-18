namespace CrossesAndZeros
{
    public class GameBoardData
    {
        private int[,] CellsArray;
        public int[,] Cells
        {
            get => CellsArray;
            set => CellsArray = value;
        }
    }
}
