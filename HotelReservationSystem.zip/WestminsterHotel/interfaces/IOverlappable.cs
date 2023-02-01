using System;
namespace WestminsterHotel
{
	public interface IOverlappable
	{
        bool Overlaps(Bookings other);

    }
}

