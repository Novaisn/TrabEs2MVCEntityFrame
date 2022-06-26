
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class AdminController:Controller
{
    private readonly MyDbContext _context;

    public AdminController()
    {
        _context = new MyDbContext();
    }
    public async Task<IActionResult> Index()
    {
        var db = new MyDbContext();

        
        var MyDbContext = _context.Utilizadors;
        return View(await MyDbContext.OrderBy(m => m.Nome).ToListAsync());
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var uti = await _context.Utilizadors.FirstOrDefaultAsync(u => u.Idutilizador == id);
        if (uti == null)
        {
            return NotFound();
        }

        return View(uti);
    }

    // POST: Meal/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var uti = await _context.Utilizadors.FindAsync(id);
        var ativos = new List<Ativofinanceiro>();

        if (uti == null)
        {
            return NotFound();
        }
        
        if (uti.Idutilizador == UserSession.idutilizador)
        {
            return NotFound();
        }
        foreach(var a in _context.Ativofinanceiros)
        {
            if (uti != null && a.Idcliente == uti.Idutilizador)
            {
              ativos.Add(a);
            }
        }

        foreach (var a in ativos)
        {
             
            foreach (var i in _context.Imovels)
            {
                if (a.Idativo == i.Idativo)
                {
                    _context.Imovels.Remove(i);
                    
                }
            }
            foreach (var d in _context.Depositos)
            {
                if (a.Idativo == d.Idativo)
                {
                    _context.Depositos.Remove(d);
                   
                }
            }
            foreach (var f in _context.Fundos)
            {
                if (a.Idativo == f.Idativo)
                {
                    _context.Fundos.Remove(f);
                    
                }
            }
              

        }

        foreach (var a in ativos)
        {
            _context.Ativofinanceiros.Remove(a);
            _context.SaveChanges();   
        }
       
        if (uti != null)
        {
            _context.Utilizadors.Remove(uti);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult CreateUser()
    {
        return View();
    }

    public async Task<IActionResult> Registar(Utilizador utilizador)
    {
        var errors = new List<string>();

        if (utilizador.Tipouser > 3)
        {
            errors.Add("O tipo de utilizador nao pode ser maior que 3");
        }
        if (utilizador.Tipouser < 0)
        {
            errors.Add("O tipo de utilizador nao pode ser menor que 0");
        }

        if (ModelState.IsValid && errors.Count <= 0)
        {
            _context.Add(utilizador);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewData["Errors"] = errors;
        return View("CreateUser");
    }

    
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var utilizador = await _context.Utilizadors.FindAsync(id);
        if (utilizador == null)
        {
            return NotFound();
        }
       
        return View(utilizador);
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Utilizador utilizador)
    {
        if (id != utilizador.Idutilizador)
        {
            return NotFound();
        }

        var errors = new List<string>();

        if (utilizador.Tipouser is < 0)
        {
            errors.Add("O tipo de utilizador não pode ser menor que 0");
        }
        if (utilizador.Tipouser is > 3)
        {
            errors.Add("O tipo de utilizador não pode ser maior que 3");
        }

        if (ModelState.IsValid && errors.Count <= 0)
        {
            try
            {
                _context.Update(utilizador);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtExists(utilizador.Idutilizador))
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
        
        ViewData["Errors"] = errors;
        return View(utilizador);
    }
    
    private bool UtExists(int id)
    {
        return _context.Utilizadors.Any(e => e.Idutilizador == id);
    }
    
    public ActionResult Imovel()
    {
        var db = new MyDbContext();

        List<Imovel> imovels = new List<Imovel>();
        List<Ativofinanceiro> at = new List<Ativofinanceiro>();
        List<AtivoImovelModel> ais = new List<AtivoImovelModel>();
        foreach(Ativofinanceiro ativofinanceiro in db.Ativofinanceiros)
        {
            at.Add(ativofinanceiro);
        }
        foreach(var a in at)
        {
            var aux = db.Imovels.ToList().FindAll(d => d.Idativo == a.Idativo);
            foreach (var au in aux)
            {
                imovels.Add(au);
            }
        }

        foreach (var a in at)
        {
            foreach (var i in imovels)
            {
                if (a.Idativo == i.Idativo)
                {
                    AtivoImovelModel aim = new AtivoImovelModel(i, a);
                    ais.Add(aim);
                }
            }
        }
        
        return View(ais);
    }
    
        public ActionResult Fundo()
        {
            var db = new MyDbContext();

            List<Fundo> fundos = new List<Fundo>();
            List<Ativofinanceiro> at = new List<Ativofinanceiro>();
            List<AtivoFundoModel> afs = new List<AtivoFundoModel>();
            foreach(Ativofinanceiro ativofinanceiro in db.Ativofinanceiros)
            {
                at.Add(ativofinanceiro);
            }
            foreach(var a in at)
            {
                var aux = db.Fundos.ToList().FindAll(d => d.Idativo == a.Idativo);
                foreach (var au in aux)
                {
                    fundos.Add(au);
                }
            }

            foreach (var a in at)
            {
                foreach (var i in fundos)
                {
                    if (a.Idativo == i.Idativo)
                    {
                        AtivoFundoModel aim = new AtivoFundoModel(a,i);
                        afs.Add(aim);
                    }
                }
            }
        
            return View(afs);
        }
    
    public ActionResult Deposito()
    {
        var db = new MyDbContext();

        List<Deposito> depositos = new List<Deposito>();
        List<Ativofinanceiro> at = new List<Ativofinanceiro>();
        List<DepositoAtivoModel> das = new List<DepositoAtivoModel>();
        foreach(Ativofinanceiro ativofinanceiro in db.Ativofinanceiros)
        {
            at.Add(ativofinanceiro);
        }
        foreach(var a in at)
        {
            var aux = db.Depositos.ToList().FindAll(d => d.Idativo == a.Idativo);
            foreach (var au in aux)
            {
                depositos.Add(au);
            }
        }

        foreach (var a in at)
        {
            foreach (var i in depositos)
            {
                if (a.Idativo == i.Idativo)
                {
                    DepositoAtivoModel aim = new DepositoAtivoModel(a,i);
                    das.Add(aim);
                }
            }
        }
        
        return View(das);
    }
    public IActionResult Relatorio()
    {
        return View();
    }

    public ActionResult RelatorioImposto(BancoModel model)
    {
        var db = new MyDbContext();

        List<Deposito> depositos = new List<Deposito>();
        List<Ativofinanceiro> af = new List<Ativofinanceiro>();
        List<RelatorioBancoModel>  rbm = new List<RelatorioBancoModel>();
        
        foreach(Ativofinanceiro ativofinanceiro in db.Ativofinanceiros)
        {
            af.Add(ativofinanceiro);
        }
        
        foreach(var a in af)
        {
            
                if (a.Datainicio > model.DtInicio && a.Datainicio < model.DtFim)
                {
                    var aux = db.Depositos.ToList().FindAll(d => d.Idativo == a.Idativo && d.Banco == model.Banco);
                    foreach (var au in aux)
                    {
                        depositos.Add(au);
                    }
                }
            
        }
        
        RelatorioBancoModel r = new RelatorioBancoModel();
            foreach (var x in depositos)
            {
                
                   
                    r.depositos.Add(x);
                    r.TotalDep +=(double) x.Valor;
                    r.Totaljuro += (double) (x.Valor * x.Taxajuro);

            }

            return View(r);
    }
    
}