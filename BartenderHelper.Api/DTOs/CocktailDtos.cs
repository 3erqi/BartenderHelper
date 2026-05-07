namespace BartenderHelper.Api.DTOs;

public record CocktailSummaryDto(
    int Id,
    string Name,
    string Description,
    string GlassType,
    bool IsCanonical,
    int? OwnerId,
    string? OwnerUsername
);

public record CocktailDetailDto(
    int Id,
    string Name,
    string Description,
    string Instructions,
    string GlassType,
    string? ImageUrl,
    bool IsCanonical,
    int? OwnerId,
    string? OwnerUsername,
    List<IngredientDto> Ingredients
);

public record SaveCocktailRequest(
    string Name,
    string Description,
    string Instructions,
    string GlassType,
    string? ImageUrl,
    List<IngredientRequest> Ingredients
);

public record IngredientDto(
    int Id,
    string Name,
    string Amount,
    string? Unit
);

public record IngredientRequest(
    string Name,
    string Amount,
    string? Unit
);

