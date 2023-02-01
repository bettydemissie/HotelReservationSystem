using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WestminsterHotel
{
	public class Standardroom : Room
	{
		private int windows;

        public Standardroom(int roomNumber, int floor, Size roomSize, int price, int windows)
            :base(roomNumber, floor, roomSize, price)
        {
			this.windows = windows;
        }

		public string GetWindows()
		{
			if (windows >= 1)
			{
				return $"Windows: {windows} ";
			}

			return $"Invalid windows";
		}

        public override string ToString()
        {
			return $"Room Number: {GetRoomNumber()} \n" +
				$"Floor Number: {Getfloor()} \n" +
				$"{GetRoomSize()} \n" +
				$"Price Per Night: {GetPrice()} \n" +
				$"Room Type: Standard \n" +
				$"{GetWindows()} \n";

		}
    }
}

