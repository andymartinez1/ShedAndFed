using ShedAndFed.Entities;

namespace ShedAndFed.Data;

public class SeedDatabase
{
    public async Task SeedDatabaseAsync(ReptileDbContext context)
    {
        // Seed Reptiles
        if (!context.Reptiles.Any())
        {
            var reptiles = new[]
            {
                new Reptile
                {
                    Name = "Spike",
                    Species = "Bearded Dragon",
                    Sex = "Male",
                    DateOfBirth = new DateTime(2023, 7, 5),
                    AcquiredDate = new DateTime(2024, 1, 15)
                },
                new Reptile
                {
                    Name = "Luna",
                    Species = "Ball Python",
                    Morph = "Spider",
                    Sex = "Female",
                    DateOfBirth = new DateTime(2022, 9, 25),
                    AcquiredDate = new DateTime(2024, 3, 20)
                },
                new Reptile
                {
                    Name = "Rex",
                    Species = "Leopard Gecko",
                    Sex = "Male",
                    DateOfBirth = new DateTime(2024, 3, 1),
                    AcquiredDate = new DateTime(2025, 6, 10)
                }
            };

            context.Reptiles.AddRange(reptiles);
            await context.SaveChangesAsync();
        }

        var spike = context.Reptiles.First(r => r.Name == "Spike");
        var luna = context.Reptiles.First(r => r.Name == "Luna");
        var rex = context.Reptiles.First(r => r.Name == "Rex");

        // Seed Feeding Logs
        if (!context.FeedingLogs.Any())
        {
            var logs = new[]
            {
                new FeedingLog
                {
                    ReptileId = spike.ReptileId,
                    Date = DateTime.Now.AddDays(-2),
                    FoodType = "Crickets",
                    WasEaten = true
                },
                new FeedingLog
                {
                    ReptileId = spike.ReptileId,
                    Date = DateTime.Now.AddDays(-5),
                    FoodType = "Mealworms",
                    WasEaten = false
                },
                new FeedingLog
                {
                    ReptileId = luna.ReptileId,
                    Date = DateTime.Now.AddDays(-7),
                    FoodType = "Frozen Mouse",
                    WasEaten = true
                },
                new FeedingLog
                {
                    ReptileId = rex.ReptileId,
                    Date = DateTime.Now.AddDays(-1),
                    FoodType = "Crickets",
                    WasEaten = true
                }
            };

            context.FeedingLogs.AddRange(logs);
            await context.SaveChangesAsync();
        }

        // Seed Shed Logs
        if (!context.ShedLogs.Any())
        {
            var shedLogs = new[]
            {
                new ShedLog
                {
                    ReptileId = spike.ReptileId,
                    Date = DateTime.Now.AddDays(-10),
                    FullShed = true
                },
                new ShedLog
                {
                    ReptileId = luna.ReptileId,
                    Date = DateTime.Now.AddDays(-14),
                    FullShed = true
                },
                new ShedLog
                {
                    ReptileId = rex.ReptileId,
                    Date = DateTime.Now.AddDays(-8),
                    FullShed = false
                }
            };

            context.ShedLogs.AddRange(shedLogs);
            await context.SaveChangesAsync();
        }

        // Seed Waste Logs
        if (!context.WasteLogs.Any())
        {
            var wasteLogs = new[]
            {
                new WasteLog
                {
                    ReptileId = spike.ReptileId,
                    Date = DateTime.Now.AddDays(-3),
                    Type = "Both"
                },
                new WasteLog
                {
                    ReptileId = luna.ReptileId,
                    Date = DateTime.Now.AddDays(-6),
                    Type = "Urate"
                },
                new WasteLog
                {
                    ReptileId = rex.ReptileId,
                    Date = DateTime.Now.AddDays(-2),
                    Type = "Feces"
                }
            };

            context.WasteLogs.AddRange(wasteLogs);
            await context.SaveChangesAsync();
        }

        // Seed Growth Logs
        if (!context.GrowthLogs.Any())
        {
            var growthLogs = new[]
            {
                new GrowthLog
                {
                    ReptileId = spike.ReptileId,
                    Date = DateTime.Now.AddDays(-15),
                    WeightGrams = 150.5,
                    LengthCm = 25.0
                },
                new GrowthLog
                {
                    ReptileId = luna.ReptileId,
                    Date = DateTime.Now.AddDays(-20),
                    WeightGrams = 800.0,
                    LengthCm = 90.0
                },
                new GrowthLog
                {
                    ReptileId = rex.ReptileId,
                    Date = DateTime.Now.AddDays(-10),
                    WeightGrams = 45.0,
                    LengthCm = 18.5
                }
            };

            context.GrowthLogs.AddRange(growthLogs);
            await context.SaveChangesAsync();
        }
    }
}