using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Housing_And_Communal_Services
    {
        [Key]
        public int id_housing_and_communal_services { get; set; }
        public string? text_of_request { get; set; }
        public DateTime? created_at { get; set; }
        public ICollection<Type_Of_Requests> Type_Of_Requests { get; set; }
        public ICollection<Quick_Answers_hcs> Quick_Answers_hcs { get; set; }
        public ICollection<Articles_Housing_Code> Articles_Housing_Code { get; set; }
        public ICollection<Meter_Readings> Meter_Readings { get; set; }
        public ICollection<Reading_History> Reading_History { get; set; }
        public ICollection<Service_Type> Service_Type { get; set; }
        public ICollection<Tariffs> Tariffs { get; set; }
    }
}
