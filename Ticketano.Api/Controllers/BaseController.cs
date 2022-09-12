using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ticketano.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public abstract class BaseController: ControllerBase
{
    
}