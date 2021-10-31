using System;
using System.Collections.Generic;

namespace HotelBooking.Domain.Models
{
    public class Booking : IBooking
    {
        public string Guest { get; }
        public DateTime BookingDate { get; }
        public IList<Room> Rooms { get; }

        public Booking(string guest, DateTime bookingDate, IList<Room> rooms)
        {
            Guest = guest;
            BookingDate = bookingDate;
            Rooms = rooms;
        }
    }
}