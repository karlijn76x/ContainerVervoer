
namespace ContainerVervoer
{
	public class Container
	{
        public bool IsValuable { get; private set; }
        public bool IsCooled { get; private set; }
        public int Weight { get; private set; }
        public bool MaxContainerWeight => Weight <= 30000;
        public bool MinimumContainerWeight => Weight >= 4000;

        public Container(int weight, bool isValuable, bool isCooled)
        {
            if (weight > 30000 || weight < 4000)
            {
                throw new ArgumentOutOfRangeException(nameof(weight), "Container weight must be between 4000 and 30000 kg.");
            }
            Weight = weight;
            IsValuable = isValuable;
            IsCooled = isCooled;
        }
        public override string ToString()
        {
            return $"Weight: {Weight}, IsValuable: {IsValuable}, IsCooled: {IsCooled}";
        }

    }
}
