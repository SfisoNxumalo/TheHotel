using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHotel.Domain.DTOs
{
    public class CartItems
    {
        public List<CartItem> cartItems { get; set; }

    }

    public class CartItem
    {
        public required Guid Id { get; set; }
        public required string ItemName { get; set; } = null!;

        public required decimal Price { get; set; }

        public required int Quantity { get; set;}

        public required string note { get; set; }
    }
}
