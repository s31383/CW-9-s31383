using CW_9_s31383.Models;
using Microsoft.EntityFrameworkCore;

namespace CW_9_s31383.DAL;

public class HospitalDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }
    public DbSet<Medicament> Medicament { get; set; }
    protected HospitalDbContext()
    {
        
    }
    public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
    {
        
    }
}