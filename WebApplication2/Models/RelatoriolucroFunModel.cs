using WebApplication2.Entities;

namespace WebApplication2.Models;

public class RelatoriolucroFunModel
{
    public RelatoriolucroFunModel(Ativofinanceiro a, Fundo f)
    {
        this.Datainicio = a.Datainicio;
        this.Durancao = a.Durancao;
        this.Idativo = a.Idativo;
        this.Idcliente = a.Idcliente;
        this.Taxaimposto = (double)a.Taxaimposto;
        
        this.Idfundo = f.Idfundo;
        this.Nome = f.Nome;
        this.Montante = (double)f.Montante;
        this.Taxajuro = (double)f.Taxajuro;
    }
    
    public double LucroImposto { get; set; }
    public double Lucro { get; set; }
    public double Taxajuro { get; set; }

    public double Montante { get; set; }

    public string? Nome { get; set; }

    public int Idfundo { get; set; }

    public double Taxaimposto { get; set; }

    public int? Idcliente { get; set; }

    public int Idativo { get; set; }

    public int? Durancao { get; set; }

    public DateTime Datainicio { get; set; }
}