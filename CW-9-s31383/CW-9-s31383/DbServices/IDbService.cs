using CW_9_s31383.DTOs;

namespace CW_9_s31383.DbServices;
using Models;
public interface IDbService
{
    Task PostPrescription(CancellationToken cancellationToken, PrescriptionPostDto prescriptionPostDto);
    Task<IEnumerable<PatientGetDto>> GetPatients(CancellationToken cancellationToken);
}