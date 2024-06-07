using ContainerVervoer;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Container Ship Management System!");

        // Get ship dimensions
        Console.Write("Enter the length of the ship: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Enter the width of the ship: ");
        int width = int.Parse(Console.ReadLine());

        // Create a new ship
        Management management = new Management(length, width);

        // Get containers
        List<Container> containers = new List<Container>();
        string addMoreContainers = "Y";
        while (addMoreContainers.ToUpper() == "Y")
        {
            Console.Write("Enter the weight of the container: ");
            int weight = int.Parse(Console.ReadLine());

            Console.Write("Is the container valuable? (Y/N): ");
            bool isValuable = Console.ReadLine().ToUpper() == "Y";

            Console.Write("Is the container cooled? (Y/N): ");
            bool isCooled = Console.ReadLine().ToUpper() == "Y";

            containers.Add(new Container(weight, isValuable, isCooled));

            Console.Write("Do you want to add more containers? (Y/N): ");
            addMoreContainers = Console.ReadLine();
        }

        // Distribute and place containers
        List<Container> leftList = new List<Container>();
        List<Container> rightList = new List<Container>();
        management.DistributeContainers(containers, leftList, rightList);
        management.PlaceContainersOnShip(leftList, rightList);

        // Display ship
        for (int i = 0; i < management.Ship.Length; i++)
        {
            for (int j = 0; j < management.Ship.Width; j++)
            {
                Console.WriteLine($"Stack {j + 1} in Row {i + 1}:");
                foreach (var container in management.Ship.Rows[i].Stacks[j].Containers)
                {
                    Console.WriteLine(container.ToString());
                }
            }
            Console.WriteLine();
        }

    }
}
