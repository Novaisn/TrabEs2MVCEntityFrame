using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class FundoController: Controller
{
    private readonly MyDbContext _context;

    public FundoController()
    {
        _context = new MyDbContext();
    }
    public ActionResult Index()
    {
        var db = new MyDbContext();

        List<Fundo> fundos = new List<Fundo>();
        List<Ativofinanceiro> at = new List<Ativofinanceiro>();
        
        foreach(Ativofinanceiro ativofinanceiro in db.Ativofinanceiros)
        {
            if (ativofinanceiro.Idcliente == UserSession.idutilizador)
            {
                at.Add(ativofinanceiro);
            }
        }
        foreach(var a in at)
        {
            var aux = db.Fundos.ToList().FindAll(d => d.Idativo == a.Idativo);
            foreach (var au in aux)
            {
                fundos.Add(au);
            }
        } 
        // ViewBag.List = imoveis;
        // ViewData["Imovel"] = imoveis;

        //return View();
        return View(fundos);
        
    }
    
    public IActionResult criar()
    {
        return View();
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> createatfun([Bind("Datainicio,Durancao,Taxaimposto")] Ativofinanceiro ativofinanceiro,
        [Bind("Nome,Montante,Taxajuro")]
        Fundo fundo)
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
            fundo.Idativo = ativofinanceiro.Idativo;
            _context.Fundos.Add(fundo);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
    
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        
        
        var fundo = await _context.Fundos.FindAsync(id);
        if (fundo == null)
        {
            return NotFound();
        }
        Ativofinanceiro ativo = await _context.Ativofinanceiros.FindAsync(fundo.Idativo);
        if(ativo!=null)
        {
            AtivoFundoModel afm = new AtivoFundoModel(ativo, fundo);
            return View(afm);
        }
       
        
        


        return RedirectToAction("Index");
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Idfundo,Nome,Montante,Taxajuro,Idativo")] Fundo fundo,
        [Bind("Idativo,Datainicio,Durancao,Taxaimposto,Idcliente")] Ativofinanceiro ativofinanceiro)
    {
        
        
        
        if (id != fundo.Idfundo)
        {
            return NotFound();
        }

        var errors = new List<string>();

        if (fundo.Montante is < 0)
        {
            errors.Add("O numero do montante não pode ser negativo");
        }

        if (ModelState.IsValid && errors.Count <= 0)
        {
            try
            {
                ativofinanceiro.Idativo = fundo.Idativo;
                _context.Update(ativofinanceiro);
                _context.Update(fundo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundoExists(fundo.Idfundo))
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
        ViewData["UserId"] = new SelectList(_context.Utilizadors, "IdUtilizador", "Nome", fundo.IdativoNavigation!.Idcliente);
        ViewData["Errors"] = errors;
        return RedirectToAction("Edit");
    }
    
    
    public IActionResult Details()
    {
        return View();
    }
    
    
    
    
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var fundo = await _context.Fundos.FirstOrDefaultAsync(f => f.Idfundo == id);
        if (fundo == null)
        {
            return NotFound();
        }

        return View(fundo);
    }

    // POST: Meal/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var fundo = await _context.Fundos.FindAsync(id);
        var ativo = await _context.Ativofinanceiros.FindAsync(fundo!.Idativo);
        _context.Fundos.Remove(fundo);
        await _context.SaveChangesAsync();
        _context.Ativofinanceiros.Remove(ativo!);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    
    private bool FundoExists(int id)
    {
        return _context.Fundos.Any(e => e.Idfundo == id);
    }
}
