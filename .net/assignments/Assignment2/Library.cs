using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2
{
    internal class Library
    {
        int bookId;
        string title;
        string author;
        bool isIssued;

        public Library(int bookId, string title, string author, bool isIssued)
        {
            this.bookId = bookId;
            this.title = title;
            this.author = author;
            this.isIssued = isIssued;
        }
        public void IssueBook()
        {
            if (isIssued)
            {
                Console.WriteLine("Book previously issued");
            }
            else
            {
                isIssued = true;
                Console.WriteLine("Book issued successfully");
            }


        }
        public void ReturnBook() 
        {
             Console.WriteLine("Book returned successfully");
             isIssued = false;
        } 
        public void DisplayBookDetails()
        {
            Console.WriteLine("BookID: " + bookId);
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Isissued: " + isIssued);


        }
    }
}
