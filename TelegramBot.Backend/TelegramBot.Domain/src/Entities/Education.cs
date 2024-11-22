using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Education
    {
        [Key]
        public int id_education {  get; set; }
        public string? text_of_request { get; set; }
        public DateTime? created_at { get; set; }
        public ICollection<Type_Of_Requests> Type_Of_Requests { get; set; }
        public ICollection<Quick_Answers_Education> Quick_Answers_Education { get; set; }
    }
}
