using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using supervisor_agente.Models;
using supervisor_agente.Data;
namespace supervisor_agente.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HomeController(ApplicationDbContext _context, 
        UserManager<IdentityUser> _userManager, 
        RoleManager<IdentityRole> _roleManager,
        IPasswordHasher<IdentityUser> _passwordHasher) {
            this._userManager = _userManager;
            this._context = _context;
            this._passwordHasher = _passwordHasher;
            this._roleManager = _roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> InitUser()
        {
            int count =_context.UsuariosApp.Count();
            //si contiene registros omitir este metodo
            if(count > 0) {
                return RedirectToAction("Index");
            }
            supervisor_agente.SeedData seedData = new SeedData();
            var transaction = _context.Database.BeginTransaction();
            try {
                await _roleManager.CreateAsync(new IdentityRole {
                    Name = "SUPERVISOR"
                });
                await _roleManager.CreateAsync(new IdentityRole {
                    Name = "AGENTE"
                });
                await _context.SaveChangesAsync();
                //agregar supervisores
                foreach (var item in seedData.listSupervisores)
                {
                    item.UserName = item.Email;
                    //usuario = item (objeto), password = password
                    await _userManager.CreateAsync(item, "Supervis0r_");
                    IdentityResult result = await _userManager.AddToRoleAsync(item, "SUPERVISOR");
                    if( !result.Succeeded) {
                        throw new Exception("No se puedo agregar al usuario al rol");
                    }
                }
                //agregar agentes
                foreach (var item in seedData.listAgentes)
                {
                    item.UserName = item.Email;
                    //usuario = item (objeto), password = agente
                    await _userManager.CreateAsync(item, "Agent3_");
                    IdentityResult result = await _userManager.AddToRoleAsync(item, "AGENTE");
                    if( !result.Succeeded) {
                        throw new Exception("No se puedo agregar al usuario al rol");
                    }
                }
                await _context.SaveChangesAsync();
                transaction.Commit();
            }catch(Exception e) {
                transaction.Rollback();
            }

            return RedirectToAction("Index");
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
