using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public int StatusId { get; set; }
        public int PersonId { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual Status Status { get; set; }
        public virtual Person Person { get; set; }
    }
}
