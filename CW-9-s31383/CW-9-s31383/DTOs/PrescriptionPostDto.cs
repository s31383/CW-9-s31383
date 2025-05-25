namespace CW_9_s31383.DTOs;
using System.ComponentModel.DataAnnotations;

public class PrescriptionPostDto
{
    public PrescriptionPostDtoPatient Patient { get; set; } = null!;
    public PrescriptionPostDtoDoctor Doctor { get; set; } = null!;
    public IList<PrescriptionPostDtoMedicament> Medicament { get; set; } = null!;
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}




public class PrescriptionPostDtoPatient
{
    public int IdPatient { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    public DateTime Birthdate { get; set; }
}

public class PrescriptionPostDtoDoctor
{
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
public class PrescriptionPostDtoMedicament
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    [Required]
    [MaxLength(100)] 
    public string Description { get; set; } = null!;
}