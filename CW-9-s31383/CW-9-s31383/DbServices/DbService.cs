using CW_9_s31383.Models;

namespace CW_9_s31383.DbServices;
using Microsoft.EntityFrameworkCore;
using DAL;
using DTOs;

public class DbService(HospitalDbContext dbContext) : IDbService
{
    public async Task PostPrescription(CancellationToken cancellationToken, PrescriptionPostDto prescriptionPostDto)
    {
        var prescription = new PrescriptionMedicament
        {
            Date = prescriptionPostDto.Date,
            DueDate = prescriptionPostDto.DueDate,
            Patient = prescriptionPostDto.,
            
        };
        dbContext.Add(prescription);
        
        await dbContext.SaveChangesAsync(cancellationToken);
    }
    public async Task<IEnumerable<PatientGetDto>> GetPatients(CancellationToken cancellationToken)
    {
        return await dbContext.Patients.Select(patient => new PatientGetDto
        {

        }).ToListAsync(cancellationToken);
    }
}