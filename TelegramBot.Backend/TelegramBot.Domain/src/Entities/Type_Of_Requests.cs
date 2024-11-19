using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Type_Of_Requests
    {
        [Key]
        public int id_type_of_requests { get; set; }
        [ForeignKey("Housing_And_Communal_Services")]
        public int? id_housing_and_communal_services { get; set; }
        public Housing_And_Communal_Services Housing_And_Communal_Services { get; set; }
        [ForeignKey("Healthcare")]
        public int? id_healthcare { get; set; }
        public Healthcare Healthcare { get; set; }
        [ForeignKey("Transport")]
        public int? id_transport { get; set; }
        public Transport Transport { get; set; }
        [ForeignKey("Education")]
        public int? id_education { get; set; }
        public Education Education { get; set; }
    }
}
