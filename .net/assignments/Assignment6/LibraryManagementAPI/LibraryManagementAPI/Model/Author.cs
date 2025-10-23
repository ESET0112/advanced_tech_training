using System.Text.Json.Serialization;

namespace LibraryManagementAPI.Model
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }

        public string Country { get; set; }

        

    }
}
