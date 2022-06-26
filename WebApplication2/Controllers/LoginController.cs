using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Entities;
using WebApplication2.Models;



namespace WebApplication2.Controllers;

public class AuthController : Controller
{
    private readonly MyDbContext _context;
    private int aux = 0;
    public AuthController()
    {
        _context = new MyDbContext();
    }
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([Bind("Email,Password")] LoginModel login)
    {
        //var passHash = $"\\x{ComputeSha256Hash(login.Password)}";

        var user = _context.Utilizadors
            .FirstOrDefault(u => u.Username.Equals(login.Email) && u.Pass.Equals(login.Password));

        if (user != null)
        {
           
            Console.WriteLine(UserSession.Username);
            UserSession.nome = user.Nome;
            UserSession.idutilizador = user.Idutilizador;
            UserSession.TipoUser = user.Idutilizador;
            Console.WriteLine(UserSession.nome);
            Console.WriteLine(UserSession.UserId);
            
            if (user.Tipouser == 1)
            {
                return RedirectToAction(controllerName: "Home", actionName: "Index");
            }
            if (user.Tipouser == 2)
            {
                return RedirectToAction(controllerName: "Manager", actionName: "Index");
            }
            if (user.Tipouser == 3)
            {
                return RedirectToAction(controllerName: "Admin", actionName: "Index");
            }
        }
            
        ViewData["HasError"] = true;
            
        return View(login);
    }
    public IActionResult registou()
    {
        return View();
    }

    public async Task<IActionResult> Registar(Utilizador utilizador)
    {
        var uti = _context.Utilizadors.ToList().Count;
        if (uti.Equals(0))
        {
            utilizador.Tipouser = 3;
        }
        utilizador.Tipouser = 1;
        _context.Add(utilizador);
        _context.SaveChanges();
        return RedirectToAction("Login");
    }

    public async Task<IActionResult> Logout()
    {
        return RedirectToAction("Login");
    }
}