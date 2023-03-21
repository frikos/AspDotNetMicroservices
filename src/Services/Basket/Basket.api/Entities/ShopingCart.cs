namespace Basket.api.Entities
{
    public class ShopingCart
    {
        public string userName { get; set; } = "";
        public List<ShopingCartItems> Items { get; set; } = new List<ShopingCartItems>();

        public ShopingCart()
        {
            
        }

        public ShopingCart(string username)
        {
            userName = username;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }
                return totalprice;
            }
        }
    }
}
    
    
