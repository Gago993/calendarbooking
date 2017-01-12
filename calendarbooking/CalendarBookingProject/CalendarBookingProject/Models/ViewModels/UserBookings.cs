using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarBookingProject.Models.ViewModels
{
    public class UserBookings
    {
        public int NumberOfBookings { get; set; }

        public int MaxNumberOfBookingsForMonth { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }



    }

}