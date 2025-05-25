using System.ComponentModel.DataAnnotations;

namespace CW_9_s31383.Models;

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }
    [Required]
    [MaxLength(100)] 
    public string FirstName { get; set; } = null!;
    [Required]
    [MaxLength(100)] 
    public string LastName { get; set; } = null!;
    [Required]
    [MaxLength(100)] 
    public string Email { get; set; } = null!;
}