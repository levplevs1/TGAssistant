using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Quick_Answers_Healthcare
    {
        [Key]
        public int id_quick_answer_healthcare { get; set; }
        public string? quick_answer_healthcare_name { get; set; }
        [ForeignKey("Healthcare")]
        public int? id_healthcare { get; set; }
        public Healthcare Healthcare { get; set; }
    }
}
