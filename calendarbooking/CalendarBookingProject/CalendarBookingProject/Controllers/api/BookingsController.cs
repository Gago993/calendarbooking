using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CalendarBookingProject.Models;
using CalendarBookingProject.ProjectContext;
using System.Web;
using CalendarBookingProject.Classes;

namespace CalendarBookingProject.Controllers.api
{
    public class BookingsController : ApiController
    {
        private CalendarBookingDbContext db = new CalendarBookingDbContext();

        // GET: api/Bookings
        public IHttpActionResult GetBookings()
        {
            if (UserManager.IsSingedIn())
            {
                return BadRequest();
            }

            DateTime timeNow = DateTime.UtcNow;
            IQueryable<Booking> bookings = db.Bookings.Where(b => b.DateFrom.Year == timeNow.Year && b.DateFrom.Month == timeNow.Month);

            return Ok(bookings);
        }

        // POST: api/Bookings
        [ResponseType(typeof(Booking))]
        public async Task<IHttpActionResult> PostBooking(Booking booking)
        {
            if (UserManager.IsSingedIn())
            {
                return BadRequest();
            }

            DateTime timeNow = DateTime.UtcNow;
            int countUserBookings = db.Bookings.Where(b => b.UserID == UserManager.User.UserID && b.DateFrom.Year == timeNow.Year && b.DateTo.Month == timeNow.Month).Count();

            if(countUserBookings >= 3)
            {
                return BadRequest("You alredy have 3 bookings for this month");
            }

            /*
            if (!DateHelper.DateFromCurrentMonth(booking.DateFrom, booking.DateTo, timeNow) ||
            !DateHelper.DateThirdValidator(booking.DateFrom, booking.DateTo))
            {
                return BadRequest("Invalid Date");
            }
            */

            IEnumerable<Booking> bookingsForGivenDate = db.Bookings.Where(b => 
            (b.DateFrom.Year == timeNow.Year && b.DateFrom.Month == timeNow.Month && b.DateFrom.Day == booking.DateFrom.Day)
            && (b.DateTo.Year == timeNow.Year && b.DateTo.Month == timeNow.Month && b.DateTo.Day == booking.DateTo.Day));

            foreach(Booking dayBooking in bookingsForGivenDate)
            {
                if (DateHelper.EqualDateTime(dayBooking.DateFrom, booking.DateFrom) || DateHelper.EqualDateTime(dayBooking.DateTo, booking.DateTo)) {
                    return BadRequest("This is alredy booked");
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bookings.Add(booking);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = booking.ID }, booking);
        }


        //// GET: api/Bookings/5
        //[ResponseType(typeof(Booking))]
        //public async Task<IHttpActionResult> GetBooking(int id)
        //{
        //    Booking booking = await db.Bookings.FindAsync(id);
        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(booking);
        //}

        //// PUT: api/Bookings/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutBooking(int id, Booking booking)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != booking.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(booking).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookingExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}


        //// DELETE: api/Bookings/5
        //[ResponseType(typeof(Booking))]
        //public async Task<IHttpActionResult> DeleteBooking(int id)
        //{
        //    Booking booking = await db.Bookings.FindAsync(id);
        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Bookings.Remove(booking);
        //    await db.SaveChangesAsync();

        //    return Ok(booking);
        //}

        //private bool BookingExists(int id)
        //{
        //    return db.Bookings.Count(e => e.ID == id) > 0;
        //}


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ApplicationSignInManager UserManager
        {
            get
            {
                return new ApplicationSignInManager(HttpContext.Current);
            }
        }

    }
}