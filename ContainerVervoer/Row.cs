namespace ContainerVervoer
{
    public class Row
    {
        public bool IsFull { get; private set; }
        public List<Stack> Stacks { get; private set; }

        public Row(int width)
        {
            Stacks = new List<Stack>(width); // Initialise stack list with initial "width" 
            for (int i = 0; i < width; i++)
            {
                Stacks.Add(new Stack());
            }
        }
        public void MarkAsFull()
        {

           IsFull = true;
        }
        
    }
}
