using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class RelatorioController: Controller
{
    private readonly MyDbContext _context;

    public RelatorioController()
    {
        _context = new MyDbContext();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult DatasFun()
    {
        return View();
    }
    public IActionResult DatasImo()
    {
        return View();
    }
    public IActionResult DatasDep()
    {
        return View();
    }
    
    public ActionResult EntreDatasFun(DatasModel datasModel)
    {
        var db = new MyDbContext();

        List<Fundo> fundos = new List<Fundo>();
        List<Ativofinanceiro> at = new List<Ativofinanceiro>();
        List<RelatoriolucroFunModel> afs = new List<RelatoriolucroFunModel>();
        
        foreach(Ativofinanceiro ativofinanceiro in db.Ativofinanceiros)
        {
            at.Add(ativofinanceiro);
        }
        foreach(var a in at)
        {
            if (a.Idcliente == UserSession.idutilizador)
            {
                if (a.Datainicio > datasModel.DtInicio && a.Datainicio < datasModel.DtFim)
                {
                    var aux = db.Fundos.ToList().FindAll(d => d.Idativo == a.Idativo);
                    foreach (var au in aux)
                    {
                        fundos.Add(au);
                    }
                }
            }
        }

        foreach (var a in at)
        {
            foreach (var i in fundos)
            {
                if (a.Idativo == i.Idativo)
                {
                    RelatoriolucroFunModel afm = new RelatoriolucroFunModel(a,i);
                    afs.Add(afm);
                }
            }
        }

        foreach (var a in afs)
        {
            a.Lucro = (a.Montante * a.Taxajuro);
            a.LucroImposto = (a.Lucro) - (a.Lucro * a.Taxaimposto);
        }

        RelatoriolucroListFun relatoriolucroListFun = new RelatoriolucroListFun();
        relatoriolucroListFun.relatoriolucroFunModel = afs;
        foreach (var x in relatoriolucroListFun.relatoriolucroFunModel)
        {
            relatoriolucroListFun.Lucro += x.Lucro;
            relatoriolucroListFun.LucroImposto += x.LucroImposto;
        }
        
        return View(relatoriolucroListFun);
    }
    
    
    public ActionResult EntreDatasImo(DatasModel datasModel)
    {
        var db = new MyDbContext();

        List<Imovel> imovels = new List<Imovel>();
        List<Ativofinanceiro> at = new List<Ativofinanceiro>();
        List<RelatoriolucroImoModel> afs = new List<RelatoriolucroImoModel>();
        
        foreach(Ativofinanceiro ativofinanceiro in db.Ativofinanceiros)
        {
            at.Add(ativofinanceiro);
        }
        foreach(var a in at)
        {
            if (a.Idcliente == UserSession.idutilizador)
            {
                if (a.Datainicio > datasModel.DtInicio && a.Datainicio < datasModel.DtFim)
                {
                    var aux = db.Imovels.ToList().FindAll(d => d.Idativo == a.Idativo);
                    foreach (var au in aux)
                    {
                        imovels.Add(au);
                    }
                }
            }
        }

        foreach (var a in at)
        {
            foreach (var i in imovels)
            {
                if (a.Idativo == i.Idativo)
                {
                    RelatoriolucroImoModel afm = new RelatoriolucroImoModel(a,i);
                    afs.Add(afm);
                }
            }
        }

        foreach (var a in afs)
        {
            a.Lucro = ((a.Valorrenda * 12) - (a.Valorcondo+a.Valoresti));
            a.LucroImposto = (a.Lucro) - (a.Lucro * a.Taxaimposto);
        }

        RelatoriolucroIListmoModel relatoriolucroListImo = new RelatoriolucroIListmoModel();
        relatoriolucroListImo.relatoriolucroImoModel = afs;
        foreach (var x in relatoriolucroListImo.relatoriolucroImoModel)
        {
            relatoriolucroListImo.Lucro += x.Lucro;
            relatoriolucroListImo.LucroImposto += x.LucroImposto;
        }
        
        return View(relatoriolucroListImo);
    }
    
    public ActionResult EntreDatasDep(DatasModel datasModel)
    {
        var db = new MyDbContext();

        List<Deposito> depositos = new List<Deposito>();
        List<Ativofinanceiro> at = new List<Ativofinanceiro>();
        List<RelatoriolucroDepModel> afs = new List<RelatoriolucroDepModel>();
        
        foreach(Ativofinanceiro ativofinanceiro in db.Ativofinanceiros)
        {
            at.Add(ativofinanceiro);
        }
        foreach(var a in at)
        {
            if (a.Idcliente == UserSession.idutilizador)
            {
                if (a.Datainicio > datasModel.DtInicio && a.Datainicio < datasModel.DtFim)
                {
                    var aux = db.Depositos.ToList().FindAll(d => d.Idativo == a.Idativo);
                    foreach (var au in aux)
                    {
                        depositos.Add(au);
                    }
                }
            }
        }

        foreach (var a in at)
        {
            foreach (var i in depositos)
            {
                if (a.Idativo == i.Idativo)
                {
                    RelatoriolucroDepModel afm = new RelatoriolucroDepModel(a,i);
                    afs.Add(afm);
                }
            }
        }

        foreach (var a in afs)
        {
            a.Lucro = a.Valor * a.Taxajuro;
            a.LucroImposto = (a.Lucro) - (a.Lucro * a.Taxaimposto);
        }

        RelatoriolucroListDepModel relatoriolucroListDepModel = new RelatoriolucroListDepModel();
        relatoriolucroListDepModel.relatoriolucroDepModel = afs;
        foreach (var x in relatoriolucroListDepModel.relatoriolucroDepModel)
        {
            relatoriolucroListDepModel.Lucro += x.Lucro;
            relatoriolucroListDepModel.LucroImposto += x.LucroImposto;
        }
        
        return View(relatoriolucroListDepModel);
    }

    public ActionResult RelatorioImposto()
    {
        var db = new MyDbContext();

        List<Fundo> fundos = new List<Fundo>();
        List<Ativofinanceiro> at = new List<Ativofinanceiro>();
        List<RelatoriolucroFunModel> afs = new List<RelatoriolucroFunModel>();
        
        foreach(Ativofinanceiro ativofinanceiro in db.Ativofinanceiros)
        {
            at.Add(ativofinanceiro);
        }
        foreach(var a in at)
        {
            if (a.Idcliente == UserSession.idutilizador)
            {
                
                
                    var aux = db.Fundos.ToList().FindAll(d => d.Idativo == a.Idativo);
                    foreach (var au in aux)
                    {
                        fundos.Add(au);
                    }
                
            }
        }

        foreach (var a in at)
        {
            foreach (var i in fundos)
            {
                if (a.Idativo == i.Idativo)
                {
                    RelatoriolucroFunModel afm = new RelatoriolucroFunModel(a,i);
                    afs.Add(afm);
                }
            }
        }

        foreach (var a in afs)
        {
            a.Lucro = (a.Montante * a.Taxajuro);
            a.LucroImposto = (a.Lucro) - (a.Lucro * a.Taxaimposto);
        }
        
        

        List<Imovel> imovels = new List<Imovel>();
        
        List<RelatoriolucroImoModel> ais = new List<RelatoriolucroImoModel>();
        
        
        foreach(var a in at)
        {
            if (a.Idcliente == UserSession.idutilizador)
            {
                
                    var aux = db.Imovels.ToList().FindAll(d => d.Idativo == a.Idativo);
                    foreach (var au in aux)
                    {
                        imovels.Add(au);
                    }
                
            }
        }

        foreach (var a in at)
        {
            foreach (var i in imovels)
            {
                if (a.Idativo == i.Idativo)
                {
                    RelatoriolucroImoModel afm = new RelatoriolucroImoModel(a,i);
                    ais.Add(afm);
                }
            }
        }

        foreach (var a in ais)
        {
            a.Lucro = ((a.Valorrenda * 12) - (a.Valorcondo+a.Valoresti));
            a.LucroImposto = (a.Lucro) - (a.Lucro * a.Taxaimposto);
        }
        

        List<Deposito> depositos = new List<Deposito>();
        
        List<RelatoriolucroDepModel> ads = new List<RelatoriolucroDepModel>();
        
        
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

        foreach (var a in at)
        {
            foreach (var i in depositos)
            {
                if (a.Idativo == i.Idativo)
                {
                    RelatoriolucroDepModel afm = new RelatoriolucroDepModel(a,i);
                    ads.Add(afm);
                }
            }
        }

        foreach (var a in ads)
        {
            a.Lucro = a.Valor * a.Taxajuro;
            a.LucroImposto = (a.Lucro) - (a.Lucro * a.Taxaimposto);
        }

        RelatorioImpostoModel rm = new RelatorioImpostoModel();
        rm.relatorioDepModel = ads;
        rm.relatorioFunModel = afs;
        rm.relatorioImoModel = ais;

        foreach (var x in rm.relatorioDepModel)
        {
            rm.Imposto += (x.Lucro * x.Taxaimposto);
        }
        foreach (var x in rm.relatorioFunModel)
        {
            rm.Imposto += (x.Lucro * x.Taxaimposto);
        }
        foreach (var x in rm.relatorioImoModel)
        {
            rm.Imposto += (x.Lucro * x.Taxaimposto);
        }

        return View(rm);
    }
}