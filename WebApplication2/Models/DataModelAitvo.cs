using WebApplication2.Entities;

namespace WebApplication2.Models;

public class DataModelAitvo
{
    public DataModelAitvo(Ativofinanceiro ativofinanceiro)
    {
        this.Datainicio = Datainicio;
        this.Durancao = ativofinanceiro.Durancao;
        this.Taxaimposto = ativofinanceiro.Taxaimposto;
        this.Idcliente = ativofinanceiro.Idcliente;
    }

    public int? Idcliente { get; set; }

    public double? Taxaimposto { get; set; }

    public int? Durancao { get; set; }

    public String Datainicio { get; set; }
}