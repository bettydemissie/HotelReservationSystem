using System;
using System.Drawing;

namespace WestminsterHotel
{
	public interface IHotelCustomer
	{
        void ListAvailableRooms(Bookings wantedBooking, Size roomSize);

        void ListAvailableRooms(Bookings wantedBooking, Size roomSize, int maxPrice);

        bool BookRoom(int roomNumber, Bookings wantedBooking);

    }
}

