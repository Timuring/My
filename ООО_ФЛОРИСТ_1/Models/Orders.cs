using System;
using System.Collections.Generic;

namespace ООО_ФЛОРИСТ_1.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Orderproducts = new HashSet<Orderproducts>();
        }

        public int OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public int OrderId { get; set; }
        public int OrderPickupPointId { get; set; }
        public string OrderStatus { get; set; }
        public int UserId { get; set; }

        public virtual Pickuppoints OrderPickupPoint { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Orderproducts> Orderproducts { get; set; }
    }
}
