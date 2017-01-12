namespace CalendarBookingProject.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CalendarBookingProject.ProjectContext.CalendarBookingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CalendarBookingProject.ProjectContext.CalendarBookingDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var user1 = new User()
            {
                Username = "user1",
                Password = "password",
            };

            var user2 = new User()
            {
                Username = "user2",
                Password = "password",
            };
            var user3 = new User()
            {
                Username = "user3",
                Password = "password",
            };

            var users = new List<User>()
            {
                user1,user2, user3
            };

            context.Users.AddOrUpdate(users.ToArray());



            var bookings = new List<Booking>()
            {
                new Booking()
                {
                    User = user1,
                    DateFrom = DateTime.UtcNow,
                    DateTo = DateTime.UtcNow,
                },
                new Booking()
                {
                    User = user2,
                    DateFrom = DateTime.UtcNow,
                    DateTo = DateTime.UtcNow,
                },
                new Booking()
                {
                    User = user3,
                    DateFrom = DateTime.UtcNow,
                    DateTo = DateTime.UtcNow,
                }
            };

            context.Bookings.AddOrUpdate(bookings.ToArray());

        }
    }
}
