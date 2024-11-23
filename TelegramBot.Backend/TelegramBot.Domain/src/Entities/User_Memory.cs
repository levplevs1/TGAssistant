using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class User_Memory
    {
        [Key]
        public int id_user_memory { get; set; }
        public string? content_memory { get; set; }
        [ForeignKey("Users")]
        public int? id_users { get; set; }
        public Users Users { get; set; }
    }
}
