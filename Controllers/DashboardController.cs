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

            sql = @"
select usu.*, anu.UserName from (
	select u.Id as Id, count(*) as Total 
	from AspNetUsers u
	inner join Actividades a
	on a.usuarioAppId = u.Id
	group by u.Id
	order by count(*) DESC
	OFFSET  0 ROWS 
	FETCH NEXT 3 ROWS ONLY 
) as usu
inner join AspNetUsers anu
on anu.Id = usu.Id
            ";
            var listaAgenteMasLlamadas = await _context.Query<AgenteConsulta>().FromSql(sql)
            .ToListAsync();
            sql = @"
select usu.*, anu.UserName from (
	select u.Id as Id, count(*) as Total 
	from AspNetUsers u
	inner join Actividades a
	on a.usuarioAppId = u.Id
	group by u.Id
	order by count(*) ASC
	OFFSET  0 ROWS 
	FETCH NEXT 3 ROWS ONLY 
) as usu
inner join AspNetUsers anu
on anu.Id = usu.Id
            ";
            var listaAgenteMenosLlamadas = await _context.Query<AgenteConsulta>().FromSql(sql)
            .ToListAsync();
            ModeloConsulta modelo = new ModeloConsulta {
                listaAgenteMasLlamadas = listaAgenteMasLlamadas, 
                listaAgenteMenosLlamadas = listaAgenteMenosLlamadas, 
                listaConsultaPorSemana = listaConsultaPorSemana
            };
            return View(modelo);
        }
        public async Task<IActionResult> VerAgentes() {
            return null;
        }
    }
}
