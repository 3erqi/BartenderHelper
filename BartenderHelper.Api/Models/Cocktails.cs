namespace BartenderHelper.Api.Models;

public class Cocktail
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public string GlassType { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public bool IsCanonical { get; set; }
    public int? OwnerId { get; set; }
    public User? Owner { get; set; }
    public ICollection<CocktailIngredient> Ingredients { get; set; } = new List<CocktailIngredient>();
}