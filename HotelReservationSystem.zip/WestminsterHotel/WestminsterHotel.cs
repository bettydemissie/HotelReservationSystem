using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Text;

namespace WestminsterHotel
{
	 class WestminsterHotel : IHotelCustomer, IHotelManager
	 {

        private List<Room> rooms;


        public WestminsterHotel()
        {
            rooms = new List<Room>();
        }
        
        public bool AddRoom(Room room)
        {
            if (rooms.Count != 0)
            {
                foreach (Room r in rooms)
                {
                    if (room.GetRoomNumber() == r.GetRoomNumber())
                    {
                        return false;

                    }
                    else
                    {
                        rooms.Add(room);
                        return true;
                    }
                }
            }
            else
            {
                rooms.Add(room);
            }
                return false;
        }

        public bool DeleteRoom(int roomNumber)
        {
            //https://stackoverflow.com/questions/47575676/how-can-i-remove-a-room-in-arraylist-room-by-name
            //find the room by room number
            //then remove the room once you find it

            if (rooms.Any(r => r.GetRoomNumber() == roomNumber))
            {
               rooms.Remove(rooms.First(r => r.GetRoomNumber() == roomNumber));
               return true;
            }
            else
            {
               return false;
            }
        }

        public void ListRooms()
        {
           foreach(Room room in rooms)
           {
               Console.WriteLine(room);
                foreach(Bookings booking in room.GetBookings())
                {
                    Console.WriteLine(booking);
                }
           }
        }

        public void ListRoomsOrderedByPrice()
        {
            // Make a copy of the rooms list
            List<Room> roomsCopy = new List<Room>(rooms);

            //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
            // Sort the copy of the list using the Sort method and a lambda expression
            roomsCopy.Sort((r1, r2) => r2.GetPrice().CompareTo(r1.GetPrice()));

            foreach (Room room in roomsCopy)
            {
                Console.WriteLine(room.ToString());
            }
        }

        public void GenerateReport(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                foreach (Room Room in rooms)
                {
                    writer.WriteLine(Room);
                }
            }
        }

        public void ListAvailableRooms(Bookings wantedBooking, Size roomSize)
        {
            foreach (Room room in rooms)
            {
                if ((room.GetRoomSize().RoomSize() == roomSize.RoomSize()) && room.CheckBookingExists(wantedBooking))
                { 
                    Console.WriteLine(room);
                }

            }

        }

        public void ListAvailableRooms(Bookings wantedBooking, Size roomSize, int maxPrice)
        {
            //https://stackoverflow.com/questions/3738639/sorting-a-listint
            //create a new list that satisfies the condiitons of the method then read through the new list and print values

            List<Room> orderedRooms = rooms.Where(Room => Room.GetRoomSize().RoomSize() == roomSize.RoomSize() && Room.CheckBookingExists(wantedBooking) && Room.GetPrice() < maxPrice)
                                           .OrderBy(room => room.GetPrice())
                                           .ToList();
            foreach (Room room in orderedRooms)
            {
                Console.WriteLine(room);
            }
        }

        public bool BookRoom(int roomNumber, Bookings wantedBooking)
        {
            //https://stackoverflow.com/questions/16164235/how-to-get-first-object-out-from-listobject-using-linq

            Room room = rooms.First(r => r.GetRoomNumber() == roomNumber);

            foreach (var b in room.GetBookings())
            {
                if (b.Overlaps(wantedBooking))
                {
                    // The room is not available for the given time period
                    // so return false
                    return false;
                }
            }
            // The room is available, so add the booking to the list of bookings
            //and return true

            room.AddBooking(wantedBooking);
            return true;
        }

  
     }
}

