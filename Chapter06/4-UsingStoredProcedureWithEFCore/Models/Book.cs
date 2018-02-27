using System.Collections.Generic;

public class Book
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; }
}
