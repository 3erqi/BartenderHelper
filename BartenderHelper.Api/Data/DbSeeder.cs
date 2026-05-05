using BartenderHelper.Api.Models;

namespace BartenderHelper.Api.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (db.Cocktails.Any(c => c.IsCanonical))
            return;

        var cocktails = new List<Cocktail>
        {
            // ── The Unforgettables (34) ─────────────────────────────────────
            new() {
                Name = "Alexander", GlassType = "Coupe", IsCanonical = true,
                Description = "A rich, creamy brandy dessert cocktail.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe. Garnish with grated nutmeg.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Cognac", Amount = "1", Unit = "oz" },
                    new() { Name = "Crème de Cacao (dark)", Amount = "1", Unit = "oz" },
                    new() { Name = "Heavy Cream", Amount = "1", Unit = "oz" }
                }
            },
            new() {
                Name = "Americano", GlassType = "Rocks", IsCanonical = true,
                Description = "A low-ABV Italian aperitivo with bitter and sweet balance.",
                Instructions = "Pour Campari and vermouth over ice. Top with soda water and stir gently. Garnish with an orange slice.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Campari", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Sweet Vermouth", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Soda Water", Amount = "1", Unit = "splash" }
                }
            },
            new() {
                Name = "Angel Face", GlassType = "Coupe", IsCanonical = true,
                Description = "An equal-parts gin cocktail with apricot and apple.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "1", Unit = "oz" },
                    new() { Name = "Apricot Brandy", Amount = "1", Unit = "oz" },
                    new() { Name = "Calvados", Amount = "1", Unit = "oz" }
                }
            },
            new() {
                Name = "Aviation", GlassType = "Coupe", IsCanonical = true,
                Description = "A floral, violet-hued gin cocktail from the early 1900s.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe. Garnish with a cherry.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Maraschino Liqueur", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Crème de Violette", Amount = "0.25", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" }
                }
            },
            new() {
                Name = "Between the Sheets", GlassType = "Coupe", IsCanonical = true,
                Description = "A strong, citrusy sour with rum and cognac.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "White Rum", Amount = "1", Unit = "oz" },
                    new() { Name = "Cognac", Amount = "1", Unit = "oz" },
                    new() { Name = "Triple Sec", Amount = "1", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.25", Unit = "oz" }
                }
            },
            new() {
                Name = "Boulevardier", GlassType = "Coupe", IsCanonical = true,
                Description = "A whiskey-forward Negroni riff with bourbon replacing gin.",
                Instructions = "Stir all ingredients over ice. Strain into a chilled coupe or rocks glass. Garnish with an orange peel.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Bourbon", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Campari", Amount = "1", Unit = "oz" },
                    new() { Name = "Sweet Vermouth", Amount = "1", Unit = "oz" }
                }
            },
            new() {
                Name = "Brandy Crusta", GlassType = "Coupe", IsCanonical = true,
                Description = "A 19th-century cognac classic with a sugar-crusted rim.",
                Instructions = "Coat the rim of a coupe with sugar. Shake all ingredients with ice and strain in. Garnish with a long lemon peel.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Cognac", Amount = "2", Unit = "oz" },
                    new() { Name = "Maraschino Liqueur", Amount = "0.25", Unit = "oz" },
                    new() { Name = "Triple Sec", Amount = "0.25", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Angostura Bitters", Amount = "2", Unit = "dashes" }
                }
            },
            new() {
                Name = "Casino", GlassType = "Coupe", IsCanonical = true,
                Description = "A classic gin cocktail with lemon and maraschino.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe. Garnish with a cherry.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Old Tom Gin", Amount = "2", Unit = "oz" },
                    new() { Name = "Maraschino Liqueur", Amount = "0.25", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.25", Unit = "oz" },
                    new() { Name = "Orange Bitters", Amount = "2", Unit = "dashes" }
                }
            },
            new() {
                Name = "Clover Club", GlassType = "Coupe", IsCanonical = true,
                Description = "A frothy, pink gin sour with raspberry.",
                Instructions = "Dry shake all ingredients. Add ice and shake again. Double strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "2", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Raspberry Syrup", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Egg White", Amount = "1", Unit = "whole" }
                }
            },
            new() {
                Name = "Daiquiri", GlassType = "Coupe", IsCanonical = true,
                Description = "A simple, perfectly balanced rum sour.",
                Instructions = "Shake all ingredients with ice. Double strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "White Rum", Amount = "2", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.75", Unit = "oz" }
                }
            },
            new() {
                Name = "Dry Martini", GlassType = "Martini", IsCanonical = true,
                Description = "The benchmark of cocktail elegance — gin and vermouth, stirred cold.",
                Instructions = "Stir gin and vermouth over ice until well chilled. Strain into a chilled martini glass. Garnish with a lemon twist or olive.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "2.5", Unit = "oz" },
                    new() { Name = "Dry Vermouth", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Orange Bitters", Amount = "1", Unit = "dash" }
                }
            },
            new() {
                Name = "Gin Fizz", GlassType = "Highball", IsCanonical = true,
                Description = "A refreshing, bubbly gin lemonade.",
                Instructions = "Shake gin, lemon juice, and syrup with ice. Strain into a highball over ice and top with soda water.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "2", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "1", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Soda Water", Amount = "3", Unit = "oz" }
                }
            },
            new() {
                Name = "Hanky Panky", GlassType = "Coupe", IsCanonical = true,
                Description = "A bittersweet gin and vermouth cocktail with a herbal Fernet kick.",
                Instructions = "Stir all ingredients over ice. Strain into a chilled coupe. Garnish with an orange peel.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Sweet Vermouth", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Fernet-Branca", Amount = "2", Unit = "dashes" }
                }
            },
            new() {
                Name = "John Collins", GlassType = "Highball", IsCanonical = true,
                Description = "A tall, refreshing gin lemonade with soda.",
                Instructions = "Build gin, lemon juice, and syrup in a highball over ice. Top with soda water. Garnish with a lemon slice and cherry.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "2", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "1", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Soda Water", Amount = "3", Unit = "oz" }
                }
            },
            new() {
                Name = "Last Word", GlassType = "Coupe", IsCanonical = true,
                Description = "A bold, equal-parts Prohibition-era cocktail.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Green Chartreuse", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Maraschino Liqueur", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.75", Unit = "oz" }
                }
            },
            new() {
                Name = "Manhattan", GlassType = "Coupe", IsCanonical = true,
                Description = "A smooth, boozy rye cocktail with sweet vermouth.",
                Instructions = "Stir all ingredients over ice. Strain into a chilled coupe. Garnish with a cherry.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Rye Whiskey", Amount = "2", Unit = "oz" },
                    new() { Name = "Sweet Vermouth", Amount = "1", Unit = "oz" },
                    new() { Name = "Angostura Bitters", Amount = "2", Unit = "dashes" }
                }
            },
            new() {
                Name = "Martinez", GlassType = "Coupe", IsCanonical = true,
                Description = "The proto-Martini — sweeter, richer, and older than its cousin.",
                Instructions = "Stir all ingredients over ice. Strain into a chilled coupe. Garnish with a lemon twist.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Old Tom Gin", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Sweet Vermouth", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Maraschino Liqueur", Amount = "1", Unit = "tsp" },
                    new() { Name = "Orange Bitters", Amount = "2", Unit = "dashes" }
                }
            },
            new() {
                Name = "Mary Pickford", GlassType = "Coupe", IsCanonical = true,
                Description = "A tropical, fruity rum cocktail from 1920s Havana.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "White Rum", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Pineapple Juice", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Maraschino Liqueur", Amount = "1", Unit = "tsp" },
                    new() { Name = "Grenadine", Amount = "1", Unit = "tsp" }
                }
            },
            new() {
                Name = "Monkey Gland", GlassType = "Coupe", IsCanonical = true,
                Description = "A fruity gin cocktail with an absinthe backbone.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "2", Unit = "oz" },
                    new() { Name = "Orange Juice", Amount = "1", Unit = "oz" },
                    new() { Name = "Grenadine", Amount = "1", Unit = "tsp" },
                    new() { Name = "Absinthe", Amount = "1", Unit = "tsp" }
                }
            },
            new() {
                Name = "Negroni", GlassType = "Rocks", IsCanonical = true,
                Description = "A bold, bittersweet Italian aperitivo.",
                Instructions = "Stir all ingredients over ice. Strain into a rocks glass over a large ice cube. Garnish with an orange peel.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "1", Unit = "oz" },
                    new() { Name = "Campari", Amount = "1", Unit = "oz" },
                    new() { Name = "Sweet Vermouth", Amount = "1", Unit = "oz" }
                }
            },
            new() {
                Name = "Old Fashioned", GlassType = "Rocks", IsCanonical = true,
                Description = "A timeless whiskey cocktail, stirred and spirit-forward.",
                Instructions = "Add sugar and bitters to a glass. Add a splash of water and stir. Add ice and whiskey. Stir until chilled. Garnish with an orange peel.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Bourbon or Rye Whiskey", Amount = "2", Unit = "oz" },
                    new() { Name = "Angostura Bitters", Amount = "2", Unit = "dashes" },
                    new() { Name = "Sugar", Amount = "1", Unit = "tsp" },
                    new() { Name = "Water", Amount = "1", Unit = "splash" }
                }
            },
            new() {
                Name = "Paradise", GlassType = "Coupe", IsCanonical = true,
                Description = "A fruity gin cocktail with apricot and orange.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "2", Unit = "oz" },
                    new() { Name = "Apricot Brandy", Amount = "1", Unit = "oz" },
                    new() { Name = "Orange Juice", Amount = "1", Unit = "oz" }
                }
            },
            new() {
                Name = "Planter's Punch", GlassType = "Highball", IsCanonical = true,
                Description = "A fruity, layered rum punch from Jamaica.",
                Instructions = "Shake rum, lime juice, and sugar with ice. Strain into a highball over ice. Top with soda. Garnish with a lime wheel.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Dark Rum", Amount = "2", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "1", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Soda Water", Amount = "2", Unit = "oz" },
                    new() { Name = "Angostura Bitters", Amount = "2", Unit = "dashes" }
                }
            },
            new() {
                Name = "Porto Flip", GlassType = "Coupe", IsCanonical = true,
                Description = "A silky, egg-enriched brandy and port cocktail.",
                Instructions = "Shake all ingredients vigorously with ice. Strain into a chilled coupe. Garnish with grated nutmeg.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Brandy", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Ruby Port", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Egg Yolk", Amount = "1", Unit = "whole" }
                }
            },
            new() {
                Name = "Ramos Gin Fizz", GlassType = "Highball", IsCanonical = true,
                Description = "New Orleans' famously silky, frothy citrus gin fizz.",
                Instructions = "Dry shake all ingredients except soda for 2 minutes. Add ice and shake again vigorously. Strain into a highball. Top slowly with soda water.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "2", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Heavy Cream", Amount = "1", Unit = "oz" },
                    new() { Name = "Orange Flower Water", Amount = "3", Unit = "dashes" },
                    new() { Name = "Egg White", Amount = "1", Unit = "whole" },
                    new() { Name = "Soda Water", Amount = "2", Unit = "oz" }
                }
            },
            new() {
                Name = "Remember the Maine", GlassType = "Coupe", IsCanonical = true,
                Description = "A smoky, cherry-tinged rye Manhattan variation.",
                Instructions = "Stir all ingredients over ice. Strain into a chilled coupe. Garnish with a cherry.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Rye Whiskey", Amount = "2", Unit = "oz" },
                    new() { Name = "Sweet Vermouth", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Cherry Heering", Amount = "0.25", Unit = "oz" },
                    new() { Name = "Absinthe", Amount = "0.25", Unit = "tsp" }
                }
            },
            new() {
                Name = "Rusty Nail", GlassType = "Rocks", IsCanonical = true,
                Description = "A simple, warming Scotch and Drambuie sipper.",
                Instructions = "Build over ice in a rocks glass. Stir gently. Garnish with a lemon twist.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Scotch Whisky", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Drambuie", Amount = "0.75", Unit = "oz" }
                }
            },
            new() {
                Name = "Sazerac", GlassType = "Rocks", IsCanonical = true,
                Description = "New Orleans' official cocktail — rye, bitters, and an absinthe rinse.",
                Instructions = "Rinse a chilled rocks glass with absinthe, discard excess. Stir rye, bitters, and sugar over ice. Strain into the prepared glass. Garnish with a lemon peel.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Rye Whiskey", Amount = "2", Unit = "oz" },
                    new() { Name = "Peychaud's Bitters", Amount = "3", Unit = "dashes" },
                    new() { Name = "Sugar", Amount = "1", Unit = "tsp" },
                    new() { Name = "Absinthe", Amount = "1", Unit = "rinse" }
                }
            },
            new() {
                Name = "Sidecar", GlassType = "Coupe", IsCanonical = true,
                Description = "A bright, citrusy cognac sour with a sugar rim.",
                Instructions = "Rim a coupe with sugar. Shake all ingredients with ice. Strain into the prepared glass.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Cognac", Amount = "2", Unit = "oz" },
                    new() { Name = "Triple Sec", Amount = "1", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" }
                }
            },
            new() {
                Name = "Stinger", GlassType = "Coupe", IsCanonical = true,
                Description = "A clean, minty brandy after-dinner drink.",
                Instructions = "Shake both ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Cognac", Amount = "2", Unit = "oz" },
                    new() { Name = "White Crème de Menthe", Amount = "1", Unit = "oz" }
                }
            },
            new() {
                Name = "Tuxedo", GlassType = "Coupe", IsCanonical = true,
                Description = "A refined dry martini variation with maraschino and absinthe.",
                Instructions = "Stir all ingredients over ice. Strain into a chilled coupe. Garnish with a cherry and lemon twist.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Old Tom Gin", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Dry Vermouth", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Maraschino Liqueur", Amount = "0.25", Unit = "tsp" },
                    new() { Name = "Absinthe", Amount = "0.25", Unit = "tsp" },
                    new() { Name = "Orange Bitters", Amount = "3", Unit = "dashes" }
                }
            },
            new() {
                Name = "Vieux Carré", GlassType = "Rocks", IsCanonical = true,
                Description = "New Orleans' French Quarter cocktail — rye, cognac, vermouth, and Bénédictine.",
                Instructions = "Stir all ingredients over ice. Strain into a rocks glass over ice. Garnish with a lemon twist and cherry.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Rye Whiskey", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Cognac", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Sweet Vermouth", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Bénédictine", Amount = "1", Unit = "tsp" },
                    new() { Name = "Peychaud's Bitters", Amount = "1", Unit = "dash" },
                    new() { Name = "Angostura Bitters", Amount = "1", Unit = "dash" }
                }
            },
            new() {
                Name = "Whiskey Sour", GlassType = "Rocks", IsCanonical = true,
                Description = "A tart, frothy whiskey classic — better with egg white.",
                Instructions = "Dry shake all ingredients. Add ice and shake again. Strain into a rocks glass. Optional: dash of bitters on the foam.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Bourbon", Amount = "2", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Egg White", Amount = "1", Unit = "whole" }
                }
            },
            new() {
                Name = "White Lady", GlassType = "Coupe", IsCanonical = true,
                Description = "A clean, citrusy gin sour with triple sec.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "2", Unit = "oz" },
                    new() { Name = "Triple Sec", Amount = "1", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" }
                }
            },

            // ── Contemporary Classics (34) ──────────────────────────────────
            new() {
                Name = "Bellini", GlassType = "Flute", IsCanonical = true,
                Description = "A delicate, peachy sparkling cocktail from Venice.",
                Instructions = "Pour peach purée into a chilled flute. Top slowly with Prosecco and stir gently.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Prosecco", Amount = "3", Unit = "oz" },
                    new() { Name = "Peach Purée", Amount = "2", Unit = "oz" }
                }
            },
            new() {
                Name = "Black Russian", GlassType = "Rocks", IsCanonical = true,
                Description = "A simple, boozy coffee cocktail.",
                Instructions = "Pour vodka and coffee liqueur over ice in a rocks glass. Stir.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Vodka", Amount = "2", Unit = "oz" },
                    new() { Name = "Coffee Liqueur", Amount = "1", Unit = "oz" }
                }
            },
            new() {
                Name = "Bloody Mary", GlassType = "Highball", IsCanonical = true,
                Description = "The ultimate savory brunch cocktail.",
                Instructions = "Build all ingredients over ice in a highball. Stir well. Garnish with celery and a lemon wedge.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Vodka", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Tomato Juice", Amount = "3", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Worcestershire Sauce", Amount = "2", Unit = "dashes" },
                    new() { Name = "Tabasco", Amount = "2", Unit = "dashes" },
                    new() { Name = "Celery Salt", Amount = "1", Unit = "pinch" }
                }
            },
            new() {
                Name = "Caipirinha", GlassType = "Rocks", IsCanonical = true,
                Description = "Brazil's national cocktail — cachaça muddled with lime and sugar.",
                Instructions = "Muddle lime wedges and sugar in a rocks glass. Add cachaça and crushed ice. Stir well.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Cachaça", Amount = "2", Unit = "oz" },
                    new() { Name = "Lime", Amount = "0.5", Unit = "whole" },
                    new() { Name = "Sugar", Amount = "2", Unit = "tsp" }
                }
            },
            new() {
                Name = "Cardinale", GlassType = "Rocks", IsCanonical = true,
                Description = "A dry, bitter Negroni variation using dry vermouth.",
                Instructions = "Stir all ingredients over ice. Strain into a rocks glass over ice. Garnish with a lemon peel.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Campari", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Dry Vermouth", Amount = "0.75", Unit = "oz" }
                }
            },
            new() {
                Name = "Champagne Cocktail", GlassType = "Flute", IsCanonical = true,
                Description = "A classic, effervescent drink with bitters-soaked sugar and cognac.",
                Instructions = "Place a sugar cube in a flute and saturate with bitters. Add cognac. Top with chilled champagne. Garnish with a lemon twist.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Champagne", Amount = "4", Unit = "oz" },
                    new() { Name = "Cognac", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Angostura Bitters", Amount = "3", Unit = "dashes" },
                    new() { Name = "Sugar Cube", Amount = "1", Unit = "whole" }
                }
            },
            new() {
                Name = "Corpse Reviver #2", GlassType = "Coupe", IsCanonical = true,
                Description = "A bright, anise-kissed gin sour. Warned to revive the dead.",
                Instructions = "Rinse a coupe with absinthe. Shake remaining ingredients with ice and strain in.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Triple Sec", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Lillet Blanc", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Absinthe", Amount = "1", Unit = "rinse" }
                }
            },
            new() {
                Name = "Cosmopolitan", GlassType = "Martini", IsCanonical = true,
                Description = "A tart, cranberry-pink vodka classic made famous in the 90s.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled martini glass. Garnish with a flamed orange twist.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Citrus Vodka", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Triple Sec", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Cranberry Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.25", Unit = "oz" }
                }
            },
            new() {
                Name = "Cuba Libre", GlassType = "Highball", IsCanonical = true,
                Description = "More than just rum and Coke — the lime makes it.",
                Instructions = "Squeeze lime into a highball over ice. Add rum and top with cola. Stir gently.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "White Rum", Amount = "2", Unit = "oz" },
                    new() { Name = "Cola", Amount = "4", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.5", Unit = "oz" }
                }
            },
            new() {
                Name = "French 75", GlassType = "Flute", IsCanonical = true,
                Description = "A punchy, celebratory gin and champagne fizz.",
                Instructions = "Shake gin, lemon, and syrup with ice. Strain into a flute and top with champagne. Garnish with a lemon twist.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "1", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Champagne", Amount = "3", Unit = "oz" }
                }
            },
            new() {
                Name = "French Connection", GlassType = "Rocks", IsCanonical = true,
                Description = "A smooth, nutty two-ingredient after-dinner drink.",
                Instructions = "Pour both ingredients over ice in a rocks glass. Stir gently.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Cognac", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Amaretto", Amount = "0.75", Unit = "oz" }
                }
            },
            new() {
                Name = "Garibaldi", GlassType = "Highball", IsCanonical = true,
                Description = "Italy's simplest aperitivo — Campari with fluffy whipped orange juice.",
                Instructions = "Pour Campari over ice in a highball. Top with freshly whipped orange juice. Garnish with an orange slice.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Campari", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Orange Juice", Amount = "3", Unit = "oz" }
                }
            },
            new() {
                Name = "Grasshopper", GlassType = "Coupe", IsCanonical = true,
                Description = "A creamy, mint-chocolate after-dinner cocktail.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Green Crème de Menthe", Amount = "1", Unit = "oz" },
                    new() { Name = "White Crème de Cacao", Amount = "1", Unit = "oz" },
                    new() { Name = "Heavy Cream", Amount = "1", Unit = "oz" }
                }
            },
            new() {
                Name = "Hemingway Special", GlassType = "Coupe", IsCanonical = true,
                Description = "Papa Hemingway's double daiquiri — drier and grapefruity.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "White Rum", Amount = "2", Unit = "oz" },
                    new() { Name = "Grapefruit Juice", Amount = "1", Unit = "oz" },
                    new() { Name = "Maraschino Liqueur", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.5", Unit = "oz" }
                }
            },
            new() {
                Name = "Horse's Neck", GlassType = "Highball", IsCanonical = true,
                Description = "A long, spiced ginger and bourbon highball.",
                Instructions = "Peel a lemon in one spiral and drape it inside a highball. Add ice, bourbon, and bitters. Top with ginger ale.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Bourbon", Amount = "2", Unit = "oz" },
                    new() { Name = "Ginger Ale", Amount = "4", Unit = "oz" },
                    new() { Name = "Angostura Bitters", Amount = "2", Unit = "dashes" }
                }
            },
            new() {
                Name = "Irish Coffee", GlassType = "Irish Coffee Mug", IsCanonical = true,
                Description = "Warm Irish whiskey and coffee topped with lightly whipped cream.",
                Instructions = "Warm a glass. Add whiskey, sugar, and hot coffee. Stir to dissolve. Float lightly whipped cream on top. Do not stir.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Irish Whiskey", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Hot Coffee", Amount = "4", Unit = "oz" },
                    new() { Name = "Brown Sugar", Amount = "1", Unit = "tsp" },
                    new() { Name = "Lightly Whipped Cream", Amount = "1", Unit = "float" }
                }
            },
            new() {
                Name = "Kir", GlassType = "Wine", IsCanonical = true,
                Description = "A Burgundy aperitif — white wine with a hint of blackcurrant.",
                Instructions = "Pour crème de cassis into a wine glass. Top with chilled white wine.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Dry White Wine", Amount = "4", Unit = "oz" },
                    new() { Name = "Crème de Cassis", Amount = "0.5", Unit = "oz" }
                }
            },
            new() {
                Name = "Lemon Drop Martini", GlassType = "Martini", IsCanonical = true,
                Description = "A sweet-tart vodka sour in a sugar-rimmed martini glass.",
                Instructions = "Rim a martini glass with sugar. Shake all ingredients with ice. Strain into the prepared glass.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Vodka", Amount = "2", Unit = "oz" },
                    new() { Name = "Triple Sec", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "1", Unit = "oz" }
                }
            },
            new() {
                Name = "Long Island Iced Tea", GlassType = "Highball", IsCanonical = true,
                Description = "Five spirits disguised as iced tea. Deceptively strong.",
                Instructions = "Shake all spirits and juices with ice. Strain into a highball over ice. Top with a splash of cola. Garnish with a lemon wedge.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Vodka", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Gin", Amount = "0.5", Unit = "oz" },
                    new() { Name = "White Rum", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Tequila", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Triple Sec", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "1", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Cola", Amount = "1", Unit = "splash" }
                }
            },
            new() {
                Name = "Mai Tai", GlassType = "Rocks", IsCanonical = true,
                Description = "Trader Vic's defining Tiki cocktail with rum, lime, and orgeat.",
                Instructions = "Shake all ingredients except dark rum with ice. Strain into a rocks glass over crushed ice. Float dark rum on top. Garnish with mint and a cherry.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Aged Rum", Amount = "2", Unit = "oz" },
                    new() { Name = "Dark Rum", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Orange Curaçao", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Orgeat", Amount = "0.25", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "1", Unit = "oz" }
                }
            },
            new() {
                Name = "Margarita", GlassType = "Margarita", IsCanonical = true,
                Description = "A bright, citrusy tequila classic with a salted rim.",
                Instructions = "Shake all ingredients with ice. Strain into a salt-rimmed glass over ice.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Tequila", Amount = "2", Unit = "oz" },
                    new() { Name = "Triple Sec", Amount = "1", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "1", Unit = "oz" }
                }
            },
            new() {
                Name = "Mimosa", GlassType = "Flute", IsCanonical = true,
                Description = "The essential brunch cocktail — Champagne and orange juice.",
                Instructions = "Pour orange juice into a chilled flute. Top with champagne.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Champagne", Amount = "3", Unit = "oz" },
                    new() { Name = "Orange Juice", Amount = "3", Unit = "oz" }
                }
            },
            new() {
                Name = "Mint Julep", GlassType = "Julep Tin", IsCanonical = true,
                Description = "Kentucky Derby's signature bourbon and mint cocktail.",
                Instructions = "Gently muddle mint with syrup in a julep tin. Add bourbon and crushed ice. Stir until the tin frosts. Garnish with a large mint bouquet.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Bourbon", Amount = "2.5", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Mint Leaves", Amount = "8", Unit = "leaves" }
                }
            },
            new() {
                Name = "Mojito", GlassType = "Highball", IsCanonical = true,
                Description = "A refreshing Cuban classic with mint and lime.",
                Instructions = "Muddle mint and lime juice in a glass. Add sugar and rum. Fill with ice and top with soda water. Garnish with mint.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "White Rum", Amount = "2", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "1", Unit = "oz" },
                    new() { Name = "Sugar", Amount = "2", Unit = "tsp" },
                    new() { Name = "Mint Leaves", Amount = "8", Unit = "leaves" },
                    new() { Name = "Soda Water", Amount = "2", Unit = "oz" }
                }
            },
            new() {
                Name = "Moscow Mule", GlassType = "Copper Mug", IsCanonical = true,
                Description = "A zippy vodka and ginger beer combo, served in a copper mug.",
                Instructions = "Fill a copper mug with ice. Add vodka and lime juice. Top with ginger beer. Garnish with a lime wedge.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Vodka", Amount = "2", Unit = "oz" },
                    new() { Name = "Ginger Beer", Amount = "4", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.5", Unit = "oz" }
                }
            },
            new() {
                Name = "Piña Colada", GlassType = "Hurricane", IsCanonical = true,
                Description = "Puerto Rico's tropical rum, coconut, and pineapple classic.",
                Instructions = "Blend all ingredients with ice until smooth. Pour into a hurricane glass. Garnish with a pineapple slice and cherry.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "White Rum", Amount = "2", Unit = "oz" },
                    new() { Name = "Coconut Cream", Amount = "1", Unit = "oz" },
                    new() { Name = "Pineapple Juice", Amount = "2", Unit = "oz" }
                }
            },
            new() {
                Name = "Pisco Sour", GlassType = "Coupe", IsCanonical = true,
                Description = "Peru's national cocktail — a frothy pisco sour with Angostura bitters.",
                Instructions = "Dry shake all ingredients except bitters. Add ice and shake again. Strain into a coupe. Garnish with a few drops of Angostura bitters.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Pisco", Amount = "2", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "1", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Egg White", Amount = "1", Unit = "whole" },
                    new() { Name = "Angostura Bitters", Amount = "3", Unit = "drops" }
                }
            },
            new() {
                Name = "Rabo de Galo", GlassType = "Rocks", IsCanonical = true,
                Description = "A Brazilian classic — cachaça stirred with sweet vermouth.",
                Instructions = "Stir all ingredients over ice. Strain into a rocks glass over ice. Garnish with a lemon twist.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Cachaça", Amount = "2", Unit = "oz" },
                    new() { Name = "Sweet Vermouth", Amount = "1", Unit = "oz" },
                    new() { Name = "Angostura Bitters", Amount = "2", Unit = "dashes" }
                }
            },
            new() {
                Name = "Sea Breeze", GlassType = "Highball", IsCanonical = true,
                Description = "A crisp, tart vodka cocktail with cranberry and grapefruit.",
                Instructions = "Build all ingredients over ice in a highball. Stir gently. Garnish with a lime wedge.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Vodka", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Cranberry Juice", Amount = "3", Unit = "oz" },
                    new() { Name = "Grapefruit Juice", Amount = "1", Unit = "oz" }
                }
            },
            new() {
                Name = "Sex on the Beach", GlassType = "Highball", IsCanonical = true,
                Description = "A fruity, tropical vodka cocktail with peach and cranberry.",
                Instructions = "Shake all ingredients with ice. Strain into a highball over ice. Garnish with an orange slice.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Vodka", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Peach Schnapps", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Orange Juice", Amount = "2", Unit = "oz" },
                    new() { Name = "Cranberry Juice", Amount = "2", Unit = "oz" }
                }
            },
            new() {
                Name = "Singapore Sling", GlassType = "Highball", IsCanonical = true,
                Description = "A complex, fruity gin sling from Raffles Hotel, Singapore.",
                Instructions = "Shake gin, cherry liqueur, Bénédictine, curaçao, pineapple, lime, and bitters with ice. Strain into a highball over ice. Top with soda. Float grenadine.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Cherry Liqueur", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Bénédictine", Amount = "0.25", Unit = "oz" },
                    new() { Name = "Triple Sec", Amount = "0.25", Unit = "oz" },
                    new() { Name = "Pineapple Juice", Amount = "2", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Grenadine", Amount = "0.5", Unit = "tsp" },
                    new() { Name = "Angostura Bitters", Amount = "1", Unit = "dash" }
                }
            },
            new() {
                Name = "Tequila Sunrise", GlassType = "Highball", IsCanonical = true,
                Description = "A layered, colorful tequila and OJ cocktail with a grenadine sunset.",
                Instructions = "Pour tequila and OJ over ice in a highball. Do not stir. Slowly pour grenadine down the side so it sinks. Garnish with an orange slice.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Tequila", Amount = "2", Unit = "oz" },
                    new() { Name = "Orange Juice", Amount = "4", Unit = "oz" },
                    new() { Name = "Grenadine", Amount = "0.75", Unit = "oz" }
                }
            },
            new() {
                Name = "Vesper", GlassType = "Martini", IsCanonical = true,
                Description = "James Bond's original martini — gin, vodka, and Lillet, shaken.",
                Instructions = "Shake all ingredients vigorously with ice. Strain into a chilled martini glass. Garnish with a lemon twist.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "3", Unit = "oz" },
                    new() { Name = "Vodka", Amount = "1", Unit = "oz" },
                    new() { Name = "Lillet Blanc", Amount = "0.5", Unit = "oz" }
                }
            },
            new() {
                Name = "Zombie", GlassType = "Zombie", IsCanonical = true,
                Description = "Donn Beach's powerful, fruity Tiki rum punch. Limit two per customer.",
                Instructions = "Shake all ingredients with ice. Strain into a zombie glass over crushed ice. Garnish with a mint sprig and cherry.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Light Rum", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Dark Jamaican Rum", Amount = "1", Unit = "oz" },
                    new() { Name = "Demerara Rum (151)", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Falernum", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Grenadine", Amount = "1", Unit = "tsp" },
                    new() { Name = "Angostura Bitters", Amount = "1", Unit = "dash" },
                    new() { Name = "Absinthe", Amount = "6", Unit = "drops" }
                }
            },

            // ── The New Era (34) ────────────────────────────────────────────
            new() {
                Name = "Bee's Knees", GlassType = "Coupe", IsCanonical = true,
                Description = "A Prohibition-era gin sour sweetened with honey.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "2", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Honey Syrup", Amount = "0.75", Unit = "oz" }
                }
            },
            new() {
                Name = "Bramble", GlassType = "Rocks", IsCanonical = true,
                Description = "Dick Bradsell's 1984 gin sour with a crème de mûre drizzle.",
                Instructions = "Shake gin, lemon, and syrup with ice. Strain into a rocks glass over crushed ice. Drizzle crème de mûre over top. Garnish with a blackberry and lemon slice.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "2", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "1", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Crème de Mûre", Amount = "0.5", Unit = "oz" }
                }
            },
            new() {
                Name = "Canchanchara", GlassType = "Rocks", IsCanonical = true,
                Description = "Cuba's oldest cocktail — aguardiente, honey, and lime.",
                Instructions = "Stir honey and lime juice in a clay cup or rocks glass. Add rum and ice. Stir well.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Cuban Aguardiente (or White Rum)", Amount = "2", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Honey", Amount = "1", Unit = "tsp" }
                }
            },
            new() {
                Name = "Chartreuse Swizzle", GlassType = "Highball", IsCanonical = true,
                Description = "A tropical, herbal swizzle with Green Chartreuse and pineapple.",
                Instructions = "Combine all ingredients in a highball over crushed ice. Swizzle until the glass frosts. Garnish with a mint sprig.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Green Chartreuse", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Pineapple Juice", Amount = "1", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Falernum", Amount = "0.5", Unit = "oz" }
                }
            },
            new() {
                Name = "Dark 'N' Stormy", GlassType = "Highball", IsCanonical = true,
                Description = "Bermuda's national drink — dark rum floating on ginger beer.",
                Instructions = "Fill a highball with ice. Add lime juice and ginger beer. Float dark rum on top. Garnish with a lime wedge.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Dark Rum", Amount = "2", Unit = "oz" },
                    new() { Name = "Ginger Beer", Amount = "4", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.5", Unit = "oz" }
                }
            },
            new() {
                Name = "Don's Special Daiquiri", GlassType = "Coupe", IsCanonical = true,
                Description = "Donn Beach's tropical daiquiri variation with grapefruit and falernum.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "White Rum", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Grapefruit Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Falernum", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Maraschino Liqueur", Amount = "0.25", Unit = "oz" }
                }
            },
            new() {
                Name = "Espresso Martini", GlassType = "Coupe", IsCanonical = true,
                Description = "Dick Bradsell's caffeinated vodka cocktail with a frothy top.",
                Instructions = "Shake all ingredients hard with ice. Double strain into a chilled coupe. Garnish with 3 coffee beans.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Vodka", Amount = "2", Unit = "oz" },
                    new() { Name = "Espresso", Amount = "1", Unit = "oz" },
                    new() { Name = "Coffee Liqueur", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.25", Unit = "oz" }
                }
            },
            new() {
                Name = "Fernandito", GlassType = "Rocks", IsCanonical = true,
                Description = "Argentina's beloved bitter digestif highball — Fernet and Coke.",
                Instructions = "Fill a rocks glass with ice. Pour Fernet-Branca over ice. Top with cola. Stir gently.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Fernet-Branca", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Cola", Amount = "4", Unit = "oz" }
                }
            },
            new() {
                Name = "French Martini", GlassType = "Martini", IsCanonical = true,
                Description = "A silky, berry-and-pineapple vodka cocktail with a frothy top.",
                Instructions = "Shake all ingredients hard with ice. Double strain into a chilled martini glass.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Vodka", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Chambord", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Pineapple Juice", Amount = "1", Unit = "oz" }
                }
            },
            new() {
                Name = "Gin Basil Smash", GlassType = "Rocks", IsCanonical = true,
                Description = "Jörg Meyer's herby, fresh gin sour with muddled basil.",
                Instructions = "Muddle basil leaves in a shaker. Add remaining ingredients and ice. Shake vigorously. Double strain into a rocks glass over ice.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "2", Unit = "oz" },
                    new() { Name = "Fresh Basil Leaves", Amount = "8", Unit = "leaves" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.75", Unit = "oz" }
                }
            },
            new() {
                Name = "Grand Margarita", GlassType = "Rocks", IsCanonical = true,
                Description = "An elevated Margarita using Grand Marnier instead of triple sec.",
                Instructions = "Shake all ingredients with ice. Strain into a salt-rimmed rocks glass over ice.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Tequila", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Grand Marnier", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.75", Unit = "oz" }
                }
            },
            new() {
                Name = "IBA Tiki", GlassType = "Tiki Mug", IsCanonical = true,
                Description = "The IBA's own tropical Tiki cocktail with rum and tropical fruits.",
                Instructions = "Shake all ingredients with ice. Strain into a tiki mug over crushed ice. Garnish with a pineapple leaf and cherry.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "White Rum", Amount = "1", Unit = "oz" },
                    new() { Name = "Dark Rum", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Blue Curaçao", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Pineapple Juice", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Cream of Coconut", Amount = "0.5", Unit = "oz" }
                }
            },
            new() {
                Name = "Illegal", GlassType = "Coupe", IsCanonical = true,
                Description = "A smoky mezcal sour with maraschino and lime.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Mezcal", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Maraschino Liqueur", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.25", Unit = "oz" }
                }
            },
            new() {
                Name = "Jungle Bird", GlassType = "Rocks", IsCanonical = true,
                Description = "A bitter, tropical Tiki drink with Campari and rum.",
                Instructions = "Shake all ingredients with ice. Strain into a rocks glass over ice. Garnish with a pineapple leaf.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Dark Rum", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Campari", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Pineapple Juice", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.5", Unit = "oz" }
                }
            },
            new() {
                Name = "Missionary's Downfall", GlassType = "Rocks", IsCanonical = true,
                Description = "Donn Beach's tropical rum blend with peach and fresh mint.",
                Instructions = "Blend all ingredients with crushed ice until smooth. Pour into a rocks glass. Garnish with a mint sprig.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Light Rum", Amount = "1", Unit = "oz" },
                    new() { Name = "Peach Schnapps", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Honey Syrup", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Fresh Mint", Amount = "6", Unit = "leaves" },
                    new() { Name = "Pineapple Juice", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.5", Unit = "oz" }
                }
            },
            new() {
                Name = "Naked and Famous", GlassType = "Coupe", IsCanonical = true,
                Description = "A modern equal-parts cocktail with mezcal, Aperol, and Chartreuse.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Mezcal", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Aperol", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Yellow Chartreuse", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.75", Unit = "oz" }
                }
            },
            new() {
                Name = "New York Sour", GlassType = "Rocks", IsCanonical = true,
                Description = "A whiskey sour topped with a dramatic red wine float.",
                Instructions = "Dry shake all ingredients except wine. Add ice and shake again. Strain into a rocks glass over ice. Gently float red wine on top.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Bourbon", Amount = "2", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Egg White", Amount = "1", Unit = "whole" },
                    new() { Name = "Dry Red Wine", Amount = "0.5", Unit = "oz" }
                }
            },
            new() {
                Name = "Old Cuban", GlassType = "Coupe", IsCanonical = true,
                Description = "Audrey Saunders' sparkling rum cocktail — a mojito grown up.",
                Instructions = "Muddle mint with lime juice and syrup. Add rum and bitters. Shake with ice and strain into a coupe. Top with champagne.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Aged Rum", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "1", Unit = "oz" },
                    new() { Name = "Angostura Bitters", Amount = "2", Unit = "dashes" },
                    new() { Name = "Mint Leaves", Amount = "6", Unit = "leaves" },
                    new() { Name = "Champagne", Amount = "2", Unit = "oz" }
                }
            },
            new() {
                Name = "Paloma", GlassType = "Highball", IsCanonical = true,
                Description = "Mexico's most beloved tequila cocktail — tart, salty, grapefruity.",
                Instructions = "Salt the rim of a highball. Add tequila and lime juice over ice. Top with grapefruit soda.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Tequila", Amount = "2", Unit = "oz" },
                    new() { Name = "Grapefruit Soda", Amount = "4", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Salt", Amount = "1", Unit = "pinch" }
                }
            },
            new() {
                Name = "Paper Plane", GlassType = "Coupe", IsCanonical = true,
                Description = "A modern equal-parts sour with bourbon and Aperol.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Bourbon", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Aperol", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Amaro Nonino", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" }
                }
            },
            new() {
                Name = "Penicillin", GlassType = "Rocks", IsCanonical = true,
                Description = "Sam Ross's smoky, gingery Scotch sour — one of the great modern classics.",
                Instructions = "Shake blended Scotch, lemon, and honey-ginger syrup with ice. Strain into a rocks glass over a large cube. Float Islay Scotch on top. Garnish with candied ginger.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Blended Scotch", Amount = "2", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Honey-Ginger Syrup", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Islay Single Malt Scotch", Amount = "0.25", Unit = "oz" }
                }
            },
            new() {
                Name = "Pisco Punch", GlassType = "Coupe", IsCanonical = true,
                Description = "San Francisco's legendary 19th-century pisco and pineapple punch.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Pisco", Amount = "2", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Pineapple Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.5", Unit = "oz" }
                }
            },
            new() {
                Name = "Porn Star Martini", GlassType = "Martini", IsCanonical = true,
                Description = "A passionately fruity vanilla vodka cocktail served with a Prosecco chaser.",
                Instructions = "Shake vodka, passionfruit, vanilla, and lime with ice. Strain into a martini glass. Serve with a shot of Prosecco on the side.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Vanilla Vodka", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Passionfruit Liqueur", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Passionfruit Purée", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Prosecco", Amount = "1", Unit = "oz" }
                }
            },
            new() {
                Name = "Russian Spring Punch", GlassType = "Highball", IsCanonical = true,
                Description = "Dick Bradsell's sparkling vodka and blackcurrant long drink.",
                Instructions = "Shake vodka, crème de cassis, lemon, and syrup with ice. Strain into a highball over ice. Top with champagne.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Vodka", Amount = "1", Unit = "oz" },
                    new() { Name = "Crème de Cassis", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.25", Unit = "oz" },
                    new() { Name = "Champagne", Amount = "3", Unit = "oz" }
                }
            },
            new() {
                Name = "Sherry Cobbler", GlassType = "Highball", IsCanonical = true,
                Description = "One of the oldest American cocktails — sherry, sugar, and seasonal fruit.",
                Instructions = "Muddle orange slice with sugar. Add sherry and crushed ice. Stir. Garnish generously with fresh seasonal fruit.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Amontillado Sherry", Amount = "3", Unit = "oz" },
                    new() { Name = "Orange Slice", Amount = "2", Unit = "slices" },
                    new() { Name = "Sugar", Amount = "1", Unit = "tsp" }
                }
            },
            new() {
                Name = "South Side", GlassType = "Coupe", IsCanonical = true,
                Description = "A gin mojito — a clean, minty gin sour with bright citrus.",
                Instructions = "Muddle mint with lemon and syrup. Add gin and ice. Shake vigorously. Double strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Gin", Amount = "2", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Simple Syrup", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Fresh Mint", Amount = "6", Unit = "leaves" }
                }
            },
            new() {
                Name = "Spicy Fifty", GlassType = "Martini", IsCanonical = true,
                Description = "A chilli-spiked honey and elderflower vodka cocktail.",
                Instructions = "Muddle chilli slice in shaker. Add remaining ingredients and ice. Shake and fine strain into a chilled martini glass.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Vodka", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Elderflower Cordial", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Honey Syrup", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Red Chilli Slice", Amount = "1", Unit = "slice" }
                }
            },
            new() {
                Name = "Spritz", GlassType = "Wine", IsCanonical = true,
                Description = "Northern Italy's iconic aperitivo — bitter liqueur, Prosecco, and soda.",
                Instructions = "Fill a wine glass with ice. Add Aperol and Prosecco. Top with soda water. Garnish with an orange slice.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Aperol (or Campari or Select)", Amount = "2", Unit = "oz" },
                    new() { Name = "Prosecco", Amount = "3", Unit = "oz" },
                    new() { Name = "Soda Water", Amount = "1", Unit = "splash" }
                }
            },
            new() {
                Name = "Suffering Bastard", GlassType = "Highball", IsCanonical = true,
                Description = "A WWII hangover cure from Cairo — bourbon, gin, and ginger beer.",
                Instructions = "Build bourbon, gin, lime, and bitters over ice in a highball. Top with ginger beer. Garnish with a mint sprig and cucumber slice.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Bourbon", Amount = "1", Unit = "oz" },
                    new() { Name = "Gin", Amount = "1", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Angostura Bitters", Amount = "2", Unit = "dashes" },
                    new() { Name = "Ginger Beer", Amount = "4", Unit = "oz" }
                }
            },
            new() {
                Name = "Three Dots and a Dash", GlassType = "Tiki Mug", IsCanonical = true,
                Description = "Donn Beach's Victory cocktail — Morse code for 'V'. Complex, tropical, and warming.",
                Instructions = "Shake all ingredients with ice. Strain into a tiki mug over crushed ice. Garnish with three cherries and a pineapple chunk (... -)",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Rhum Agricole", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Cognac", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Orange Juice", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Falernum", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Allspice Dram", Amount = "0.25", Unit = "oz" },
                    new() { Name = "Honey Syrup", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Angostura Bitters", Amount = "2", Unit = "dashes" }
                }
            },
            new() {
                Name = "Tipperary", GlassType = "Coupe", IsCanonical = true,
                Description = "A robust Irish whiskey cocktail with Chartreuse and sweet vermouth.",
                Instructions = "Stir all ingredients over ice. Strain into a chilled coupe. Garnish with an orange twist.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Irish Whiskey", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Sweet Vermouth", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Green Chartreuse", Amount = "0.25", Unit = "oz" },
                    new() { Name = "Orange Bitters", Amount = "2", Unit = "dashes" }
                }
            },
            new() {
                Name = "Tommy's Margarita", GlassType = "Rocks", IsCanonical = true,
                Description = "Julio Bermejo's agave-forward Margarita — no triple sec needed.",
                Instructions = "Shake all ingredients with ice. Strain into a salt-rimmed rocks glass over ice.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "100% Agave Tequila", Amount = "2", Unit = "oz" },
                    new() { Name = "Lime Juice", Amount = "1", Unit = "oz" },
                    new() { Name = "Agave Syrup", Amount = "0.5", Unit = "oz" }
                }
            },
            new() {
                Name = "Trinidad Sour", GlassType = "Coupe", IsCanonical = true,
                Description = "An Angostura-forward sour where bitters are the star — not the accent.",
                Instructions = "Shake all ingredients with ice. Strain into a chilled coupe.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Angostura Bitters", Amount = "1", Unit = "oz" },
                    new() { Name = "Rye Whiskey", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Orgeat", Amount = "1", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" }
                }
            },
            new() {
                Name = "Ve.N.To", GlassType = "Rocks", IsCanonical = true,
                Description = "A grappa-based cocktail showcasing Italian Alpine flavors.",
                Instructions = "Shake all ingredients with ice. Strain into a rocks glass over ice. Garnish with a lemon peel.",
                Ingredients = new List<CocktailIngredient> {
                    new() { Name = "Grappa", Amount = "1.5", Unit = "oz" },
                    new() { Name = "Elderflower Cordial", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Lemon Juice", Amount = "0.75", Unit = "oz" },
                    new() { Name = "Honey Syrup", Amount = "0.5", Unit = "oz" },
                    new() { Name = "Still Water", Amount = "1", Unit = "oz" }
                }
            }
        };

        db.Cocktails.AddRange(cocktails);
        db.SaveChanges();
    }
}
