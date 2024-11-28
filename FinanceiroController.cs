using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pjt_Software.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pjt_Software.Controllers
{
    public class FinanceiroController : Controller
    {
        private readonly TWTodosContext _context;

        public FinanceiroController(TWTodosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var query = _context.Financeiros.AsQueryable();

                if (startDate.HasValue)
                    query = query.Where(f => f.Data >= startDate.Value);
                if (endDate.HasValue)
                    query = query.Where(f => f.Data <= endDate.Value);

                var dadosGrafico = await query
                    .GroupBy(f => f.Data.Date)
                    .Select(g => new
                    {
                        Data = g.Key.ToString("dd/MM/yyyy"),
                        TotalLucro = g.Sum(f => f.Lucro),
                        TotalDespesas = g.Sum(f => f.Despesas)
                    })
                    .ToListAsync();

                ViewBag.DadosGrafico = dadosGrafico; // Passa os dados para a view
                return View();  // Retorna a view sem dados
            }
            catch (Exception ex)
            {
                return View("Error", new { Message = "Erro ao processar a requisição.", Details = ex.Message });
            }
        }
    }
}