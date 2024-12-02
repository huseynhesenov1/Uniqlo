using System.ComponentModel.DataAnnotations.Schema;

namespace UniqloProject.Models;

public class Product
{
    public int Id { get; set; }

    public string Title { get; set; }
    public string ImgUrl { get; set; }
    public int Price { get; set; }
    public int NewPrice { get; set; }
    public bool IsDelete { get; set; }

    public int CatagoryId { get; set; }
    [NotMapped]
    public Catagory Catagory { get; set; }
}
