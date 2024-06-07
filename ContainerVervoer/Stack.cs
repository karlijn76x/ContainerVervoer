
namespace ContainerVervoer
{
    public class Stack
    {
        private List<Container> _containers = new List<Container>();
        public IReadOnlyList<Container> Containers => _containers.AsReadOnly();
        public int TotalStackWeight => _containers.Sum(c => c.Weight);

        public bool CanAddContainer(Container container)
        {
            return (TotalStackWeight + container.Weight) <= 120000;
        }
        public bool IsFull
        {
            get
            {
                return TotalStackWeight >= 120000;
            }
        }

        public bool TryAddContainerToStack(Container container)
        {
            if (CanAddContainer(container))
            {
                _containers.Add(container);
                return true;
            }
            return false;
        }
        public void AddContainer(Container container)
        {
            if (!CanAddContainer(container))
            {
                throw new InvalidOperationException("Cannot add container to stack, exceeds maximum stack weight.");
            }
            _containers.Add(container);
        }
    }
}
