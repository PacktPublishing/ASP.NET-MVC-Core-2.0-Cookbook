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
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [Range(0.01, double.MaxValue,
    ErrorMessage = "Please enter a positive number")]
    public decimal Price { get; set; }

    [Required]
    public string CategoryName { get; set; }
}
