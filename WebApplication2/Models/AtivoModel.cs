namespace WebApplication2.Models;

public class AtivoModel
{
    
    public AtivoModel(Entities.Ativofinanceiro ativofinanceiro)
    {
        this.Idativo = ativofinanceiro.Idativo;
        this.Datainico = ativofinanceiro.Datainicio;
        this.Durancao = ativofinanceiro.Durancao;
        this.Taxaimposto = ativofinanceiro.Taxaimposto;
        this.Idcliente = ativofinanceiro.Idcliente;
    }

    public int? Idcliente { get; set; }

    public double? Taxaimposto { get; set; }

    public int? Durancao { get; set; }

    public DateTime Datainico { get; set; }

    public int Idativo { get; set; }
}