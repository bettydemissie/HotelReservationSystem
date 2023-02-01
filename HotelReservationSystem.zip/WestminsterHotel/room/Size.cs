using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace WestminsterHotel
{
    public class Size
    {
        private string roomSize;

        public Size(string roomSize)
        {
            this.roomSize = roomSize;
        }

        public string RoomSize()
        {
            return roomSize;
        }

        public override string ToString()
        {
            return $"Room Size: {roomSize}";
           
           
        }
    }
            
}

