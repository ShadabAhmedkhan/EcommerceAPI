namespace EcommerceAPI.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        //public List<OrderItem> OrderItems { get; set; }
        public string UserId { get; set; }
    }
}
