using System;
using System.Collections.Generic;

namespace HotelBooking.Domain.Models
{
    public interface IBooking
    {
        string Guest { get; }
        DateTime BookingDate { get; }
        IList<Room> Rooms { get; }
    }
}