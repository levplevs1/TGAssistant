using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Meter_Readings.Common
{
    public class Meter_ReadingsContextFactory
    {
        public static int id_meter_readings_for_delete = 3;
        public static int id_meter_readings_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Meter_Readings.AddRange(
                new Domain.src.Entities.Meter_Readings
                {
                    id_meter_readings = 1,
                    readings_value = "Alto",
                    previos_readings_value = "Rapid",
                    readings_date = DateTime.Today,
                    id_meters = 1,
                    id_housing_and_communal_services = 1
                },

                new Domain.src.Entities.Meter_Readings
                {
                    id_meter_readings = 2,
                    readings_value = "Delta",
                    previos_readings_value = "Bullet",
                    readings_date = DateTime.Today,
                    id_meters = 2,
                    id_housing_and_communal_services = 2
                },

                new Domain.src.Entities.Meter_Readings

                {
                    id_meter_readings = id_meter_readings_for_delete,
                    readings_value = "Omega",
                    previos_readings_value = "Volvo",
                    readings_date = DateTime.Today,
                    id_meters = 3,
                    id_housing_and_communal_services = 3
                },

                new Domain.src.Entities.Meter_Readings
                {
                    id_meter_readings = id_meter_readings_for_update,
                    readings_value = "Radan",
                    previos_readings_value = "General",
                    readings_date = DateTime.Today,
                    id_meters = 4,
                    id_housing_and_communal_services = 4
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(TelegramBotDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
