namespace UniqloProject.Models
{
    public class Catagory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
