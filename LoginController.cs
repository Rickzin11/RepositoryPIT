using Microsoft.AspNetCore.Mvc;
using Pjt_Software.Contexts;
using Pjt_Software.Models;
using System.Linq;

namespace Pjt_Software.Controllers;

public class LoginController : Controller
{
    private readonly TWTodosContext _context;

    public LoginController(TWTodosContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Login";
        return View();
    }

    [HttpPost]
    public IActionResult Index(Empresa empresa)
    {
        if (ModelState.IsValid)
        {
            var empresaAutenticada = _context.Empresas
                .FirstOrDefault(e => e.Email == empresa.Email && e.Senha == empresa.Senha);
            
            if (empresaAutenticada != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Email ou senha inválidos.");
        }

        ViewData["Title"] = "Login da Empresa";
        return View(empresa); // Retorna a lista de empresas para a view
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "Nova Empresa";
        return View("Form");
    }

    [HttpPost]
    public IActionResult Create(Empresa empresa)
    {
        if (ModelState.IsValid)
        {
            // Verifica se já existe uma empresa com o mesmo e-mail
            var existingEmpresa = _context.Empresas
                .FirstOrDefault(e => e.Email == empresa.Email);

            if (existingEmpresa != null)
            {
                ModelState.AddModelError("Email", "Já existe uma conta com este e-mail.");
                return View("Form", empresa);
            }

            // Adiciona a nova empresa ao contexto
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); // Redireciona para a lista de empresas após a criação
        }

        ViewData["Title"] = "Nova Empresa";
        return View("Form", empresa); // Retorna o modelo para o formulário em caso de erro
    }
}


    
