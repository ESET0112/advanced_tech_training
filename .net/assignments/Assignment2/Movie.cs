using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2
{
    internal class Movie
    {
        string movieName;
        int totalSeats;
        int bookedSeats;
        int availableSeats;

        public Movie(string movieName, int totalSeats,int bookedSeats)
        {
            this.movieName = movieName;
            this.totalSeats = totalSeats;
            this.bookedSeats = bookedSeats;
            this.availableSeats = totalSeats;
        }
        public void BookSeats(int number)
        {
            if (number <= availableSeats)
            {
                bookedSeats += number;
                availableSeats -= number;
                Console.WriteLine(number + " Movie tickets Booked");
            }
            else
            {
                Console.WriteLine(number + " tickets not available");
            }
            
        }
        public void CancelSeats(int number)
        {
            if (number <= bookedSeats)
            {
                bookedSeats -= number;
                availableSeats += number;
                Console.WriteLine(number + " Movie tickets Canceled");
            }
            else
            {
                Console.WriteLine(number + " is more than movie tickets booked");
            }
            
        }
        public void DisplayAvailableSeats()
        {
            Console.WriteLine("Movie Name: " + movieName);
            Console.WriteLine("Total Seats: " + totalSeats);
            Console.WriteLine("Booked seats: " + bookedSeats);
            Console.WriteLine("available seats: " + availableSeats);


        }
    }
}
