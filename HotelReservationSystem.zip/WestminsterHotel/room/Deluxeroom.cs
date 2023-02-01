using System;
using System.Diagnostics;
using System.Drawing;

namespace WestminsterHotel
{
    public class Deluxeroom : Room
    {
        private int balconysize;
        private string view;

        public Deluxeroom(int roomNumber, int floor, Size roomSize, int price, int balconysize, string view)
            : base(roomNumber, floor, roomSize, price)
        {
            this.balconysize = balconysize;
            this.view = view;
            
        }

        public int GetBalconySize()
        {
            return balconysize;
        }

        public string GetView()
        {
            return view;
        }
        
        public override string ToString()
        {
            return $"Room Number: {GetRoomNumber()} \n" +
                $"Floor Number: {Getfloor()} \n" +
                $"{GetRoomSize()} \n" +
                $"Price Per Night: {GetPrice()} \n" +
                $"Room Type: Deluxe \n" +
                $"Balcony Size: {GetBalconySize()} m\u00B2 \n" +
                $"Balcony View: {GetView()} \n";
        }
    }
}


