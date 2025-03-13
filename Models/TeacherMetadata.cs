using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.MVC.Data;

public class TeacherMetadata
{
    [Required]
    [StringLength(50)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = null!;

    [Range(1, 99999)]
    [Required]
    [Display(Name = "File Number")]
    public int FileNumber { get; set; }
}

[ModelMetadataType(typeof(TeacherMetadata))]
public partial class Teacher{}