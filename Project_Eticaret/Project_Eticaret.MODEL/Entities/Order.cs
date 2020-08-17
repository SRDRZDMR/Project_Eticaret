using Project_Eticaret.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Eticaret.MODEL.Entities
{
    public class Order : CoreEntity
    {
        public Order()
        {
            // Sipariş oluşturulduğunda otomatik olarak sipariş detayı nesnesi de oluşturulsun.
            OrderDetails = new List<OrderDetail>();
        }
        public Guid AppUserID { get; set; }
        public bool Confirmed { get; set; }
        // ,bir siparişi bir kullanıcı vermiş olabilir.
        public virtual AppUser AppUser { get; set; }

        // Bir siparişşin içide birden fazla ürün (sipariş) detayı olabilir.
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
