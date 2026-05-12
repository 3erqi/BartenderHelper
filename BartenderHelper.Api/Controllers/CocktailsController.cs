using System.IO.Compression;
using System.Security.Claims;
using BartenderHelper.Api.Data;
using BartenderHelper.Api.DTOs;
using BartenderHelper.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BartenderHelper.Api.Controllers;

[ApiController]
[Route("api/cocktails")]
public class CocktailsController : ControllerBase
{
    private readonly AppDbContext _db;

    public CocktailsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Search([FromQuery] string? search)
    {
        var query = _db.Cocktails
            .Include(c => c.Owner)
            .Where(c => c.IsCanonical)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.ToLower();
            query = query.Where(c =>
                c.Name.ToLower().Contains(term) ||
                c.Description.ToLower().Contains(term) ||
                c.Ingredients.Any(i => i.Name.ToLower().Contains(term)));
        }

        var results = query
            .OrderBy(c => c.Name)
            .Select(c => new CocktailSummaryDto(
                c.Id, c.Name, c.Description,
                c.GlassType, c.IsCanonical, c.OwnerId,
                c.Owner != null ? c.Owner.Username : null))
            .ToList();

        return Ok(results);
    }

    [Authorize]
    [HttpGet("mine")]
    public IActionResult GetMine([FromQuery] string? search)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var query = _db.Cocktails
            .Include(c => c.Owner)
            .Where(c => c.OwnerId == userId)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.ToLower();
            query = query.Where(c =>
                c.Name.ToLower().Contains(term) ||
                c.Description.ToLower().Contains(term) ||
                c.Ingredients.Any(i => i.Name.ToLower().Contains(term)));
        }

        var results = query
            .OrderBy(c => c.Name)
            .Select(c => new CocktailSummaryDto(
                c.Id, c.Name, c.Description,
                c.GlassType, c.IsCanonical, c.OwnerId,
                c.Owner != null ? c.Owner.Username : null))
            .ToList();

        return Ok(results);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var cocktail = _db.Cocktails
            .Include(c => c.Ingredients)
            .Include(c => c.Owner)
            .SingleOrDefault(c => c.Id == id);

        if (cocktail is null)
            return NotFound();

        var dto = new CocktailDetailDto(
            cocktail.Id, cocktail.Name, cocktail.Description,
            cocktail.Instructions, cocktail.GlassType,
            cocktail.ImageUrl, cocktail.IsCanonical, cocktail.OwnerId,
            cocktail.Owner?.Username,
            cocktail.Ingredients.Select(i =>
                new IngredientDto(i.Id, i.Name, i.Amount, i.Unit)).ToList());

        return Ok(dto);
    }

    [Authorize]
    [HttpPost]
    public IActionResult Create(SaveCocktailRequest request)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var cocktail = new Cocktail
        {
            Name = request.Name,
            Description = request.Description,
            Instructions = request.Instructions,
            GlassType = request.GlassType,
            ImageUrl = request.ImageUrl,
            IsCanonical = false,
            OwnerId = userId,
            Ingredients = request.Ingredients.Select(i => new CocktailIngredient
            {
                Name = i.Name,
                Amount = i.Amount,
                Unit = i.Unit ?? string.Empty
            }).ToList()
        };

        _db.Cocktails.Add(cocktail);
        _db.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = cocktail.Id }, cocktail.Id);
    }

    [Authorize]
    [HttpPut("{id}")]
    public IActionResult Update(int id, SaveCocktailRequest request)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var cocktail = _db.Cocktails
            .Include(c => c.Ingredients)
            .SingleOrDefault(c => c.Id == id);

        if (cocktail is null) return NotFound();
        if (cocktail.IsCanonical) return Forbid();
        if (cocktail.OwnerId != userId) return Forbid();

        cocktail.Name = request.Name;
        cocktail.Description = request.Description;
        cocktail.Instructions = request.Instructions;
        cocktail.GlassType = request.GlassType;
        cocktail.ImageUrl = request.ImageUrl;

        _db.CocktailIngredients.RemoveRange(cocktail.Ingredients);
        cocktail.Ingredients = request.Ingredients.Select(i => new CocktailIngredient
        {
            Name = i.Name,
            Amount = i.Amount,
            Unit = i.Unit ?? string.Empty
        }).ToList();

        _db.SaveChanges();
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var cocktail = _db.Cocktails.SingleOrDefault(c => c.Id == id);

        if (cocktail is null) return NotFound();
        if (cocktail.IsCanonical) return Forbid();
        if (cocktail.OwnerId != userId) return Forbid();

        _db.Cocktails.Remove(cocktail);
        _db.SaveChanges();
        return NoContent();
    }
}
