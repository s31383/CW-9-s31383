using CW_9_s31383.DbServices;
using CW_9_s31383.DTOs;
using CW_9_s31383.Models;
using Microsoft.AspNetCore.Mvc;

namespace CW_9_s31383.Controllers;

[ApiController]
[Route("prescription")]
public class PrescriptionController(IDbService dbService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post(CancellationToken cancellationToken,PrescriptionPostDto prescription)
    {
        try
        {
            await dbService.PostPrescription(cancellationToken, prescription);
            return Ok();
        } 
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}