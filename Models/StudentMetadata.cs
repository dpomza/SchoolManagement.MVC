using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.MVC.Data;

public class StudentMetadata
{
    [Required]
    [StringLength(50)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    public DateOnly? DateOfBirth { get; set; }

    [Range(1, 99999)]
    [Required]
    [Display(Name = "File Number")]
    public int FileNumber { get; set; } 
}

[ModelMetadataType(typeof(StudentMetadata))]
public partial class Student{}