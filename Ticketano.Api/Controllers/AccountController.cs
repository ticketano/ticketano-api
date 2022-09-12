using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ticketano.BLL.Services;
using Ticketano.Domain.Models;

namespace Ticketano.Api.Controllers;

public class AccountController: BaseController
{
    private readonly AccountService _accountService;
    
    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<ActionResult> SignIn([FromBody]SignInModel user)
    {
        var result = await _accountService.SignIn(user);
        return Ok(result);
    }

    [HttpPost("sign-up")]
    [AllowAnonymous]
    public async Task<ActionResult> SignUp([FromBody] SignUpModel model)
    {
        await _accountService.SignUp(model);
        return NoContent();
    }
}