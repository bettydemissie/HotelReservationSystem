using System;
using System.IO;

namespace WestminsterHotel
{
    class Program 
    {
        static void Main(string[] args)
        {
            WestminsterHotel hotel = new WestminsterHotel();

            Size size1 = new Size("Single");
            Size size2 = new Size("Double");
            Size size3 = new Size("Triple");

            Room room1 = new Standardroom(1, 1, size1, 1000, 3);
            Room room2 = new Deluxeroom(2, 1, size1, 1200, 23, "mountain");
            Room room3 = new Standardroom(3, 1, size2, 1100, 2);
            Room room4 = new Standardroom(4, 1, size3, 2000, 2);
            Room room5 = new Deluxeroom(5, 2, size3, 2400, 34, "seaview");

            hotel.AddRoom(room1);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);
            hotel.AddRoom(room4);

            DateTime checkinDate = new DateTime(2023, 1, 10);
            DateTime checkoutDate = new DateTime(2023, 1, 15);
            Bookings wantedBooking = new Bookings(0, checkinDate, checkoutDate);

            DateTime checkinDate1 = new DateTime(2023, 1, 10);
            DateTime checkoutDate1 = new DateTime(2023, 1, 12);
            Bookings wantedBooking1 = new Bookings(0, checkinDate, checkoutDate);

            hotel.BookRoom(1, wantedBooking);

            bool compare = wantedBooking.Overlaps(wantedBooking1);

            if(compare == true)
            {
                Console.WriteLine("These Bookings Overlaps");
            }
            else
            {
                Console.WriteLine("These Bookings dont overlap");
            }

            while (true)
            {
                Console.WriteLine("\n--- Customer Menu ---");
                Console.WriteLine("1. View available rooms of given size");
                Console.WriteLine("2. View avaible rooms in descending order of price");
                Console.WriteLine("3. View avaible rooms of a given size and maximum price");
                Console.WriteLine("4. Book a room");
                Console.WriteLine("5. Access admin menu");
                Console.WriteLine("6. Exit \n");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        hotel.ListAvailableRooms(wantedBooking, size2);
                        break;
                    case 2:
                        hotel.ListRoomsOrderedByPrice();
                        break;
                    case 3:
                        hotel.ListAvailableRooms(wantedBooking, size1, 1300);
                        break;
                    case 4:
                        hotel.BookRoom(2, wantedBooking);
                        break;
                    case 5:
                        // Access to admin menu
                        while (true)
                        {
                            Console.WriteLine("\n--- Admin Menu ---");
                            Console.WriteLine("1. Add a room");
                            Console.WriteLine("2. Delete a room");
                            Console.WriteLine("3. List all rooms");
                            Console.WriteLine("4. List rooms ordered by price");
                            Console.WriteLine("5. Generate report");
                            Console.WriteLine("6. Go back to customer menu \n");

                            Console.Write("Enter your choice: ");
                            int adminChoice = int.Parse(Console.ReadLine());

                            switch (adminChoice)
                            {
                                case 1:
                                    hotel.AddRoom(room5);
                                    break;
                                case 2:
                                    hotel.DeleteRoom(1);
                                    break;
                                case 3:
                                    hotel.ListRooms();
                                    break;
                                case 4:
                                    hotel.ListRoomsOrderedByPrice();
                                    break;
                                case 5:
                                    hotel.GenerateReport("report.txt");
                                    Console.WriteLine("\nReport has been generated. \n");
                                    break;
                                case 6:
                                    // Go back to customer menu with 'if' statement below
                                    break;
                                default:
                                    Console.WriteLine("\nInvalid choice. Please try again.\n");
                                    break;
                            }

                            if (adminChoice == 6)
                            {
                                break;
                            }
                        }
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.\n");
                        break;
                }
            }
        }
    }
}