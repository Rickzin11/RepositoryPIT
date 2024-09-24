using Microsoft.AspNetCore.Mvc;

namespace Projeto_de_Software.Controllers;

public class EstoqueController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

}