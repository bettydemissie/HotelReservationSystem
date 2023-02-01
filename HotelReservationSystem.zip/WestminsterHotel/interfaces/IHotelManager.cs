using System;
namespace WestminsterHotel
{
	public interface IHotelManager
	{
        public bool AddRoom(Room room);

        bool DeleteRoom(int roomNumber);

        void ListRooms();

        void ListRoomsOrderedByPrice();

        void GenerateReport(string fileName);

    }
}

