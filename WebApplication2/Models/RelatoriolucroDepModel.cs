using WebApplication2.Entities;

namespace WebApplication2.Models;

public class RelatoriolucroDepModel
{
    public RelatoriolucroDepModel(Ativofinanceiro a , Deposito d)
    {
        this.Datainicio = a.Datainicio;
        this.Durancao = a.Durancao;
        this.Idativo = a.Idativo;
        this.Idcliente = a.Idcliente;
        this.Taxaimposto = (double)a.Taxaimposto;
        
        this.Iddeposito = d.Iddeposito;
        this.Banco = d.Banco;
        this.Titulares = d.Titulares;
        this.Valor = (double)d.Valor;
        this.Taxajuro = (double)d.Taxajuro;
        this.Nconta = d.Nconta;

    }

    public double Lucro { get; set; }
    
    public double LucroImposto { get; set; }
    public string? Nconta { get; set; }

    public double Taxajuro { get; set; }

    public double Valor { get; set; }

    public string? Titulares { get; set; }

    public string? Banco { get; set; }

    public int Iddeposito { get; set; }

    public double Taxaimposto { get; set; }

    public int? Idcliente { get; set; }

    public int Idativo { get; set; }

    public int? Durancao { get; set; }

    public DateTime Datainicio { get; set; }
}