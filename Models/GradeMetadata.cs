using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.MVC.Data;

public class GradeMetadata
{
    [Range(0, 100)]
    [Required]
    [Display(Name = "Grade Obtained")]
    public int GradeObtained { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Date Recorded")]
    public DateOnly? DateRecorded { get; set; }

    [Display(Name = "Student / Course")]
    public int StudentCourseId { get; set; }
    }

[ModelMetadataType(typeof(GradeMetadata))]
public partial class Grade{}