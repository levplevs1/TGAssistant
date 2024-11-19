using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Users
    {
        [Key]
        public int id_users { get; set; }
        public double? id_telegram {  get; set; }
        public string? name { get; set; }
        public string? lastname { get; set; }
        public string? username { get; set; }
        public DateTime? created_at { get; set; }
        public ICollection<Meters> Meters { get; set; }
        public ICollection<Requests> Requests { get; set; }
        public ICollection<Payments> Payments { get; set; }
        public ICollection<User_Memory> User_Memory { get; set; }
    }
}
