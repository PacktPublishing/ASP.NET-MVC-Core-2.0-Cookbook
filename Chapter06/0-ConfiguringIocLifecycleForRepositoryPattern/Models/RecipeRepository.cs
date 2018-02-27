using System.Collections.Generic;
using System.Linq;

public class RecipeRepository : IRecipeRepository
{
    private readonly CookBookContext _context;

    public RecipeRepository(CookBookContext context)
    {
        _context = context;
    }

    public IEnumerable<Recipe> GetAllRecipes()
    {
        return _context.Recipes.AsEnumerable();
    }
}
