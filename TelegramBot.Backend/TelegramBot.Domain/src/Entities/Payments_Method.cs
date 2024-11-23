using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Payments_Method
    {
        [Key]
        public int id_payments_method { get; set; }
        public string? payments_method_name { get; set; }
        public ICollection<Payments> Payments { get; set; }
    }
}