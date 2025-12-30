using Microsoft.AspNetCore.Mvc;
using Oid85.Medicaments.Application.Interfaces.Services;
using Oid85.Medicaments.Core;
using Oid85.Medicaments.Core.Requests;
using Oid85.Medicaments.Core.Responses;
using Oid85.Medicaments.WebHost.Controller.Base;

namespace Oid85.Medicaments.WebHost.Controller;

/// <summary>
/// Лекарства
/// </summary>
[Route("api/pills")]
[ApiController]
public class PillsController(
    IPillService pillService)
    : BaseController
{
    /// <summary>
    /// Получить список лекарств
    /// </summary>
    [HttpPost("list")]
    [ProducesResponseType(typeof(BaseResponse<GetPillListResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetPillListResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<GetPillListResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> GetPillListAsync(
        [FromBody] GetPillListRequest request) =>
        GetResponseAsync(
            () => pillService.GetPillListAsync(request),
            result => new BaseResponse<GetPillListResponse> { Result = result });

    /// <summary>
    /// Добавить лекарство
    /// </summary>
    [HttpPost("create")]
    [ProducesResponseType(typeof(BaseResponse<CreatePillResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<CreatePillResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<CreatePillResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> CreatePillAsync(
        [FromBody] CreatePillRequest request) =>
        GetResponseAsync(
            () => pillService.CreatePillAsync(request),
            result => new BaseResponse<CreatePillResponse> { Result = result });

    /// <summary>
    /// Редактировать лекарство
    /// </summary>
    [HttpPost("edit")]
    [ProducesResponseType(typeof(BaseResponse<EditPillResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<EditPillResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<EditPillResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> EditPillAsync(
        [FromBody] EditPillRequest request) =>
        GetResponseAsync(
            () => pillService.EditPillAsync(request),
            result => new BaseResponse<EditPillResponse> { Result = result });

    /// <summary>
    /// Удалить лекарство
    /// </summary>
    [HttpPost("delete")]
    [ProducesResponseType(typeof(BaseResponse<DeletePillResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<DeletePillResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<DeletePillResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> DeletePillAsync(
        [FromBody] DeletePillRequest request) =>
        GetResponseAsync(
            () => pillService.DeletePillAsync(request),
            result => new BaseResponse<DeletePillResponse> { Result = result });
}