using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

public interface ICategoryRepository
{
    List<SelectListItem> GetCategories();
}

public class CategoryRepository : ICategoryRepository
{
    private CategoryFormData _data;
    public CategoryRepository()
    {
        _data = JsonConvert.DeserializeObject<CategoryFormData>(File.ReadAllText("CategoryJsonDataStore.json"));
    }

    public List<SelectListItem> GetCategories()
    {
        return _data.Categories.Select(x => new SelectListItem() { Text = x }).ToList();
    }
}

public class CategoryFormData
{
    public List<string> Categories { get; set; }
}
