using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Tariffs
    {
        [Key]
        public int id_tariffs {  get; set; }
        public DateTime? effective_date { get; set; }
        public double? tariff_value { get; set; }
        [ForeignKey("Unit_Of_Tariffs")]
        public int? id_unit_of_tariffs { get; set; }
        public Unit_Of_Tariffs Unit_Of_Tariffs { get; set; }
        [ForeignKey("Service_Type")]
        public int? id_service_type { get; set; }
        public Service_Type Service_Type { get; set; }
        [ForeignKey("Housing_And_Communal_Services")]
        public int? id_housing_and_communal_services { get; set; }
        public Housing_And_Communal_Services Housing_And_Communal_Services { get; set; }
    }
}
