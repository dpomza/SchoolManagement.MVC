using System;
using System.Collections.Generic;

namespace SchoolManagement.MVC.Data;

public partial class StudentsCourse
{
    public int Id { get; set; }

    public bool Completed { get; set; }

    //FK to Courses - Many to One
    public int CourseId { get; set; }
    public Course? Course { get; set; }

    //FK to Grades - One to Many
    public IEnumerable<Grade> Grades { get; set; } = new List<Grade>();
    
    //FK to Students - Many to One
    public int StudentId { get; set; }
    public Student? Student { get; set; } 

 
}
