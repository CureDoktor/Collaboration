namespace Common.Migrations
{
    using Common.DataModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Common.Repository.ShesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Common.Repository.ShesDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Batteries.Add(new Battery(200, 1000, "battery1"));
            context.Batteries.Add(new Battery(200, 1000, "battery2"));

            context.Consumers.Add(new Consumer(100, "consumer1"));
            context.Consumers.Add(new Consumer(100, "consumer2"));
            context.Consumers.Add(new Consumer(100, "consumer3"));


            context.SolarPanels.Add(new SolarPanel(500, "solarPanel1"));
            context.SolarPanels.Add(new SolarPanel(500, "solarPanel2"));

            context.Measurements.Add(new Measurement("battery1", 200) { TimeStamp = new DateTime(2020, 9, 17, 15, 45, 00) });
            context.Measurements.Add(new Measurement("battery1", 200) { TimeStamp = new DateTime(2020, 9, 17, 15, 46, 00) });
            context.Measurements.Add(new Measurement("battery1", 200) { TimeStamp = new DateTime(2020, 9, 17, 15, 47, 00) });
            context.Measurements.Add(new Measurement("battery1", 200) { TimeStamp = new DateTime(2020, 9, 17, 15, 48, 00) });
            context.Measurements.Add(new Measurement("battery1", 200) { TimeStamp = new DateTime(2020, 9, 18, 16, 14, 12) });
            context.Measurements.Add(new Measurement("battery1", 200) { TimeStamp = new DateTime(2020, 9, 18, 16, 15, 12) });
            context.Measurements.Add(new Measurement("battery1", 200) { TimeStamp = new DateTime(2020, 9, 18, 16, 16, 12) });
            context.Measurements.Add(new Measurement("battery1", 200) { TimeStamp = new DateTime(2020, 9, 18, 16, 17, 12) });
            context.Measurements.Add(new Measurement("battery1", 200) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("battery1", 200) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("battery1", 200) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("battery1", 200) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("battery1", 200) { TimeStamp = new DateTime(2020, 9, 17, 20, 24, 18) });

            context.Measurements.Add(new Measurement("battery2", 200) { TimeStamp = new DateTime(2020, 9, 17, 15, 45, 00) });
            context.Measurements.Add(new Measurement("battery2", 200) { TimeStamp = new DateTime(2020, 9, 17, 15, 46, 00) });
            context.Measurements.Add(new Measurement("battery2", 200) { TimeStamp = new DateTime(2020, 9, 17, 15, 47, 00) });
            context.Measurements.Add(new Measurement("battery2", 200) { TimeStamp = new DateTime(2020, 9, 17, 15, 48, 00) });
            context.Measurements.Add(new Measurement("battery2", 200) { TimeStamp = new DateTime(2020, 9, 18, 16, 14, 12) });
            context.Measurements.Add(new Measurement("battery2", 200) { TimeStamp = new DateTime(2020, 9, 18, 16, 15, 12) });
            context.Measurements.Add(new Measurement("battery2", 200) { TimeStamp = new DateTime(2020, 9, 18, 16, 16, 12) });
            context.Measurements.Add(new Measurement("battery2", 200) { TimeStamp = new DateTime(2020, 9, 18, 16, 17, 12) });
            context.Measurements.Add(new Measurement("battery2", 200) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("battery2", 200) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("battery2", 200) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("battery2", 200) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("battery2", 200) { TimeStamp = new DateTime(2020, 9, 17, 20, 24, 18) });

            context.Measurements.Add(new Measurement("consumer1", 100) { TimeStamp = new DateTime(2020, 9, 17, 15, 45, 00) });
            context.Measurements.Add(new Measurement("consumer1", 100) { TimeStamp = new DateTime(2020, 9, 17, 15, 46, 00) });
            context.Measurements.Add(new Measurement("consumer1", 100) { TimeStamp = new DateTime(2020, 9, 17, 15, 47, 00) });
            context.Measurements.Add(new Measurement("consumer1", 100) { TimeStamp = new DateTime(2020, 9, 17, 15, 48, 00) });
            context.Measurements.Add(new Measurement("consumer1", 100) { TimeStamp = new DateTime(2020, 9, 18, 16, 14, 12) });
            context.Measurements.Add(new Measurement("consumer1", 100) { TimeStamp = new DateTime(2020, 9, 18, 16, 15, 12) });
            context.Measurements.Add(new Measurement("consumer1", 100) { TimeStamp = new DateTime(2020, 9, 18, 16, 16, 12) });
            context.Measurements.Add(new Measurement("consumer1", 100) { TimeStamp = new DateTime(2020, 9, 18, 16, 17, 12) });
            context.Measurements.Add(new Measurement("consumer1", 100) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("consumer1", 100) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("consumer1", 100) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("consumer1", 100) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("consumer1", 100) { TimeStamp = new DateTime(2020, 9, 17, 20, 24, 18) });

            context.Measurements.Add(new Measurement("consumer2", 100) { TimeStamp = new DateTime(2020, 9, 17, 15, 45, 00) });
            context.Measurements.Add(new Measurement("consumer2", 100) { TimeStamp = new DateTime(2020, 9, 17, 15, 46, 00) });
            context.Measurements.Add(new Measurement("consumer2", 100) { TimeStamp = new DateTime(2020, 9, 17, 15, 47, 00) });
            context.Measurements.Add(new Measurement("consumer2", 100) { TimeStamp = new DateTime(2020, 9, 17, 15, 48, 00) });
            context.Measurements.Add(new Measurement("consumer2", 100) { TimeStamp = new DateTime(2020, 9, 18, 16, 14, 12) });
            context.Measurements.Add(new Measurement("consumer2", 100) { TimeStamp = new DateTime(2020, 9, 18, 16, 15, 12) });
            context.Measurements.Add(new Measurement("consumer2", 100) { TimeStamp = new DateTime(2020, 9, 18, 16, 16, 12) });
            context.Measurements.Add(new Measurement("consumer2", 100) { TimeStamp = new DateTime(2020, 9, 18, 16, 17, 12) });
            context.Measurements.Add(new Measurement("consumer2", 100) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("consumer2", 100) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("consumer2", 100) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("consumer2", 100) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("consumer2", 100) { TimeStamp = new DateTime(2020, 9, 17, 20, 24, 18) });

            context.Measurements.Add(new Measurement("consumer3", 100) { TimeStamp = new DateTime(2020, 9, 17, 15, 45, 00) });
            context.Measurements.Add(new Measurement("consumer3", 100) { TimeStamp = new DateTime(2020, 9, 17, 15, 46, 00) });
            context.Measurements.Add(new Measurement("consumer3", 100) { TimeStamp = new DateTime(2020, 9, 17, 15, 47, 00) });
            context.Measurements.Add(new Measurement("consumer3", 100) { TimeStamp = new DateTime(2020, 9, 17, 15, 48, 00) });
            context.Measurements.Add(new Measurement("consumer3", 100) { TimeStamp = new DateTime(2020, 9, 18, 16, 14, 12) });
            context.Measurements.Add(new Measurement("consumer3", 100) { TimeStamp = new DateTime(2020, 9, 18, 16, 15, 12) });
            context.Measurements.Add(new Measurement("consumer3", 100) { TimeStamp = new DateTime(2020, 9, 18, 16, 16, 12) });
            context.Measurements.Add(new Measurement("consumer3", 100) { TimeStamp = new DateTime(2020, 9, 18, 16, 17, 12) });
            context.Measurements.Add(new Measurement("consumer3", 100) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("consumer3", 100) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("consumer3", 100) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("consumer3", 100) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("consumer3", 100) { TimeStamp = new DateTime(2020, 9, 17, 20, 24, 18) });

            context.Measurements.Add(new Measurement("solarPanel1", 250) { TimeStamp = new DateTime(2020, 9, 17, 15, 45, 00) });
            context.Measurements.Add(new Measurement("solarPanel1", 243) { TimeStamp = new DateTime(2020, 9, 17, 15, 46, 00) });
            context.Measurements.Add(new Measurement("solarPanel1", 386) { TimeStamp = new DateTime(2020, 9, 17, 15, 47, 00) });
            context.Measurements.Add(new Measurement("solarPanel1", 385) { TimeStamp = new DateTime(2020, 9, 17, 15, 48, 00) });
            context.Measurements.Add(new Measurement("solarPanel1", 400) { TimeStamp = new DateTime(2020, 9, 18, 16, 14, 12) });
            context.Measurements.Add(new Measurement("solarPanel1", 423) { TimeStamp = new DateTime(2020, 9, 18, 16, 15, 12) });
            context.Measurements.Add(new Measurement("solarPanel1", 444) { TimeStamp = new DateTime(2020, 9, 18, 16, 16, 12) });
            context.Measurements.Add(new Measurement("solarPanel1", 456) { TimeStamp = new DateTime(2020, 9, 18, 16, 17, 12) });
            context.Measurements.Add(new Measurement("solarPanel1", 286) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("solarPanel1", 500) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("solarPanel1", 466) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("solarPanel1", 369) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("solarPanel1", 289) { TimeStamp = new DateTime(2020, 9, 17, 20, 24, 18) });

            context.Measurements.Add(new Measurement("solarPanel2", 250) { TimeStamp = new DateTime(2020, 9, 17, 15, 45, 00) });
            context.Measurements.Add(new Measurement("solarPanel2", 243) { TimeStamp = new DateTime(2020, 9, 17, 15, 46, 00) });
            context.Measurements.Add(new Measurement("solarPanel2", 386) { TimeStamp = new DateTime(2020, 9, 17, 15, 47, 00) });
            context.Measurements.Add(new Measurement("solarPanel2", 385) { TimeStamp = new DateTime(2020, 9, 17, 15, 48, 00) });
            context.Measurements.Add(new Measurement("solarPanel2", 400) { TimeStamp = new DateTime(2020, 9, 18, 16, 14, 12) });
            context.Measurements.Add(new Measurement("solarPanel2", 423) { TimeStamp = new DateTime(2020, 9, 18, 16, 15, 12) });
            context.Measurements.Add(new Measurement("solarPanel2", 444) { TimeStamp = new DateTime(2020, 9, 18, 16, 16, 12) });
            context.Measurements.Add(new Measurement("solarPanel2", 456) { TimeStamp = new DateTime(2020, 9, 18, 16, 17, 12) });
            context.Measurements.Add(new Measurement("solarPanel2", 286) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("solarPanel2", 500) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("solarPanel2", 466) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("solarPanel2", 369) { TimeStamp = new DateTime(2020, 9, 19, 20, 24, 18) });
            context.Measurements.Add(new Measurement("solarPanel2", 289) { TimeStamp = new DateTime(2020, 9, 17, 20, 24, 18) });

            context.SaveChanges();
        }
    }
}
