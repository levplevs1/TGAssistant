using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Reading_History
    {
        [Key]
        public int id_reading_history {  get; set; }
        public DateTime? reading_date { get; set; }
        public string? reading_value { get; set; }
        [ForeignKey("Meters")]
        public int? id_meters { get; set; }
        public Meters Meters { get; set; }
        [ForeignKey("Housing_And_Communal_Services")]
        public int? id_housing_and_communal_services { get; set; }
        public Housing_And_Communal_Services Housing_And_Communal_Services { get; set; }
    }
}
