using System;
using System.Collections.Generic;

namespace ООО_ФЛОРИСТ_1.Models
{
    public partial class Pickuppoints
    {
        public Pickuppoints()
        {
            Orders = new HashSet<Orders>();
        }

        public int PickUpPointId { get; set; }
        public string PickUpPointIndex { get; set; }
        public string PickUpPointName { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
