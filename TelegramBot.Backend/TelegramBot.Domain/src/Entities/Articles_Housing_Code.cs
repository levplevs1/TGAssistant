using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Domain.src.Entities
{
    public class Articles_Housing_Code
    {
        [Key]
        public int id_articles_housing_code { get; set; }
        public string? articles_housing_code_name { get; set; }
        public string? articles_housing_code_content { get; set; }
        [ForeignKey("Housing_And_Communal_Services")]
        public int? id_housing_and_communal_services { get; set; }
        public Housing_And_Communal_Services Housing_And_Communal_Services { get; set; }
    }
}
