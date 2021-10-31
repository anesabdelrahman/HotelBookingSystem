using System;
using System.Collections.Generic;
using System.Linq;
using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.BusinessLogic
{
    public class BookingManager : IBookingManager
    {
        private static readonly BookingManager _bookingManagerInstance = new BookingManager();
        private RoomRepository _roomsRepository;
        private IList<IBooking> _bookings;

        private BookingManager()
        {
            _roomsRepository = new RoomRepository();
            _bookings = new List<IBooking>();
        }

        public static BookingManager GetInstance() => _bookingManagerInstance;


        public void AddBooking(string guest, int room, DateTime date)
        {
            if (!IsRoomAvailable(room, date))
            {
                throw new ArgumentException($"Room: {room} is not available on the {date}");
            }

            _bookings.Add(new Booking(guest, date, new List<Room> { new Room(room) }));
        }

        public IEnumerable<int> getAvailableRooms(DateTime date)
        {
            var availableRoomNumbers = _roomsRepository.Rooms.Select(r => r.RoomNumber);

            if (_bookings.Any(b => b.BookingDate == date))
            {
                availableRoomNumbers = availableRoomNumbers.Except(_bookings.FirstOrDefault(i => i.BookingDate == date).Rooms.Select(r => r.RoomNumber));
            }

            return availableRoomNumbers;
        }

        public bool IsRoomAvailable(int room, DateTime date)
        {
            return !_bookings.Any(r => r.BookingDate == date && r.Rooms.Any(r => r.RoomNumber == room));
        }
    }
}
