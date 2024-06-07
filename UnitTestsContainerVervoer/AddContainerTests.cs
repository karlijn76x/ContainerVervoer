using ContainerVervoer;
namespace UnitTestsContainerVervoer
{
    [TestClass]
    public class AddContainerTests
    {
        [TestMethod]
        public void TryAddContainerToStack_ShouldReturnTrue_WhenStackIsNotFull()
        {
            // Arrange
            Stack stack = new Stack();
            Container container = new Container(10000, false, false);

            // Act
            bool result = stack.TryAddContainerToStack(container);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryAddContainerToStack_ShouldReturnFalse_WhenStackIsFull()
        {
            // Arrange
            Stack stack = new Stack();
            for (int i = 0; i < 12; i++)
            {
                stack.TryAddContainerToStack(new Container(10000, false, false));
            }
            Container container = new Container(10000, false, false);

            // Act
            bool result = stack.TryAddContainerToStack(container);

            // Assert
            Assert.IsFalse(result);
        }
    }
}