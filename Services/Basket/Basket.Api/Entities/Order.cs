namespace Basket.Api.Entities
{
    public class Order
    {
        public Order()
        {

        }

        public Order(string userName)
        {
            this.UserName = userName;
        }

        public string UserName { get; set; }
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                if (OrderDetails is not null && OrderDetails.Any())
                    foreach (var orderDetail in OrderDetails)
                        totalPrice += orderDetail.Price;
                return totalPrice;
            }
        }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
