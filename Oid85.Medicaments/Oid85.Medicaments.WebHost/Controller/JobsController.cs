using Microsoft.AspNetCore.Mvc;
using Oid85.Medicaments.Application.Interfaces.Services;
using Oid85.Medicaments.Core;
using Oid85.Medicaments.Core.Requests;
using Oid85.Medicaments.Core.Responses;
using Oid85.Medicaments.WebHost.Controller.Base;

namespace Oid85.Medicaments.WebHost.Controller;

/// <summary>
/// Задачи по расписанию
/// </summary>
[Route("api/jobs")]
[ApiController]
public class JobsController(
    IJobService jobService)
    : BaseController
{
    /// <summary>
    /// Обновить остатки лекарств
    /// </summary>
    [HttpPost("update-reserve")]
    [ProducesResponseType(typeof(BaseResponse<GetMedicamentListResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetMedicamentListResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<GetMedicamentListResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMedicamentListAsync(
        [FromBody] GetMedicamentListRequest request)
    {
        await jobService.UpdateReserveAsync();
        return Ok();
    }
}