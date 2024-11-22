using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Unit_Of_Tariffs
    {
        [Key]
        public int id_unit_of_tariffs { get; set; }
        public string? unit_of_tariffs_name { get; set; }
        public ICollection<Tariffs> Tariffs { get; set; }
    }
}
