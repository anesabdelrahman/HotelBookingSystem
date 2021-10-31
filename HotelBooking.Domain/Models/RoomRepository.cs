using System;
using System.Collections.Generic;

namespace HotelBooking.Domain.Models
{
    public class RoomRepository
    {
        public IEnumerable<Room> Rooms = new List<Room>
        {
            new Room(101),
            new Room(102),
            new Room(103),
            new Room(201),
            new Room(202),
            new Room(203),

        };
    }
}
