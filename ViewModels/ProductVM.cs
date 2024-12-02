using System.ComponentModel.DataAnnotations.Schema;
using UniqloProject.Models;

namespace UniqloProject.ViewModels;

public class ProductVM
{
   

    public string Title { get; set; }
    public string ImgUrl { get; set; }
    public int Price { get; set; }
    public int NewPrice { get; set; }
     

    public int CatagoryId { get; set; }
   
}
