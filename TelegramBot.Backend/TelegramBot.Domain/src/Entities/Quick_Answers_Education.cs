using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Quick_Answers_Education
    {
        [Key]
        public int id_quick_answer_education {  get; set; }
        public string? quick_answer_education_name { get; set; }
        [ForeignKey("Education")]
        public int? id_education { get; set; }
        public Education Education { get; set; }
    }
}
