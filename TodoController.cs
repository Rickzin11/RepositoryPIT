using Microsoft.AspNetCore.Mvc;
using Pjt_Software.Contexts;
using Pjt_Software.Models;

namespace Pjt_Software.Controllers;

public class TodoController : Controller
{
    private readonly TWTodosContext _context;
    
    public TodoController(TWTodosContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        ViewData["Title"] = "Lista de Teste";
        var todos = _context.Todos.ToList();
        return View(todos);
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "Nova Tarefa";
        return View("Form");
    }

    [HttpPost]
        public IActionResult Create(Todo todo)
    {
        if(ModelState.IsValid)
        {
            todo.CreatedAt = DateTime.Now;
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Nova Tarefa";
        return View("Form", todo);
    }

    public IActionResult Edit(int Id)
    {
        
        var todo = _context.Todos.Find(Id);
        if(todo is null)
        {
            return NotFound();
        };
        ViewData["Title"] = "Editar Tarefa";
        return View("Form", todo);
    
    }

    [HttpPost]
    public IActionResult Edit(Todo todo)
    {
        if(ModelState.IsValid)
        {
            _context.Todos.Update(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Editar Tarefa";
        return View("Form", todo);
    }

    public IActionResult Delete(int Id)
    {
        var todo = _context.Todos.Find(Id);
        if(todo is null)
        {
            return NotFound();
        };
        ViewData["Title"] = "Excluir Tarefa";
        return View(todo);
    }

    [HttpPost]
    public IActionResult Delete(Todo todo)
    {
        _context.Todos.Remove(todo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
