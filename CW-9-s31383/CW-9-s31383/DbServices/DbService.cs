using CW_9_s31383.Models;

namespace CW_9_s31383.DbServices;
using Microsoft.EntityFrameworkCore;
using DAL;
using DTOs;

public class DbService(HospitalDbContext dbContext) : IDbService
{
    public async Task PostPrescription(CancellationToken cancellationToken, PrescriptionPostDto prescriptionPostDto)
    {
        if (prescriptionPostDto.DueDate < prescriptionPostDto.Date) 
            throw new ArgumentException("Due date cannot be earlier than prescription date");
        if (prescriptionPostDto.Medicament.Count > 10 )
            throw new ArgumentException("more then 10 medicaments");
        var table = dbContext.Medicament.Select(med => med.IdMedicament).ToList();
        var exists = prescriptionPostDto.Medicament
            .Where(med => table.Any(medicament => medicament == med.IdMedicament))
            .ToList();
        if (exists.Any())
            throw new Exception();
        var patient = new Patient
        {
            IdPatient = prescriptionPostDto.Patient.IdPatient,
            BirthDate = prescriptionPostDto.Patient.Birthdate,
            FirstName = prescriptionPostDto.Patient.FirstName,
            LastName = prescriptionPostDto.Patient.LastName,
            Prescriptions = new List<Prescription>()
        };
        var prescription = new Prescription
        {
            Date = prescriptionPostDto.Date,
            DueDate = prescriptionPostDto.DueDate,
            IdPatient = patient.IdPatient,
            Patient = patient
        };
        if (!dbContext.Patients.Contains(patient))
        {
            await dbContext.Patients.AddAsync(patient,cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        await dbContext.Prescriptions.AddAsync(prescription,cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        var medicament = prescriptionPostDto.Medicament
            .Select(med => new PrescriptionMedicament
            {
                IdMedicament = med.IdMedicament,
                IdPrescription = prescription.IdPrescription,
                Details = med.Description,
                Dose = med.Dose,
                Prescription = prescription,
                Medicament = dbContext.Medicament.First(m => m.IdMedicament == med.IdMedicament)
            }).ToList();
        foreach (var med in medicament)
        {
            dbContext.PrescriptionMedicament.Add(med);
        }
    }
    public async Task<IEnumerable<PatientGetDto>> GetPatients(CancellationToken cancellationToken)
    {
        return await dbContext.Patients.Select(patient => new PatientGetDto
        {

        }).ToListAsync(cancellationToken);
    }
}