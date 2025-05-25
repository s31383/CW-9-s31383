namespace CW_9_s31383.Controllers;
using DbServices;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("patients")]
public class PatientController(IDbService dbService) : ControllerBase
{
    public async Task<ActionResult> GetPatients(CancellationToken cancellationToken, int index)
    {
        return Ok(await dbService.GetPatients(cancellationToken));
    }
}