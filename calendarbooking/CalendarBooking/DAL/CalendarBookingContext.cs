using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CalendarBooking.DAL
{
    public class CalendarBookingContext : DbContext
    {
        public CalendarBookingContext() : base("DefaultConnection")
        {
        }

        public DbSet<Booking> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}