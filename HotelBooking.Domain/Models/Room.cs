using System;
using System.Collections.Generic;

namespace HotelBooking.Domain.Models
{
    public class Room
    {
        public int RoomNumber { get; }


        public Room(int number)
        {
            RoomNumber = number;

        }
    }
}
