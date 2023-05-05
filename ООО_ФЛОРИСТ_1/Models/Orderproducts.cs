using System;
using System.Collections.Generic;

namespace ООО_ФЛОРИСТ_1.Models
{
    public partial class Orderproducts
    {
        public int OrderId { get; set; }
        public int OrderProductCount { get; set; }
        public string ProductArticleNumber { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products ProductArticleNumberNavigation { get; set; }
    }
}
