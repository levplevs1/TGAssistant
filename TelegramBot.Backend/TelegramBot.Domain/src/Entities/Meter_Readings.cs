using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Meter_Readings
    {
        [Key]
        public int id_meter_readings { get; set; }
        public string? readings_value { get; set; }
        public string? previos_readings_value { get; set; }
        public DateTime? readings_date { get; set; }
        [ForeignKey("Meters")]
        public int? id_meters { get; set; }
        public Meters Meters { get; set; }
        [ForeignKey("Housing_And_Communal_Services")]
        public int? id_housing_and_communal_services { get; set; }
        public Housing_And_Communal_Services Housing_And_Communal_Services { get; set; }
    }
}
