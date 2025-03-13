using System;
using System.Collections.Generic;

namespace SchoolManagement.MVC.Data;

public partial class Grade
{
    public int Id { get; set; }

    public int GradeObtained { get; set; }

    public DateOnly? DateRecorded { get; set; }
    
    //FK to StudentsCourses - Many to One
    public int StudentCourseId { get; set; }
    public StudentsCourse? StudentsCourse { get; set; } 

    // StudentCourse fullname
    public string StudentFullName => (StudentsCourse?.Student?.LastName ?? "-") + ", " + (StudentsCourse?.Student?.FirstName ?? "-");

    // Course name
    public string CourseName => StudentsCourse?.Course?.Name ?? "-";    

}
