using WebApplication2.Entities;

namespace WebApplication2.Models;

public class RelatoriolucroImoModel
{
    public RelatoriolucroImoModel(Ativofinanceiro a, Imovel i)
    {
        this.Datainicio = a.Datainicio;
        this.Durancao = a.Durancao;
        this.Idativo = a.Idativo;
        this.Idcliente = a.Idcliente;
        this.Taxaimposto = (double)a.Taxaimposto;
        this.Idimovel = i.Idimovel;
        this.Nome = i.Nome;
        this.Valorrenda = (double)i.Valorrenda;
        this.Valorcondo = (double)i.Valorcondo;
        this.Valoresti = (double)i.Valoresti;
        this.Rua = i.Rua;
        this.Nporta = i.Nporta;
        this.Codpostal = i.Codpostal;
    }

    public double LucroImposto { get; set; }
    
    public double Lucro { get; set; }
    public string? Codpostal { get; set; }

    public string? Nporta { get; set; }

    public string? Rua { get; set; }

    public double Valoresti { get; set; }

    public double Valorcondo { get; set; }

    public double Valorrenda { get; set; }

    public string? Nome { get; set; }

    public int Idimovel { get; set; }

    public double Taxaimposto { get; set; }

    public int? Idcliente { get; set; }

    public int Idativo { get; set; }

    public int? Durancao { get; set; }

    public DateTime Datainicio { get; set; }
}