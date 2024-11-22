using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Quick_Answers_hcs
    {
        [Key]
        public int id_quick_answers_hcs { get; set; }
        public string? quick_answers_hcs_name { get; set; }
        public string? quick_answers_hcs_content { get; set; }
        [ForeignKey("Housing_And_Communal_Services")]
        public int? id_housing_and_communal_services { get; set; }
        public Housing_And_Communal_Services Housing_And_Communal_Services { get; set; }
    }
}
