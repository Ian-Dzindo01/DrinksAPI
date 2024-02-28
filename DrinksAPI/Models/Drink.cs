using Newtonsoft.Json;

namespace drinks_info;

public class Drinks
{
    //Specify serialization
    [JsonProperty("drinks")]
    public List<Drink> DrinksList {get; set;}
}

public class Drink
{
    public string idDrink {get; set;}
    public string strDrink{get; set;}
}

