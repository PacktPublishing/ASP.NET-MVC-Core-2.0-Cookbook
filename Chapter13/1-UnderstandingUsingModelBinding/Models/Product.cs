using Microsoft.AspNetCore.Mvc;

public class Product
{
    public int Id { get; set; }
    public int Name { get; set; }
    public decimal Price { get; set; }

    public Category Category { get; set; }

}

public class Category
{
    public int Id { get; set; }
    public int Name { get; set; }
}

public class Query
{
    public int ItemsPerPage { get; set; }
    public int CurrentPage { get; set; }
}

public class Headers
{
    [FromHeader]
    public string Accept { get; set; }

    [FromHeader]
    public string Referer { get; set; }

    [FromHeader(Name = "Accept-Language")]
    public string AcceptLanguage { get; set; }

    [FromHeader(Name = "User-Agent")]
    public string UserAgent { get; set; }
}
