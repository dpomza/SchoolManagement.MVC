﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.MVC.Data;

public partial class Course
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Code { get; set; }

    // One to Many to StudentsCourses
    public IEnumerable<StudentsCourse> StudentsCourses { get; set; } = new List<StudentsCourse>();
    
    //FK to Teachers - Many to One
    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; } 
}
