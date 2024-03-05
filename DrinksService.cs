using Newtonsoft.Json;
using RestSharp;
using System.Web;
using System.Reflection;

namespace drinks_info;

public class DrinksService 
{
    public void GetCategories()
    {   // Link to connect to
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        // Endpoint
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        // If operation successfull
        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            // Deserialize to categories class
            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

            // Convert to list of categories
            List<Category> returnedList = serialize.CategoriesList;

            // Show table of categories
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

         internal void GetDrink(string drink)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            // Change from filter to lookup.php here
            var request = new RestRequest($"lookup.php?i={drink}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;

                var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

                List<DrinkDetail> returnedList = serialize.DrinkDetailList;

                // Grab first element of returned list
                DrinkDetail drinkDetail = returnedList[0];
                
                // List to store the cleaned data
                List<object> prepList = new();

                string formattedName = "";

                foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
                {
                    // Remove the starting str from the strings
                    if (prop.Name.Contains("str"))
                    {
                        formattedName = prop.Name.Substring(3);
                    }
                    // Make sure to skip empty fields
                    if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                    {
                        prepList.Add(new
                        {
                            Key = formattedName,
                            Value = prop.GetValue(drinkDetail)
                        });
                    }
                }
                
                // Show table of data
                TableVisualization.ShowTable(prepList, drinkDetail.strDrink);
            }
        }
    }