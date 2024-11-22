using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Requests
    {
        [Key]
        public int id_requests { get; set; }
        public string? request_text { get; set; }
        public string? response { get; set; }
        public DateTime? created_at { get; set; }
        [ForeignKey("Type_Of_Requests")]
        public int? id_type_of_requests { get; set; }
        public Type_Of_Requests Type_Of_Requests { get; set; }
        [ForeignKey("Users")]
        public int? id_users { get; set; }
        public Users Users { get; set; }
    }
}
