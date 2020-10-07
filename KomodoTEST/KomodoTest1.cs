using System.Collections.Generic;
using _01_CafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _KomodoTest
{
    [TestClass]
    public class KomodoTests
    {
        private Menu _item;
        private MenuRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            string[] cheeseBurgerIngredients = { "Half Pound Beef Patty", "Lettuce", " Onion", "Ketchup", " Mustard", "American Cheese", };
            Menu cheeseBurger = new Menu("Cheese Burger", "Classic Cheeseburger", 1, cheeseBurgerIngredients, 6.99m);
            _repo = new MenuRepo();
            _repo.AddItem(_item);
        }

        [TestMethod]
        public void AddItem_ShouldGetTrue()
        {
            string[] cheeseBurgerIngredients = { "Half Pound Beef Patty", "Lettuce", " Onion", "Ketchup", " Mustard", "American Cheese", };
            Menu cheeseBurger = new Menu("Cheese Burger", "Classic Cheeseburger", 1, cheeseBurgerIngredients, 6.99m);
            MenuRepo repository = new MenuRepo();
            bool addResult = repository.AddItem(cheeseBurger);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void DeleteItem_ShouldGetTrue()
        {
            Menu item = _item;
            bool deleteResult = _repo.DeleteItem(item);
            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void GetItems_ShouldReturnTrue()
        {
            List<Menu> menuItems = _repo.GetItems();
            bool listHasItems = menuItems.Contains(_item);
            Assert.IsTrue(listHasItems);
        }
    }
}