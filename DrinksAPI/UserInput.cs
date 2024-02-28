using System;

namespace drinks_info
{
    public class UserInput
    {
        DrinksService drinksService = new();

        internal void GetCategoriesInput() 
        {
            drinksService.GetCategories();

            Console.WriteLine("Choose category: ");

            string category = Console.ReadLine();

            while(!Validator.IsStringValid(category))
            {
                Console.WriteLine("\nInvalid category");
                category = Console.ReadLine();
            }

            GetDrinksInput(category);
        }

        private void GetDrinksInput(string category)
        {
            drinksService.GetDrinksByCategory(category);

            Console.WriteLine("Choose a drink: ");

            string drink = Console.ReadLine();

            while(!Validator.IsIdValid(drink))
            {
                Console.WriteLine("\n Invalid drink");
                drink = Console.ReadLine();
            }

            

        }
    }
}