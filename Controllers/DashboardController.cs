using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using supervisor_agente.Models;
using supervisor_agente.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using supervisor_agente.Consulta;

namespace supervisor_agente.Controllers
{
    [Authorize(Roles = "SUPERVISOR")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        
        public DashboardController(ApplicationDbContext _context, 
        UserManager<IdentityUser> _userManager, 
        
        IPasswordHasher<IdentityUser> _passwordHasher) {
            this._userManager = _userManager;
            this._context = _context;
            this._passwordHasher = _passwordHasher;
            
        }
        public async Task<IActionResult> Index()
        {
            string sql = @"

select DATEPART(week, fecha) as semana, 
count(*) as total, 
    SUM(CASE WHEN estaResuelto = 'true' THEN 1 ELSE 0 END) as resueltos, 
	SUM(CASE WHEN estaResuelto = 'false' THEN 1 ELSE 0 END) as noResueltos
from dbo.Actividades 
where fecha >= '20210101' and fecha <= '20220101' 
group by DatePART(week, fecha)
order by DatePart(week, fecha)

            ";
            var listaConsultaPorSemana = await _context.Query<ConsultaSemana>().FromSql(sql)
            .ToListAsync();
            return View(listaConsultaPorSemana);
        }
        public async Task<IActionResult> VerAgentes() {
            return null;
        }
    }
}
