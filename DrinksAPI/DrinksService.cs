using Newtonsoft.Json;
using RestSharp;
using System.Web;


namespace drinks_info;

public class DrinksService 
{
    public void GetCategories()
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

            List<Category> returnedList = serialize.CategoriesList;

            TableVisualization.ShowTable(returnedList, "Categories Menu");
        }
    }   

        internal List<Drink> GetDrinksByCategory(string category)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");

            var response = client.ExecuteAsync(request);

            List<Drink> drinks = new();

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;

                var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                drinks = serialize.DrinksList;

                TableVisualization.ShowTable(drinks, "Drinks Menu");

                return drinks;
            }
            return drinks;
        }
}