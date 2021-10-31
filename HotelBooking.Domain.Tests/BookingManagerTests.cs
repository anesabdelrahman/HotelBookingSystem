using System;
using System.Linq;
using HotelBooking.Domain.BusinessLogic;
using HotelBooking.Domain.Models;
using NUnit.Framework;

namespace HotelBooking.Domain.Tests
{
    public class BookingManagerTests
    {
        private IBookingManager bookingManager;

        [SetUp]
        public void Setup()
        {
            bookingManager = BookingManager.GetInstance();
        }

        [Test]
        public void Should_Return_True_If_Room_Is_Available()
        {
            var room = 101;
            var date = new DateTime(2021, 10, 30);
            var isRoomAvailable = bookingManager.IsRoomAvailable(room, date);
            Assert.IsTrue(isRoomAvailable);
        }

        [Test]
        public void Should_Return_False_If_Room_Is_Not_Available()
        {
            var room = 101;
            var date = new DateTime(2021, 10, 30);
            bookingManager.AddBooking("Anes", room, date);
            var isRoomAvailable = bookingManager.IsRoomAvailable(room, date);
            Assert.IsFalse(isRoomAvailable);
        }

        [Test]
        public void Should_Throw_An_Exception_If_Attempting_Overbooking()
        {
            var room = 101;
            var date = new DateTime(2021, 10, 30);
            bookingManager.AddBooking("Anes", room, date);
            Assert.Throws<ArgumentException>(() => bookingManager.AddBooking("Anes", room, date));
        }

        [Test]
        public void Should_Return_All_Available_Rooms_If_No_Booking_For_Given_Date_()
        {
            var date = new DateTime(2021, 10, 30);
            var expectedAvailableRooms = new RoomRepository().Rooms.Select(r => r.RoomNumber);

            var availableRooms = bookingManager.getAvailableRooms(date);

            Assert.AreEqual(expectedAvailableRooms, availableRooms);
        }

        [Test]
        public void Should_Return_Other_Rooms_Except_Booked_Ones()
        {
            var room = 101;
            var date = new DateTime(2021, 10, 30);
            bookingManager.AddBooking("Anes", room, date);
            var expectedAvailableRooms = new RoomRepository().Rooms.Select(r => r.RoomNumber).Where(i => i != room);

            var availableRooms = bookingManager.getAvailableRooms(date);

            Assert.AreEqual(expectedAvailableRooms, availableRooms);
        }
    }
}
