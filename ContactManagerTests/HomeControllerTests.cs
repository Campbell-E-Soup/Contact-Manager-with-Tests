namespace ContactManagerTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexAction_ReturnsView()
        {
            //arrange
            var repo = new Mock<IRepository<Contact>>();
            var controller = new HomeController(repo.Object);
            //act
            var result = controller.Index();
            //assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void IndexAction_ModelIsContactList()
        {
            //arrange
            var repo = new Mock<IRepository<Contact>>();
            var controller = new HomeController(repo.Object);
            //act
            var result = controller.Index() as ViewResult;
            //assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Contact>>(result.Model);
        }
    }
}