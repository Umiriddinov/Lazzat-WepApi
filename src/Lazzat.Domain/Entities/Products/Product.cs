namespace Lazzat.Domain.Entities.Product;

public class Product : Auditable
{
    public long CategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

}
