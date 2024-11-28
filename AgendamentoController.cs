using Microsoft.AspNetCore.Mvc;
using Pjt_Software.Contexts;
using Pjt_Software.Models;

namespace Pjt_Software.Controllers;

public class AgendamentoController : Controller
{
    private readonly TWTodosContext _context;

    public AgendamentoController(TWTodosContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Lista de Agendamentos";
        var agendamentos = _context.Agendamentos.ToList();
        return View(agendamentos);
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "Novo Agendamento";
        return View("Form");
    }

    [HttpPost]
        public IActionResult Create(Agendamento agendamento)
    {
        if(ModelState.IsValid)
        {
            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Novo Agendamento";
        return View("Form", agendamento);
    }


    public IActionResult Edit(int Id)
    {
        
        var agendamento = _context.Agendamentos.Find(Id);
        if(agendamento is null)
        {
            return NotFound();
        };
        ViewData["Title"] = "Editar Agendamento";
        return View("Form", agendamento);
    
    }

    [HttpPost]
    public IActionResult Edit(Agendamento agendamento)
    {
        if(ModelState.IsValid)
        {
            _context.Agendamentos.Update(agendamento);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Editar Agendamento";
        return View("Form", agendamento);
    }

    public IActionResult Delete(int id)
    {
        var agendamento = _context.Agendamentos.Find(id);
        if (agendamento == null)
        {
            return NotFound();
        }
        return View(agendamento);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var agendamento = _context.Agendamentos.Find(id);
        if (agendamento != null)
        {
            _context.Agendamentos.Remove(agendamento);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }

}