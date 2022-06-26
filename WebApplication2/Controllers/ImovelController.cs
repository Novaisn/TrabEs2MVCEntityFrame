using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class ImovelController: Controller
{
    private readonly MyDbContext _context;

        public ImovelController()
        {
            _context = new MyDbContext();
        }

        // GET
        public ActionResult Index()
        {
            var db = new MyDbContext();

            List<Imovel> imovels = new List<Imovel>();
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
                var aux = db.Imovels.ToList().FindAll(d => d.Idativo == a.Idativo);
                foreach (var au in aux)
                {
                    imovels.Add(au);
                }
            } 
            // ViewBag.List = imoveis;
            // ViewData["Imovel"] = imoveis;

            //return View();
            return View(imovels);
        }
        public IActionResult createimo()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> createati(Ativofinanceiro ativofinanceiro1)
        {
           
           Console.WriteLine(ativofinanceiro1.Taxaimposto);
            ativofinanceiro1.Idcliente = UserSession.idutilizador;
            _context.Add(ativofinanceiro1);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        

      

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> createatimo([Bind("Datainicio,Durancao,Taxaimposto")] Ativofinanceiro ativofinanceiro,
            [Bind("Nome,Valorrenda,Valorcondo,Valoresti,Rua,Nporta,Codpostal")]
            Imovel imovel)
        {
            ativofinanceiro.Idcliente = UserSession.idutilizador;
            _context.Ativofinanceiros.Add(ativofinanceiro);
            _context.SaveChanges();
            imovel.Idativo = ativofinanceiro.Idativo;
            _context.Imovels.Add(imovel);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

      public async Task<IActionResult> Editimo(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        
        
        var imo = await _context.Imovels.FindAsync(id);
        if (imo == null)
        {
            return NotFound();
        }
        Ativofinanceiro ativo = await _context.Ativofinanceiros.FindAsync(imo.Idativo);
        if(ativo!=null)
        {
            AtivoImovelModel aim = new AtivoImovelModel(imo, ativo);
            return View(aim);
        }

        return RedirectToAction("Index");
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editimo(int id, [Bind("Idimovel,Nome,Valorrenda,Rua,Valorcondo,Valoresti,Nporta,Codpostal,Idativo")] Imovel imovel,
        [Bind("Idativo,Datainicio,Durancao,Taxaimposto,Idcliente")] Ativofinanceiro ativofinanceiro)
    {
        
        
        
        if (id != imovel.Idimovel)
        {
            return NotFound();
        }

        var errors = new List<string>();

        if (imovel.Valorrenda is < 0)
        {
            errors.Add("O numero do Valor Renda não pode ser negativo");
        }
        if (imovel.Valorcondo is < 0)
        {
            errors.Add("O numero do Valor Condominio não pode ser negativo");
        }
        if (imovel.Valoresti is < 0)
        {
            errors.Add("O numero do Custos Estimado não pode ser negativo");
        }


        if (ModelState.IsValid && errors.Count <= 0)
        {
            try
            {
                
                _context.Update(ativofinanceiro);
                _context.Update(imovel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositoExists(imovel.Idimovel))
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
        ViewData["UserId"] = new SelectList(_context.Utilizadors, "IdUtilizador", "Nome", imovel.IdativoNavigation!.Idcliente);
        ViewData["Errors"] = errors;
        return RedirectToAction("index");
    }
    
    private bool DepositoExists(int id)
    {
        return _context.Depositos.Any(e => e.Iddeposito == id);
    }
       
    
    public async Task<IActionResult> DeleteImo(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var imovel = await _context.Imovels.FirstOrDefaultAsync(i => i.Idimovel == id);
        if (imovel == null)
        {
            return NotFound();
        }

        return View(imovel);
    }

   
    [HttpPost, ActionName("DeleteImo")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var imovel = await _context.Imovels.FindAsync(id);
        var ativo = await _context.Ativofinanceiros.FindAsync(imovel!.Idativo);
        _context.Imovels.Remove(imovel);
        await _context.SaveChangesAsync();
        _context.Ativofinanceiros.Remove(ativo!);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

       


}