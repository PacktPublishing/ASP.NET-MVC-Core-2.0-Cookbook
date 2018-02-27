using System.Collections.Generic;

public interface IRecipeRepository
{
    IEnumerable<Recipe> GetAllRecipes();
}