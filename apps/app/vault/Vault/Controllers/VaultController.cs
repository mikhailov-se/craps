using Microsoft.AspNetCore.Mvc;

namespace Vault.Controllers;

[ApiController]
[Route("[controller]")]
public class VaultController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public VaultController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("test")]
    public string Test(string name)
    {
        return _configuration.GetValue<string>(name);
    }
}
