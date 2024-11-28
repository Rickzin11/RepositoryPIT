using Microsoft.AspNetCore.Mvc;
using Pjt_Software.Contexts;
using Pjt_Software.Models;

namespace Pjt_Software.Controllers;

public class EstoqueController : Controller
{
    private readonly TWTodosContext _context;
        
        public EstoqueController(TWTodosContext context)
        {
            _context = context;
        }


    public IActionResult Index()
        {
            ViewData["Title"] = "Gestão de Estoque";
            var estoques = _context.Estoques.ToList();
            return View(estoques);
        }

    public IActionResult Create()
        {
            ViewData["Title"] = "Novo Item para o Estoque";
            return View("Form");
        }

    
    [HttpPost]
    public IActionResult Create(Estoque estoque)
    {
        if(ModelState.IsValid)
        {
            _context.Estoques.Add(estoque);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Novo Item para o Estoque";
        return View("Form", estoque);
    }

    public IActionResult Edit(int Id)
    {
        
        var estoque = _context.Estoques.Find(Id);
        if(estoque is null)
        {
            return NotFound();
        };
        ViewData["Title"] = "Editar Item";
        return View("Form", estoque);
    
    }

    [HttpPost]
    public IActionResult Edit(Estoque estoque)
    {
        if(ModelState.IsValid)
        {
            _context.Estoques.Update(estoque);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Editar Item";
        return View("Form", estoque);
    }

    public IActionResult Delete(int id)
    {
        var estoque = _context.Estoques.Find(id);
        if (estoque == null)
        {
            return NotFound();
        }
        return View(estoque);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var estoque = _context.Estoques.Find(id);
        if (estoque != null)
        {
            _context.Estoques.Remove(estoque);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }

}
