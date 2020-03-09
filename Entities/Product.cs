namespace Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Сomposition { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }
    }
}
