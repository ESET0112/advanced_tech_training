using System;
using System.Collections.Generic;

namespace Students_Database.Models;

public partial class Course
{
    public int Id { get; set; }

    public string CourseName { get; set; } = null!;

    public int Rank { get; set; }
}
