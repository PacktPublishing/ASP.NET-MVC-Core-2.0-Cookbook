public class Recipe
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int IdBook { get; set; }

    public virtual Book IdBookNavigation { get; set; }
}