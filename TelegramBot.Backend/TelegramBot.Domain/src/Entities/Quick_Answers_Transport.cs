using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Quick_Answers_Transport
    {
        [Key]
        public int id_quick_answer_transport { get; set; }
        public string? quick_answer_transport_name { get; set; }
        [ForeignKey("Transport")]
        public int? id_transport { get; set; }
        public Transport Transport { get; set; }
    }
}
