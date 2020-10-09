using _01_CafeRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _CafeUI
{
    public class ProgramUI
    {
        private readonly MenuRepo _repo = new MenuRepo();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;

            while (continueToRun)
            {

                Console.WriteLine(
                    "1) Show Menu \n" +
                    "2) Add To Menu \n" +
                    "3) Remove from Menu \n" +
                    "4) Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        ShowAllItems();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        AddItem();
                        break;
                    case "3":
                        Console.Clear();
                        DeleteItem();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                }
            }
        }

        public void ShowAllItems()
        {
            List<Menu> allItems = _repo.GetItems();

            foreach (Menu item in allItems)
            {
                string listOfIngredients = string.Join(",", item.Ingredients);
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"Meal Number: {item.MealNumber}");
                Console.WriteLine($"Ingredients: {listOfIngredients}");
                Console.WriteLine($"Price:${item.Price}");
               
            }
        }

        public void AddItem()
        {
            Menu newMenuItem = new Menu();
            Console.WriteLine("Name of item:");
            newMenuItem.Name = Console.ReadLine();

            Console.WriteLine($"Enter description of {newMenuItem.Name}");
            newMenuItem.Description = Console.ReadLine();

            Console.WriteLine($"Enter meal number of {newMenuItem}");
            newMenuItem.MealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"Ingredients: {newMenuItem.Name}");
            string ingredientsList = Console.ReadLine();
            newMenuItem.Ingredients = ingredientsList.Split(',');

            Console.WriteLine($"Enter price of {newMenuItem.Name}");
            newMenuItem.Price = decimal.Parse(Console.ReadLine());

            _repo.AddItem(newMenuItem);
            Console.WriteLine($"{newMenuItem.Name} added.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void DeleteItem()
        {
            List<Menu> menuItems = _repo.GetItems();

            if (menuItems.Count == 0)
            {
                Console.WriteLine("Nothing to remove.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            else
            {
                int count = 0;

                foreach (Menu item in menuItems)
                {
                    count++;
                    Console.WriteLine($"{count}) {item.Name}");
                }
                int targetID = int.Parse(Console.ReadLine());
                int actualID = targetID - 1;

                if (actualID >= 0 && actualID < menuItems.Count)
                {
                    Menu selectedItem = menuItems[actualID];
                    if (_repo.DeleteItem(selectedItem))
                    {
                        Console.WriteLine($"{selectedItem.Name} removed.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option...");
                        Console.ReadKey();
                    }

                }
            }
        }

        public void SeedContent()
        {
            string[] cheeseBurgerIngredients = { "Half Pound Beef Patty", "Lettuce", " Onion", "Ketchup", " Mustard", "American Cheese", };
            Menu item1 = new Menu(" \n Cheese Burger", "Classic Cheeseburger", 1, cheeseBurgerIngredients, 6.99m);

            string[] chickenSandwichIngredients = { "Breaded Chicken Breast", "Mayonaisse", "Ketchup", "Swiss Cheese" };
            Menu item2 = new Menu(" \n Chicken Sandwich", "Classic Chicken Sadwich ", 2, chickenSandwichIngredients, 6.99m);

            string[] spicyChickenSandwichIngredients = { "Chicken Breast in Spicy Breading", "Ketchup", "Mayonaisse", };
            Menu item3 = new Menu(" \n Spicy Chicken Sandwich", "Classic Chicken Sandwich with an extra kick!", 3, spicyChickenSandwichIngredients, 6.99m);

            string[] chickenSaladIngredients = { "Grilled Chicken Breast", "Romain Lettuce", "Spinach Leaves", "House Dressing", };
            Menu item4 = new Menu(" \n Grilled Chicken Salad", "A Salad with grilled chicken breast and delicious house dressing!", 4, chickenSaladIngredients, 6.99m);

            _repo.AddItem(item1);
            _repo.AddItem(item2);
            _repo.AddItem(item3);
            _repo.AddItem(item4);
        }
    }
}