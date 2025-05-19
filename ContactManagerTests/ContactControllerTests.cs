namespace ContactManagerTests
{
    public class ContactControllerTests
    {
        #region Add Action Tests
        [Fact]
        public void AddAction_ReturnsView()
        {
            //arrange
            var contactRepo = new Mock<IRepository<Contact>>();
            var categoryRepo = new Mock<IRepository<Category>>();

            var controller = new ContactController(contactRepo.Object,categoryRepo.Object);

            //act
            var result = controller.Add();

            //assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void AddAction_ModelIsContact()
        {
            //arrange
            var contactRepo = new Mock<IRepository<Contact>>();
            var categoryRepo = new Mock<IRepository<Category>>();

            var controller = new ContactController(contactRepo.Object, categoryRepo.Object);

            //act
            var result = controller.Add() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<Contact>(result.Model);
        }
        #endregion
        #region Edit Action Tests
        [Fact]
        public void EditAction_GET_ReturnsView()
        {
            //arrange
            var contactRepo = new Mock<IRepository<Contact>>();

            var categoryRepo = new Mock<IRepository<Category>>();

            var controller = new ContactController(contactRepo.Object, categoryRepo.Object);

            //act
            var result = controller.Edit(1); //just pass any int really.

            //assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void EditAction_GET_ModelIsContact()
        {
            //arrange
            var contactRepo = new Mock<IRepository<Contact>>();
            contactRepo.Setup(m => m.Get(It.IsAny<int>())).Returns(new Contact());

            var categoryRepo = new Mock<IRepository<Category>>();

            var controller = new ContactController(contactRepo.Object, categoryRepo.Object);

            //act
            var result = controller.Edit(1) as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<Contact>(result.Model);
        }

        [Fact]
        public void EditAction_POST_InvalidModel_ReturnsViewResult()
        {
            //arrange
            var contactRepo = new Mock<IRepository<Contact>>();

            var categoryRepo = new Mock<IRepository<Category>>();

            var controller = new ContactController(contactRepo.Object, categoryRepo.Object);

            //act
            controller.ModelState.AddModelError("FirstName", "Please enter a first name."); //invalidate
            var result = controller.Edit(new Contact());
            //assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void EditAction_POST_ValidModel_ReturnsRedirect()
        {
            //arrange
            var contactRepo = new Mock<IRepository<Contact>>();

            var categoryRepo = new Mock<IRepository<Category>>();

            var controller = new ContactController(contactRepo.Object, categoryRepo.Object);

            //act
            var result = controller.Edit(new Contact());

            //assert
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact]
        public void EditAction_POST_InvalidModel_ModelIsContact()
        {
            //arrange
            var contact = new Contact();
            var contactRepo = new Mock<IRepository<Contact>>();

            var categoryRepo = new Mock<IRepository<Category>>();

            var controller = new ContactController(contactRepo.Object, categoryRepo.Object);

            //act
            controller.ModelState.AddModelError("FirstName", "Please enter a first name."); //invalidate
            var result = controller.Edit(contact) as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<Contact>(result.Model);
        }
        #endregion
        #region Delete Action Test
        [Fact]
        public void DeleteAction_GET_ReturnsView()
        {
            //arrange
            var contactRepo = new Mock<IRepository<Contact>>();

            var categoryRepo = new Mock<IRepository<Category>>();

            var controller = new ContactController(contactRepo.Object, categoryRepo.Object);

            //act
            var result = controller.Delete(1);

            //assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void DeleteAction_GET_ModelIsContact()
        {
            //arrange
            var contactRepo = new Mock<IRepository<Contact>>();
            contactRepo.Setup(m => m.Get(It.IsAny<int>())).Returns(new Contact());

            var categoryRepo = new Mock<IRepository<Category>>();

            var controller = new ContactController(contactRepo.Object, categoryRepo.Object);

            //act
            var result = controller.Delete(1) as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<Contact>(result.Model);
        }
        [Fact]
        public void DeleteAction_POST_ReturnsRedirect()
        {
            //arrange
            var contactRepo = new Mock<IRepository<Contact>>();

            var categoryRepo = new Mock<IRepository<Category>>();

            var controller = new ContactController(contactRepo.Object, categoryRepo.Object);

            //act
            var result = controller.Delete(new Contact());

            //assert
            Assert.IsType<RedirectToActionResult>(result);
        }
        #endregion
        #region Details Action Test
        [Fact]
        public void DetailsAction_ReturnsView()
        {
            //arrange
            var contactRepo = new Mock<IRepository<Contact>>();
            contactRepo.Setup(m => m.Get(It.IsAny<int>())).Returns(new Contact() { CategoryID = 1});

            var categoryRepo = new Mock<IRepository<Category>>();
            categoryRepo.Setup(m => m.Get(It.IsAny<int>())).Returns(new Category() { CategoryID = 1,Name="Name"});

            var controller = new ContactController(contactRepo.Object, categoryRepo.Object);

            //act
            var result = controller.Details(1);

            //assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void DetailsAction_ModelIsContact()
        {
            //arrange
            var contactRepo = new Mock<IRepository<Contact>>();
            contactRepo.Setup(m => m.Get(It.IsAny<int>())).Returns(new Contact() { CategoryID = 1 });

            var categoryRepo = new Mock<IRepository<Category>>();
            categoryRepo.Setup(m => m.Get(It.IsAny<int>())).Returns(new Category() { CategoryID = 1, Name = "Name" });

            var controller = new ContactController(contactRepo.Object, categoryRepo.Object);

            //act
            var result = controller.Details(1) as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<Contact>(result.Model);
        }
        #endregion
    }
}
