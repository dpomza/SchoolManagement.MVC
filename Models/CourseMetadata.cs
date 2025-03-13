using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.MVC.Data;

public class CourseMetadata
{
    [Required]
    [StringLength(50)]
    [Display(Name = "Course Name")]
    public string Name { get; set; } = null!;

    [Range(1, 9999)]
    [Required]
    [Display(Name = "Course Code")]
    public int Code { get; set; } 

    [Display(Name = "Teacher")]
    public int TeacherId { get; set; }
}

[ModelMetadataType(typeof(CourseMetadata))]
public partial class Course{}