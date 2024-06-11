namespace ContainerVervoer
{
    public class Stack
    {
        private List<Container> _containers = new List<Container>();
        public IReadOnlyList<Container> Containers => _containers.AsReadOnly();
        public int TotalStackWeight => _containers.Sum(c => c.Weight);
        public bool HasValuableContainer { get; private set; }

        public bool CanAddContainer(Container container)
        {
            return (TotalStackWeight + container.Weight) <= 120000;
        }

        public bool IsFull => TotalStackWeight >= 120000;

        public bool TryAddContainerToStack(Container container)
        {
            if (CanAddContainer(container))
            {
                if (container.IsValuable && HasValuableContainer)
                {
                    return false; // Cannot add another valuable container
                }

                _containers.Add(container);
                if (container.IsValuable)
                {
                    HasValuableContainer = true; // Mark stack as having a valuable container
                }
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

            if (container.IsValuable && HasValuableContainer)
            {
                throw new InvalidOperationException("Cannot add another valuable container to this stack.");
            }

            _containers.Add(container);
            if (container.IsValuable)
            {
                HasValuableContainer = true;
            }
        }
    }
}
