namespace drinks_info
{
    public class UserInput
    {
        DrinksService drinksService = new();

        internal void GetCategoriesInput() 
        {
            drinksService.GetCategories();
        }
    }
}