namespace API.DTOs.Products;

public class GetProductDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }

    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}

