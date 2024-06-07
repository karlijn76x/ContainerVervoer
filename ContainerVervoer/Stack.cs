
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

        // Bepaal of de stack vol is
        public bool IsFull
        {
            get
            {
                // Je moet de logica voor het bepalen of de stack vol is hier implementeren
                // Bijvoorbeeld, je zou kunnen controleren of het totale gewicht van de containers gelijk is aan de maximale capaciteit van de stack
                return TotalStackWeight >= 120000;
            }
        }

        // Probeer een container aan de stack toe te voegen
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
