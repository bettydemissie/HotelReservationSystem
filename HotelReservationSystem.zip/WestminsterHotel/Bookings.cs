using System;
using System.Collections.Generic;
using WestminsterHotel;

namespace WestminsterHotel
{
    public class Bookings : IOverlappable
    {
        private int roomNumber;
        private DateTime Checkin;
        private DateTime Checkout;

        public Bookings(int roomNumber, DateTime Checkin, DateTime Checkout)
        {
            this.Checkin = Checkin;
            this.Checkout = Checkout;
            this.roomNumber = roomNumber;
        }
        
        public int GetRoomNumber()
        {
            return roomNumber;
        }

        public DateTime GetCheckin()
        {
            return Checkin;
        }

        public DateTime GetCheckout()
        {
            return Checkout;
        }

        public void Checkdates(DateTime Checkin, DateTime Checkout)
        {
            if (Checkout > Checkin)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("invalid");
            }
        }

        public bool Overlaps(Bookings other)
        {
            //conditions which would mean two bookings are overlapping each other

            bool startTimeOverlap = other.Checkin >= Checkin && other.Checkin < Checkout;

            bool endTimeOverlap = other.Checkout > Checkin && other.Checkout <= Checkout;

            bool enclosingOverlap = other.Checkin <= Checkin && other.Checkout >= Checkout;

            if (startTimeOverlap || endTimeOverlap || enclosingOverlap)
            {
                
                return true;
            }
            else
            {
                return false;
            }

        }

        public override string ToString()
        {
            return $"Booking: \n" +
                $"Check in: {GetCheckin()}\n" +
                $"Check out: {GetCheckout()}\n";
        }
    }
}

