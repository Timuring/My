using System;
using System.Collections.Generic;

namespace ООО_ФЛОРИСТ_1.Models
{
    public partial class Products
    {
        public Products()
        {
            Orderproducts = new HashSet<Orderproducts>();
        }

        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public int MaxDiscountAmount { get; set; }
        public string ProductArticleNumber { get; set; }
        public decimal ProductCost { get; set; }
        public string ProductDescription { get; set; }
        public sbyte? ProductDiscountAmount { get; set; }
        public string ProductName { get; set; }
        public byte[] ProductPhoto { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string ProductStatus { get; set; }
        public int SupplierId { get; set; }
        public int UnitId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Manufacturers Manufacturer { get; set; }
        public virtual Suppliers Supplier { get; set; }
        public virtual Units Unit { get; set; }
        public virtual ICollection<Orderproducts> Orderproducts { get; set; }
    }
}
