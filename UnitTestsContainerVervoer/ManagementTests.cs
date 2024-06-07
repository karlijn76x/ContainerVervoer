using ContainerVervoer;


namespace UnitTestsContainerVervoer
{
    [TestClass]
    public class ManagementTests
    {
        [TestMethod]
        public void DistributeThreeContainers_ShouldDistributeContainersEvenly()
        {
            // Arrange
            Management management = new Management(1, 3);
            List<Container> leftList = new List<Container>
    {
        new Container(10000, false, false),
        new Container(20000, false, false)
    };
            List<Container> middleList = new List<Container>
    {
        new Container(30000, false, false)
    };
            List<Container> rightList = new List<Container>
    {
        new Container(25000, false, false)
    };

            // Act
            management.DistributeContainers(leftList, middleList, rightList);

            // Assert
            int leftWeight = management.Ship.GetTotalWeightOfSide(true);
            int rightWeight = management.Ship.GetTotalWeightOfSide(false);
            Assert.AreEqual(leftWeight, rightWeight);
        }
        [TestMethod]
        public void DistributeContainers_ShouldDistributeContainersEvenly()
        {
            // Arrange
            Management management = new Management(1, 3);
            List<Container> leftList = new List<Container>
    {
        new Container(10000, false, false),
        new Container(20000, false, false)
    };
        List<Container> rightList = new List<Container>
    {
        new Container(25000, false, false)
    };

            // Act
            management.DistributeContainers(, leftList, rightList);

            // Assert
            int leftWeight = management.Ship.GetTotalWeightOfSide(true);
            int rightWeight = management.Ship.GetTotalWeightOfSide(false);
            Assert.AreEqual(leftWeight, rightWeight);
        }
    }
}
