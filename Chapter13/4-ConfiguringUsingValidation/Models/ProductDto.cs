using System.ComponentModel.DataAnnotations;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class ProductViewModel
{
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z]{1,40}$", ErrorMessage = "The field must be a string")]
    public string Name { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive number")]
    public decimal Price { get; set; }
}
