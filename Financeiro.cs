using Microsoft.AspNetCore.Mvc;

namespace Projeto_de_Software.Controllers;

public class FinanceiroController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

}