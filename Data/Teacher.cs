using System;
using System.Collections.Generic;

namespace SchoolManagement.MVC.Data;

public partial class Teacher
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int FileNumber { get; set; }

    public IEnumerable<Course> Courses { get; set; } = new List<Course>();
}
