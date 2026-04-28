namespace BartenderHelper.Api.Models;

public class CocktailIngredient
{
    public int Id { get; set; }
    public int CocktailId { get; set; }
    public Cocktail Cocktail { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public string Amount { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
}
