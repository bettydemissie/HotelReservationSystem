using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace WestminsterHotel
{
	public class Room : IComparable<Room>
	{
		private int roomNumber;
		private int floor;
		private Size roomSize;
		private int price;
        private List<Bookings> bookings;

		public Room(int roomNumber, int floor, Size roomSize, int price)
		{
			this.roomNumber = roomNumber;
			this.floor = floor;
			this.roomSize = roomSize;
			this.price = price;
			this.bookings = new List<Bookings>();
        }

		public int GetRoomNumber()
		{
			return roomNumber;
		}

		public int Getfloor()
		{
			return floor;
		}

        public Size GetRoomSize()
        {
            return roomSize;
        }

		public int GetPrice()
		{
			return price;
		}

        public List<Bookings> GetBookings()
        {
				return bookings;
        }

        public void AddBooking(Bookings booking)
        {
			bookings.Add(booking);
        }

		public bool CheckBookingExists(Bookings otherbooking)
		{
			//Will method be used in the clas WestminsterHotel to support the use of method Listavaibalerooms
			foreach(Bookings booking in bookings)
			{
				if (booking.Overlaps(otherbooking))
				{
					return false;
				}
				
			}
				return true;
		}
		public int CompareTo(Room other)
		{
            {
				if (GetPrice() < other.GetPrice())
					return -1;
				
				else if (GetPrice() > other.GetPrice())
					return 1;
				
				else
					return 0;
            }
        }

        public override string ToString()
		{
			return $"Room Number: {GetRoomNumber()} \n" +
				$"Floor Number: {Getfloor()} \n" +
				$"{GetRoomSize()} \n" +
				$"Price Per Night: {GetPrice()} \n";

        }
    }
}