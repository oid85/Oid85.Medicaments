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
[Route("api/medicaments")]
[ApiController]
public class MedicamentsController(
    IMedicamentService medicamentService)
    : BaseController
{
    /// <summary>
    /// Получить список лекарств
    /// </summary>
    [HttpPost("list")]
    [ProducesResponseType(typeof(BaseResponse<GetMedicamentListResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetMedicamentListResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<GetMedicamentListResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> GetMedicamentListAsync(
        [FromBody] GetMedicamentListRequest request) =>
        GetResponseAsync(
            () => medicamentService.GetMedicamentListAsync(request),
            result => new BaseResponse<GetMedicamentListResponse> { Result = result });

    /// <summary>
    /// Добавить лекарство
    /// </summary>
    [HttpPost("create")]
    [ProducesResponseType(typeof(BaseResponse<CreateMedicamentResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<CreateMedicamentResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<CreateMedicamentResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> CreateMedicamentAsync(
        [FromBody] CreateMedicamentRequest request) =>
        GetResponseAsync(
            () => medicamentService.CreateMedicamentAsync(request),
            result => new BaseResponse<CreateMedicamentResponse> { Result = result });

    /// <summary>
    /// Редактировать лекарство
    /// </summary>
    [HttpPost("edit")]
    [ProducesResponseType(typeof(BaseResponse<EditMedicamentResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<EditMedicamentResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<EditMedicamentResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> EditMedicamentAsync(
        [FromBody] EditMedicamentRequest request) =>
        GetResponseAsync(
            () => medicamentService.EditMedicamentAsync(request),
            result => new BaseResponse<EditMedicamentResponse> { Result = result });

    /// <summary>
    /// Удалить лекарство
    /// </summary>
    [HttpPost("delete")]
    [ProducesResponseType(typeof(BaseResponse<DeleteMedicamentResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<DeleteMedicamentResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<DeleteMedicamentResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> DeleteMedicamentAsync(
        [FromBody] DeleteMedicamentRequest request) =>
        GetResponseAsync(
            () => medicamentService.DeleteMedicamentAsync(request),
            result => new BaseResponse<DeleteMedicamentResponse> { Result = result });

    /// <summary>
    /// Пополнить лекарство
    /// </summary>
    [HttpPost("add")]
    [ProducesResponseType(typeof(BaseResponse<AddMedicamentResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<AddMedicamentResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<AddMedicamentResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> AddMedicamentAsync(
        [FromBody] AddMedicamentRequest request) =>
        GetResponseAsync(
            () => medicamentService.AddMedicamentAsync(request),
            result => new BaseResponse<AddMedicamentResponse> { Result = result });
}