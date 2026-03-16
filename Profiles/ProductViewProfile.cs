namespace ProducrCQRS.Profiles
{
    public class ProductViewProfile
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        public decimal Price { set; get; }
        public string Code { set; get; }
        public Guid CategoryId { set; get; }
        public int Discount { set; get; }
        public int Quantity { set; get; }
    }
}
