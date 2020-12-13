using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Reservations.Any())
                {
                    var reservationsData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/reservations.json");
                    var reservations = JsonSerializer.Deserialize<List<Reservation>>(reservationsData);

                    foreach (var item in reservations)
                    {
                        context.Reservations.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex, ex.Message);
            }
        }
    }
} 