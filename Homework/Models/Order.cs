namespace Homework.Models
{
    public class Order
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string BatchSizeCode { get; set; }
        public int BatchSize { get; set; }
        public int BatchQuantity { get; set; }
        public float Price { get; set; }
    }
}
