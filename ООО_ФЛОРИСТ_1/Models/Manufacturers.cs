using System;
using System.Collections.Generic;

namespace ООО_ФЛОРИСТ_1.Models
{
    public partial class Manufacturers
    {
        public Manufacturers()
        {
            Products = new HashSet<Products>();
        }

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
