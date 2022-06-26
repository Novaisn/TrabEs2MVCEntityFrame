using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class DepositoController: Controller
{
    private readonly MyDbContext _context;

    public DepositoController()
    {
        _context = new MyDbContext();
    }

    
    public ActionResult Index()
    {
        var db = new MyDbContext();

        List<Deposito> depositos = new List<Deposito>();
        List<Ativofinanceiro> at = new List<Ativofinanceiro>();
        
        foreach(Ativofinanceiro ativofinanceiro in db.Ativofinanceiros)
        {
            at.Add(ativofinanceiro);
        }
        
        foreach(var a in at)
        {
            if (a.Idcliente == UserSession.idutilizador)
            {
               
                var aux = db.Depositos.ToList().FindAll(d => d.Idativo == a.Idativo);
                foreach (var au in aux)
                {
                    depositos.Add(au);
                }
                
            }
        }
            
              
                 
        
       
        // ViewBag.List = imoveis;
        // ViewData["Imovel"] = imoveis;

        //return View();
        return View(depositos);
    }
   
    public IActionResult criar()
    {
        return View();
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> createatde([Bind("Datainicio,Durancao,Taxaimposto")] Ativofinanceiro ativofinanceiro,
        [Bind("Banco,Titulares,Valor,Taxajuro,Nconta")]
        Deposito deposito)
    {
        if (UserSession.idutilizador == null)
        {
            return RedirectToPage("/Auth/Login");
        }
        else
        {
            ativofinanceiro.Idcliente = UserSession.idutilizador;
            _context.Ativofinanceiros.Add(ativofinanceiro);
            _context.SaveChanges();
            deposito.Idativo = ativofinanceiro.Idativo;
            _context.Depositos.Add(deposito);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
    
    public async Task<IActionResult> Editde(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        
        
        var dep = await _context.Depositos.FindAsync(id);
        if (dep == null)
        {
            return NotFound();
        }
        Ativofinanceiro ativo = await _context.Ativofinanceiros.FindAsync(dep.Idativo);
        if(ativo!=null)
        {
            DepositoAtivoModel dam = new DepositoAtivoModel(ativo, dep);
            return View(dam);
        }

        return RedirectToAction("Index");
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editde(int id, [Bind("Iddeposito,Banco,Titulares,Valor,Taxajuro,Nconta,Idativo")] Deposito deposito,
        [Bind("Idativo,Datainicio,Durancao,Taxaimposto,Idcliente")] Ativofinanceiro ativofinanceiro)
    {
        
        
        
        if (id != deposito.Iddeposito)
        {
            return NotFound();
        }

        var errors = new List<string>();

        if (deposito.Valor is < 0)
        {
            errors.Add("O numero do montante não pode ser negativo");
        }

        if (ModelState.IsValid && errors.Count <= 0)
        {
            try
            {
                ativofinanceiro.Idativo = deposito.Idativo;
                _context.Update(ativofinanceiro);
                _context.Update(deposito);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositoExists(deposito.Iddeposito))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["UserId"] = new SelectList(_context.Utilizadors, "IdUtilizador", "Nome", deposito.IdativoNavigation!.Idcliente);
        ViewData["Errors"] = errors;
        return RedirectToAction("Index");
    }
    
    
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var dep = await _context.Depositos.FirstOrDefaultAsync(d => d.Iddeposito == id);
        if (dep == null)
        {
            return NotFound();
        }

        return View(dep);
    }

   
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
       
        var dep = await _context.Depositos.FindAsync(id);
        Ativofinanceiro? ativo = new Ativofinanceiro();

        if (dep != null)
        {
            ativo = _context.Ativofinanceiros.Find(dep.Idativo);   
        }
        else
        {
            return NotFound();
        } 
        _context.Depositos.Remove(dep);
        await _context.SaveChangesAsync();
        _context.Ativofinanceiros.Remove(ativo!);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    private bool DepositoExists(int id)
    {
        return _context.Depositos.Any(e => e.Iddeposito == id);
    }
}