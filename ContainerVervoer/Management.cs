namespace ContainerVervoer
{
    public class Management
    {
        public Ship Ship { get; private set; }

        public Management(int length, int width)
        {
            Ship = new Ship(length, width);
        }

        public void DistributeContainers(List<Container> containers, List<Container> leftList, List<Container> rightList)
        {
            if (containers.Sum(c => c.Weight) > Ship.MaxShipWeight)
            {
                throw new InvalidOperationException("Total weight of containers exceeds the maximum weight of the ship.");
            }

            var sortedContainers = containers.OrderByDescending(c => c.Weight).ToList();
            var cooledValuableContainers = sortedContainers.Where(c => c.IsCooled && c.IsValuable).ToList();
            var cooledContainers = sortedContainers.Where(c => c.IsCooled && !c.IsValuable).ToList();
            var valuableContainers = sortedContainers.Where(c => c.IsValuable && !c.IsCooled).ToList();
            var normalContainers = sortedContainers.Where(c => !c.IsCooled && !c.IsValuable).ToList();

            DistributeListContainers(cooledContainers, leftList, rightList);
            DistributeListContainers(normalContainers, leftList, rightList);
            DistributeListContainers(cooledValuableContainers, leftList, rightList);
            DistributeListContainers(valuableContainers, leftList, rightList);
        }

        private void DistributeListContainers(List<Container> containers, List<Container> leftList, List<Container> rightList)
        {
            int leftWeight = leftList.Sum(c => c.Weight);
            int rightWeight = rightList.Sum(c => c.Weight);

            foreach (var container in containers)
            {
                if (leftWeight <= rightWeight)
                {
                    leftList.Add(container);
                    leftWeight += container.Weight;
                }
                else
                {
                    rightList.Add(container);
                    rightWeight += container.Weight;
                }
            }
        }

        public void PlaceContainersOnShip(List<Container> leftList, List<Container> rightList)
        {
            PlaceContainersOfTypeOnShip(leftList.Where(c => c.IsCooled && !c.IsValuable).ToList(), false, placeInFirstRow: true, placeOnLeftSide: true);
            PlaceContainersOfTypeOnShip(rightList.Where(c => c.IsCooled && !c.IsValuable).ToList(), false, placeInFirstRow: true, placeOnLeftSide: false);

            PlaceContainersOfTypeOnShip(leftList.Where(c => !c.IsCooled && !c.IsValuable).ToList(), false, placeOnLeftSide: true);
            PlaceContainersOfTypeOnShip(rightList.Where(c => !c.IsCooled && !c.IsValuable).ToList(), false, placeOnLeftSide: false);

            PlaceValuableContainersOnShip(leftList.Where(c => c.IsCooled && c.IsValuable).ToList(), false, placeInFirstRow: true, placeOnLeftSide: true);
            PlaceValuableContainersOnShip(rightList.Where(c => c.IsCooled && c.IsValuable).ToList(), false, placeInFirstRow: true, placeOnLeftSide: false);

            PlaceValuableContainersOnShip(leftList.Where(c => c.IsValuable && !c.IsCooled).ToList(), false, placeEveryTwoRows: true, placeOnLeftSide: true);
            PlaceValuableContainersOnShip(rightList.Where(c => c.IsValuable && !c.IsCooled).ToList(), false, placeEveryTwoRows: true, placeOnLeftSide: false);
        }

        private void PlaceContainersOfTypeOnShip(List<Container> containers, bool markAsFull, bool placeInFirstRow = false, bool placeOnLeftSide = true)
        {
            foreach (var container in containers)
            {
                bool placed = false;
                if (placeInFirstRow)
                {
                    placed = placeOnLeftSide
                        ? Ship.TryAddContainerToSpecificRow(container, 0, markAsFull, leftSide: true)
                        : Ship.TryAddContainerToSpecificRow(container, 0, markAsFull, leftSide: false);
                }
                else
                {
                    placed = placeOnLeftSide
                        ? Ship.TryAddContainerToAnyRow(container, markAsFull, leftSide: true)
                        : Ship.TryAddContainerToAnyRow(container, markAsFull, leftSide: false);
                }

                if (!placed)
                {
                    throw new InvalidOperationException("Failed to place all containers of the specified type on the ship.");
                }
            }
        }

        private void PlaceValuableContainersOnShip(List<Container> containers, bool markAsFull, bool placeInFirstRow = false, bool placeEveryTwoRows = false, bool placeOnLeftSide = true)
        {
            foreach (var container in containers)
            {
                bool placed = false;
                if (placeInFirstRow)
                {
                    placed = placeOnLeftSide
                        ? Ship.TryAddContainerToTop(container, 0, markAsFull, leftSide: true)
                        : Ship.TryAddContainerToTop(container, 0, markAsFull, leftSide: false);
                }
                else if (placeEveryTwoRows)
                {
                    for (int i = 0; i < Ship.Length; i += 2)
                    {
                        placed = placeOnLeftSide
                            ? Ship.TryAddContainerToTop(container, i, markAsFull, leftSide: true)
                            : Ship.TryAddContainerToTop(container, i, markAsFull, leftSide: false);
                        if (placed) break;
                    }
                }

                if (!placed)
                {
                    throw new InvalidOperationException("Failed to place all valuable containers on the ship.");
                }
            }
        }
    }
}
