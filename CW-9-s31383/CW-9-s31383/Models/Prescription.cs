using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW_9_s31383.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public int IdPatient { get; set; }
    
    public int IdDoctor { get; set; }
    
    [ForeignKey(nameof(IdDoctor))] 
    public Doctor Doctor { get; set; } 
    
    [ForeignKey(nameof(IdPatient))]
    public Patient Patient { get; set; } = null!;
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicament { get; set; } = null!;
}