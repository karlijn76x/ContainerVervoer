namespace ContainerVervoer
{
    public class Ship
    {
        public int Length { get; private set; }
        public int Width { get; private set; }
        public List<Row> Rows { get; private set; }
        public int MaxShipWeight => Length * Width * 150000;

        public Ship(int length, int width)
        {
            Length = length;
            Width = width;
            Rows = new List<Row>();
            for (int i = 0; i < length; i++)
            {
                Rows.Add(new Row(width));
            }
        }

        public bool TryAddContainerToSpecificRow(Container container, int rowIndex, bool markAsFull, bool leftSide)
        {
            int middle = (Width + 1) / 2;
            int start = leftSide ? 0 : middle;
            int end = leftSide ? middle : Width;

            for (int i = start; i < end; i++)
            {
                if (!Rows[rowIndex].Stacks[i].IsFull && Rows[rowIndex].Stacks[i].TryAddContainerToStack(container))
                {
                    if (markAsFull)
                    {
                        Rows[rowIndex].MarkAsFull();
                    }
                    return true;
                }
            }
            return false;
        }

        public bool TryAddContainerToAnyRow(Container container, bool markAsFull, bool leftSide)
        {
            foreach (var row in Rows)
            {
                if (TryAddContainerToSpecificRow(container, Rows.IndexOf(row), markAsFull, leftSide))
                {
                    return true;
                }
            }
            return false;
        }

        public bool TryAddContainerToTop(Container container, int rowIndex, bool markAsFull, bool leftSide)
        {
            int middle = (Width + 1) / 2;
            int start = leftSide ? 0 : middle;
            int end = leftSide ? middle : Width;

            for (int i = start; i < end; i++)
            {
                if (!Rows[rowIndex].Stacks[i].IsFull && Rows[rowIndex].Stacks[i].TryAddContainerToStack(container))
                {
                    if (markAsFull)
                    {
                        Rows[rowIndex].MarkAsFull();
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
