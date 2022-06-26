using WebApplication2.Entities;

namespace WebApplication2.Models;

public class AtivoFundoModel
{
    public AtivoFundoModel(Ativofinanceiro? a, Fundo f)
    {

        this.Idativo = a.Idativo;
        this.Durancao = a!.Durancao;
        this.Taxaimposto = a.Taxaimposto;
        this.Idcliente = a.Idcliente;
        this.Datainicio = a.Datainicio!;

        this.Idfundo = f.Idfundo;
        this.Nome = f.Nome;
        this.Montante = f.Montante;
        this.Taxajuro = f.Taxajuro;
        this.Idativo = f.Idativo;
    }

    public int Idfundo { get; set; }

    public int? Idativo { get; set; }

    public double? Taxajuro { get; set; }

    public double? Montante { get; set; }

    public string? Nome { get; set; }

    public int? Idcliente { get; set; }

    public double? Taxaimposto { get; set; }

    public int? Durancao { get; set; }

    public DateTime Datainicio { get; set; }
}