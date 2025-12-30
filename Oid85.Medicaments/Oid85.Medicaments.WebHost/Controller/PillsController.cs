using Microsoft.AspNetCore.Mvc;
using Oid85.Medicaments.Application.Interfaces.Services;
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

}