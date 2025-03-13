using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace SchoolManagement.MVC.Data;

public class StudentCourseMetadata
{
    [Display(Name = "Completed")]
    public bool Completed { get; set; }

    [Display(Name = "Course")]
    public int CourseId { get; set; }
    
    [Display(Name = "Student")]
    public int StudentId { get; set; }
}

[ModelMetadataType(typeof(StudentCourseMetadata))]
public partial class StudentsCourse{}