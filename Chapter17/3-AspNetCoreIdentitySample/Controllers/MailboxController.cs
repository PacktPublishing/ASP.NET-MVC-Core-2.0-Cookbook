using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class MailboxController : Controller
{
    [Authorize]
    public IActionResult Index() => View();
}