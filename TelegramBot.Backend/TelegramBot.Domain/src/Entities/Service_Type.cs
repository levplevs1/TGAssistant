using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelegramBot.Domain.src.Entities
{
    public class Service_Type
    {
        [Key]
        public int id_service_type { get; set; }
        public string? service_type_name { get; set; }
        [ForeignKey("Housing_And_Communal_Services")]
        public int? id_housing_and_communal_services { get; set; }
        public Housing_And_Communal_Services Housing_And_Communal_Services { get; set; }
    }
}
