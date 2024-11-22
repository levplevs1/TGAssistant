using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Meter_Type
    {
        [Key]
        public int id_meter_type { get; set; }
        public string? meter_type_name { get; set; }
        public ICollection<Meters> Meters { get; set; }
    }
}
