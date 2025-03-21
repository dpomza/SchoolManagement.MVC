﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.MVC.Data;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public int FileNumber { get; set; } 

    //
    public IEnumerable<StudentsCourse> StudentsCourses { get; set; } = new List<StudentsCourse>();
}
