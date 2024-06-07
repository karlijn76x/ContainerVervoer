using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContainerVervoer;

namespace UnitTestsContainerVervoer
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void TryAddContainerToSpecificRow_ShouldReturnTrue_WhenThereIsSpace()
        {
            // Arrange
            Ship ship = new Ship(2, 2); // Maak een schip met 2 rijen en 2 stacks per rij
            Container container = new Container(10000, false, false);

            // Act
            bool result = ship.TryAddContainerToSpecificRow(container, 0, false, true);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryAddContainerToSpecificRow_ShouldReturnFalse_WhenRowIsFull()
        {
            // Arrange
            Ship ship = new Ship(2, 2); // Maak een schip met 2 rijen en 2 stacks per rij
            for (int i = 0; i < 2; i++)
            {
                ship.TryAddContainerToSpecificRow(new Container(6000, false, false), 0, false, true);
            }
            Container container = new Container(10000, false, false);

            // Act
            bool result = ship.TryAddContainerToSpecificRow(container, 0, false, true);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
