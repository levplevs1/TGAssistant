using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Payments
    {
        [Key]
        public int id_payments { get; set; }
        public DateTime? payments_date { get; set; }
        public double? amount { get; set; }
        [ForeignKey("Users")]
        public int? id_users { get; set; }
        public Users Users { get; set; }
        [ForeignKey("Payments_Method")]
        public int? id_payments_method { get; set; }
        public Payments_Method Payments_Method { get; set; }
        [ForeignKey("Service_Type")]
        public int? id_service_type { get; set; }
        public Service_Type Service_Type { get; set; }

    }
}
