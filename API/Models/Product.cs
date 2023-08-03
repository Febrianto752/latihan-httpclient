using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Product
{
    [Key]
    [Column("guid")]
    public Guid Guid { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Precision(10, 2)]
    [Column("price")]
    public decimal Price { get; set; }

    [Column("create_date")]
    public DateTime CreatedDate { get; set; }

    [Column("modified_date")]
    public DateTime ModifiedDate { get; set; }
}

