using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Meters
    {
        [Key]
        public int id_meters {  get; set; }
        public DateTime? instalition_date { get; set; }
        public DateTime? last_reading_date { get; set; }
        [ForeignKey("Meter_Type")]
        public int? id_meter_type { get; set; }
        public Meter_Type Meter_Type { get; set; }
        [ForeignKey("Users")]
        public int? id_users { get; set; }
        public Users Users { get; set; }

    }
}
