using Microsoft.AspNetCore.Mvc;
using Pjt_Software.Contexts;
using Pjt_Software.Models;

namespace Pjt_Software.Controllers;

public class ServicosController : Controller
{
    private readonly TWTodosContext _context;
        
        public ServicosController(TWTodosContext context)
        {
            _context = context;
        }


    public IActionResult Index()
        {
            ViewData["Title"] = "Serviços";
            var servicos = _context.Servicos.ToList();
            return View(servicos);
        }

    public IActionResult Create()
        {
            ViewData["Title"] = "Novo Serviço";
            return View("Form");
        }

    
    [HttpPost]
    public IActionResult Create(Servico servico)
    {
        if(ModelState.IsValid)
        {
            _context.Servicos.Add(servico);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Novo Serviço";
        return View("Form", servico);
    }

    public IActionResult Edit(int Id)
    {
        
        var servico = _context.Servicos.Find(Id);
        if(servico is null)
        {
            return NotFound();
        };
        ViewData["Title"] = "Editar Serviço";
        return View("Form", servico);
    
    }

    [HttpPost]
    public IActionResult Edit(Servico servico)
    {
        if(ModelState.IsValid)
        {
            _context.Servicos.Update(servico);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Editar Serviço";
        return View("Form", servico);
    }

    public IActionResult Delete(int id)
    {
        var servico = _context.Servicos.Find(id);
        if (servico == null)
        {
            return NotFound();
        }
        return View(servico);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var servico = _context.Servicos.Find(id);
        if (servico != null)
        {
            _context.Servicos.Remove(servico);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }

}
