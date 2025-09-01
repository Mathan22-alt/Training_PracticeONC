namespace CodeFirstApproach.Models
{
    public class Product
    {
        public int Id { get; set; }  // Primary Key
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
        public Category? Category { get; set; } // Navigation property
    }
}
