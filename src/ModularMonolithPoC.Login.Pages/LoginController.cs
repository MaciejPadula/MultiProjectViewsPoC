using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModularMonolithPoC.Login.Pages.Models;

namespace ModularMonolithPoC.Login.Pages;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly ILoginService _loginService;

    public LoginController(ILogger<LoginController> logger, ILoginService loginService)
    {
        _logger = logger;
        _loginService = loginService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromForm] LoginSave input, [FromQuery] string redirectUrl)
    {
        if (await _loginService.ValidateUser(input.Login, input.Password))
        {
            return Redirect(redirectUrl);
        }

        throw new Exception("Invalid login or password");
    }
}
