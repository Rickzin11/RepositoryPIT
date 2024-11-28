using Microsoft.AspNetCore.Mvc;
using Pjt_Software.Contexts;
using Pjt_Software.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pjt_Software.Controllers;

public class FuncionariosController : Controller
{
    private readonly TWTodosContext _context;

    public FuncionariosController(TWTodosContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Lista de Funcionário";
        var funcionarios = _context.Funcionarios.ToList();
        return View(funcionarios);
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "Novo Funcionário";
        return View("Form");
    }

    [HttpPost]
        public IActionResult Create(Funcionario funcionario)
    {
        if(ModelState.IsValid)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Novo Funcionário";
        return View("Form", funcionario);
    }


    public IActionResult Edit(int Id)
    {
        
        var funcionario = _context.Funcionarios.Find(Id);
        if(funcionario is null)
        {
            return NotFound();
        };
        ViewData["Title"] = "Editar Funcionário";
        return View("Form", funcionario);
    
    }

    [HttpPost]
    public IActionResult Edit(Funcionario funcionario)
    {
        if(ModelState.IsValid)
        {
            _context.Funcionarios.Update(funcionario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Editar Funcionário";
        return View("Form", funcionario);
    }

    public IActionResult Delete(int id)
    {
        var funcionario = _context.Funcionarios.Find(id);
        if (funcionario == null)
        {
            return NotFound();
        }
        return View(funcionario);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var funcionario = _context.Funcionarios.Find(id);
        if (funcionario != null)
        {
            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }

}

